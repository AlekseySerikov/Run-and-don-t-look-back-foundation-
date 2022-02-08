using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShadow : MonoBehaviour
{
    private float delay;                         //задержка межды миганием
    private float minIntensity = 0;              //минимальная интенсивность
    private float maxIntensity = 4;              //максимальная интенсивность
    private Light myLight;
    private float timeElapsed;                   //сцетчик времени

    //Скрит на мигающую лампочку
    private void Awake()
    {
        delay = Random.Range(0.2f, 1f);
        myLight = GetComponent<Light>();

    }


    private void Update()
    {
        if (myLight != null)                     //если не равно 0
        {
            timeElapsed += Time.deltaTime;       //считает время

            if (timeElapsed >= delay)            //если timeElapsed больше или равно delay
            {
                timeElapsed = 0;                 //timeElapsed прировнять к 0
                ToggleLight();                   
            }
        }
    }

    //Метод делает минимальное значени есть стоит максимальное и наоборот
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
