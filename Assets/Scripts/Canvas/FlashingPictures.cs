using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingPictures : MonoBehaviour
{
    public GameObject Image_1;                                    
    public GameObject Image_2;

    //Предназначен для обучения новых игроков
    void Start()
    {
        Image_1.SetActive(false);
        Image_2.SetActive(false);
    }

    // Куратина вкл/выкл Image_1, Image_2 через задержку
    IEnumerator Shadow()
    {
        Image_1.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        Image_1.SetActive(false);
        Image_2.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Image_2.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))         
        {
            if (PlayerPrefs.GetInt("Totalcoins") == 0)           //Если Totalcoins = 0 то запустить куратину
                                                                            
            {
                StartCoroutine(Shadow());
            }           
        }
       
    }
}
