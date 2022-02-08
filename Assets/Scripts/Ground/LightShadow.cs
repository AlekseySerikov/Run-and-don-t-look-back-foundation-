using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShadow : MonoBehaviour
{
    private float delay;                         //�������� ����� ��������
    private float minIntensity = 0;              //����������� �������������
    private float maxIntensity = 4;              //������������ �������������
    private Light myLight;
    private float timeElapsed;                   //������� �������

    //����� �� �������� ��������
    private void Awake()
    {
        delay = Random.Range(0.2f, 1f);
        myLight = GetComponent<Light>();

    }


    private void Update()
    {
        if (myLight != null)                     //���� �� ����� 0
        {
            timeElapsed += Time.deltaTime;       //������� �����

            if (timeElapsed >= delay)            //���� timeElapsed ������ ��� ����� delay
            {
                timeElapsed = 0;                 //timeElapsed ���������� � 0
                ToggleLight();                   
            }
        }
    }

    //����� ������ ����������� ������� ���� ����� ������������ � ��������
    public void ToggleLight()
    {

        if (myLight != null)
        {
            if (myLight.intensity == minIntensity)
            {
                myLight.intensity = maxIntensity;
            }
            else if (myLight.intensity == maxIntensity)
            {
                myLight.intensity = minIntensity;
            }
        }
    }
}
