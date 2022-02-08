using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioSource GainAudio;                        //����� ����
    public GameObject Shop;                              //������ ��������
    public GameObject Main;                              //������� ������
    public void StartGame()
    {
        StartCoroutine(RunGame());                    
    }
   public IEnumerator RunGame()
    {
        GainAudio.Play();                                //��� ����� ����
        SceneManager.LoadScene(1);                       //��������� �����
        yield return new WaitForSeconds(0.5f);           //��������
        Main.SetActive(false);                           //������� ������(������� ����������)

    }
    public void ShopMenu()                               //����� ��� ��������
    {
        GainAudio.Play();                                
        Shop.SetActive(true);                            
        Main.SetActive(false);
    }
    public void Back()                                   //����� �������� �� ������� ������
    {
        GainAudio.Play();
        Shop.SetActive(false);
        Main.SetActive(true);
    }

    public void QuitGame()                              //����� �� ���� �� ����������
    {
        Application.Quit();
    }
}
