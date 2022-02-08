using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDooor : MonoBehaviour
{
    public Rigidbody [] rb;                                   //массив для хранения элементов двери
    public new AudioSource audio;

    private Vector3 force;                                    //сила приложенная к обьектам
    [SerializeField] private float chois;

    //Скрипт для взрыва двери

    private void Start()
    {
        for (int i = 0; i < rb.Length; i++)                   //цыкл включающщий кинематик у элементов
        {
            rb[i].isKinematic = true;
        }
        chois = Random.Range(0, 10);                          //random от 1 - 10
        force = new Vector3(chois, chois, chois);             //случаенное число передается на x y z
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                            //если игрок косается
        {
            audio.Play();                                     //включается аудио файл
            for (int i = 0; i < rb.Length; i++)               
            {
                rb[i].isKinematic = false;                    //уберается галочка с кинематик
                rb[i].AddForce(force * 2, ForceMode.Impulse); // добовляется сила на элементы двери
            }

        }
    }
}
