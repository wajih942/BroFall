using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� �Է°��� ���� �¿�յڷ� �̵��ϰ� �ʹ�.
// shiftŰ�� ������ ���� �޸��� �ʹ�.
// jumpŰ�� ������ �ٰ� �ʹ�.
public class LHS_Player : MonoBehaviour
{

    // �̵��ӵ�
    public float speed = 10;
    // �����޸��� �ӵ�
    public float runSpeed = 2f;
    // ���� �Ŀ�
    public float jumpPower = 5;

    float hAxis;
    float vAxis;

    Vector3 moveVec;

    

    private Camera currentCamera;
    public bool UseCameraRotation = true;

    Animator anim;
    Rigidbody rigid;

    // ����
    bool jDown;
    bool isJump;
    // ���� �޸���
    bool rDown;
    // �߰��׼�
    //bool isVictory;

    //�� �浹 �÷��� (��輱�� ��ҳ� �ȴ�ҳ�)
    bool isBorder;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

    }

    private void Start()
    {
        currentCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        //Victory();
    }

    //�浹 ���� �� ���� ȸ���� ���ϰ� �ʹ�.
    // ������ ���� ���� ���ֱ�
    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    // �� ����� �����ϰ� �ʹ�.
    void StopToWall()
    {
        // ������ġ, ��� ���� * ���� , ��
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
        // Wall ������ ture -> Move�� ���ѻ������� �ɱ�  
        isBorder = Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall"));
    }

private void FixedUpdate()
    {
        FreezeRotation();
        StopToWall();
    }

    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        jDown = Input.GetButton("Jump");
        //shift ��ư�� RunFast �߰���
        // rDown = Input.GetButton("Runfast");
        //isVictory = Input.GetButton("victory");
    }

    void Move()
    {
        // �̵��ϰ�ʹ�
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //ī�޶� �������� �����ش�.
        if (UseCameraRotation)
        {
            //ī�޶��� yȸ���� ���ؿ´�.
            Quaternion v3Rotation = Quaternion.Euler(0f, currentCamera.transform.eulerAngles.y, 0f);
            //�̵��� ���͸� ������.
            moveVec = v3Rotation * moveVec;
            //Debug.Log(currentCamera.transform.eulerAngles.y.ToString());
        }

        if(!isBorder)
        // ���׿����ڷ� ���� ����
        // bool ���� ���� ? trun �� �� �� : false �϶� ��
        transform.position += moveVec * (rDown ? speed * runSpeed : speed) * Time.deltaTime;

        // Move �ִϸ��̼� true
        anim.SetBool("isMove", moveVec != Vector3.zero);
        // ���� �޸���
        anim.SetBool("isRun", rDown);
    }

    void Turn()
    {
        // �ڿ������� ȸ�� = ���ư��� �������� �ٶ󺻴�
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        // jump�ϰ� �մ� ��Ȳ���� Jump���� �ʵ��� ����
        // ������ �ϰ� ���� �ʴٸ�
        if(jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            
            // Jump Trigger true  ����
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

   /* void Victory()
    {
        anim.SetTrigger("victory");
        isVictory =  true;
    }*/

    // �ٴڿ� ����� �� �ٽ� flase�� �ٲ��ش�. 
    private void OnCollisionEnter(Collision collision)
    {
        // �±װ� �ٴ��̶�� 
        if(collision.gameObject.layer == 6)
        {
            isJump = false;  
        }
    }

}
  



