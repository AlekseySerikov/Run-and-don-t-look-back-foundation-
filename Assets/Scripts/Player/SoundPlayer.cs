using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource Death;
    public AudioSource Bonus;
    public AudioSource Move;

    //������ ��������� ��������� ��������� (���������, ������ ������)
    void Start()
    {

    }

    public void SoundDeath()
    {
        Death.Play();
    }
    public void SoundBonus()
    {
        Bonus.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

            case "coint":
                {
                    Bonus.Play();
                    break;
                }

            case "Danger":
                {
                    Death.Play();
                    break;
                }

        }
    }
}
    
