using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDooor : MonoBehaviour
{
    public Rigidbody [] rb;                                   //������ ��� �������� ��������� �����
    public new AudioSource audio;

    private Vector3 force;                                    //���� ����������� � ��������
    [SerializeField] private float chois;

    //������ ��� ������ �����

    private void Start()
    {
        for (int i = 0; i < rb.Length; i++)                   //���� ����������� ��������� � ���������
        {
            rb[i].isKinematic = true;
        }
        chois = Random.Range(0, 10);                          //random �� 1 - 10
        force = new Vector3(chois, chois, chois);             //���������� ����� ���������� �� x y z
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                            //���� ����� ��������
        {
            audio.Play();                                     //���������� ����� ����
            for (int i = 0; i < rb.Length; i++)               
            {
                rb[i].isKinematic = false;                    //��������� ������� � ���������
                rb[i].AddForce(force * 2, ForceMode.Impulse); // ����������� ���� �� �������� �����
            }

        }
    }
}
