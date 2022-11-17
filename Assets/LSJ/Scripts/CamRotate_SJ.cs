using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate_SJ : MonoBehaviour
{
    float rx;
    float ry;
    public float rotSpeed = 200;

    public Transform body;

    Vector3 nearPosition;
    Vector3 farPosition;
    float wheelValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ī�޶��� ���� ����� ��ġ�� �÷��̾ �������� �� ���� ��ġ�� ����
        nearPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺�� �Է� ���� �̿��ؼ�
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        rx += rotSpeed * my * Time.deltaTime;
        ry += rotSpeed * mx * Time.deltaTime;

        // rx�� ȸ�� ���� �����ϰ� �ʹ� -80�� ~ + 80��
        rx = Mathf.Clamp(rx, -80, 80);

        // ȸ���ϰ� �ʹ�
        transform.eulerAngles = new Vector3(-rx, ry, 0);

        body.transform.eulerAngles = new Vector3(0, ry, 0);


        // �ɸ޶��� ���� ������ �������� ���� ������ 5m �������� ����
        farPosition = nearPosition + transform.forward * -5;
        // ���콺 ��ũ�� �ٷ� �̵�
        wheelValue -= Input.GetAxis("Mouse ScrollWheel");
        wheelValue = Mathf.Clamp(wheelValue, 0, 1.0f); // 0~1 ���̷� ����

        // ���� ��ġ - ���� ��ġ ���� ������ ����
        Vector3 camPosition = Vector3.Lerp(nearPosition, farPosition, wheelValue);

        transform.localPosition = camPosition;
    }
}
