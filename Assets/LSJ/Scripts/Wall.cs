using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            bouncing b = collision.gameObject.GetComponent<bouncing>();

            Vector3 income = b.MovePos; // �Ի纤��
            Vector3 normal = collision.contacts[0].normal; // ��������
            b.MovePos = Vector3.Reflect(income, normal).normalized; // �ݻ纤��
        }
    }
}
