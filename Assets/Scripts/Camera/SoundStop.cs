using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStop : MonoBehaviour
{
    public AudioSource GroundMusic; //����� ����
    private WorldController WC;     //������ ���� ��� �������� �������� ��������
    void Start()
    {
        WC = GetComponent<WorldController>();
    }

    //��������� ������ ��� ���������
    void Update()
    {
        if (WC.speed != 0)          //���� WorldController �� = 0 
        {
            GroundMusic.Play();     //��� �����
        }
        else
        {
            GroundMusic.Stop();     //���� �����
        }
        
    }
}
