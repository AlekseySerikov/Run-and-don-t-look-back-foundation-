using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStop : MonoBehaviour
{
    public AudioSource GroundMusic; //аудио файл
    private WorldController WC;     //Скрипт взят для контроля движения платформ
    void Start()
    {
        WC = GetComponent<WorldController>();
    }

    //Выключает музыку при проигрыше
    void Update()
    {
        if (WC.speed != 0)          //Если WorldController не = 0 
        {
            GroundMusic.Play();     //Вкл аудио
        }
        else
        {
            GroundMusic.Stop();     //Выкл аудио
        }
        
    }
}
