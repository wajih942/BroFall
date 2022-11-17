using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints_SJ : MonoBehaviour
{
    //���� �ð��� ����
    public float minTime = 1;
    public float maxTime = 5;
    //���� �ð�
    float createTime;
    //��� �ð�
    float currentTime;
    //����� ������ ��ġ
    public Transform[] spawnPoints;
    //��� ����
    public GameObject ballFactory;

    void Start()
    {
        //���� �ð��� ���� �������� ����
        createTime = Random.Range(minTime, maxTime);
    }


    void Update()
    {
        //1. �ð��� �귯�� �Ѵ�
        currentTime += Time.deltaTime;
        //2. ���� ��� �ð��� ���� �ð��� �ʰ��ߴٸ�
        if (currentTime > createTime)
        {
            //3. ��� ����
            GameObject ball = Instantiate(ballFactory);
            //4. ��� ��ġ ����
            //�������� spawnPoints �� �ϳ��� �̴´�
            int index = Random.Range(0, spawnPoints.Length);
            //����� ��ġ�� �������� ���� spawnPoint �� ��ġ�� �Ҵ�
            ball.transform.position = spawnPoints[index].position;
            //5. ��� �ð� �ʱ�ȭ
            currentTime = 0;
            //6. ���� �ð� ���Ҵ�
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
