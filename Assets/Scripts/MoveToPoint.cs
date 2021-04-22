using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{

    public float speed = 1f;
    public GameObject player;//����� �� ��������� ��������� ��� ������� Object;

    void Start()
    {
        player = (GameObject)this.gameObject; //��� ����������� ��������� � �������� Object ��� ���-�� ���.
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;//�������� ������ ��������� �� W,S,D,A;
        }                                              //�� ����� � ������, ��� ����(�� ��� �� � �������)
    }
}