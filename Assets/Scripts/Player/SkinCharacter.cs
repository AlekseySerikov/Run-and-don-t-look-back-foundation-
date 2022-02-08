using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCharacter : MonoBehaviour
{
    public GameObject Skin_1;
    public GameObject Skin_2;
    public int chois = 0;


    //Скрипт получает данный с первой сцены, передает ее в переменную chois для активации/деактивации скинов.
    private void Start()
    {

        chois = PlayerPrefs.GetInt("temporaryNumb");
    }
    private void Update()
    {

        if (chois == 1)
        {
            Skin_1.SetActive(false);
            Skin_2.SetActive(true);
        }
        else
        {
            Skin_1.SetActive(true);
            Skin_2.SetActive(false);
        }
            
    }


}
