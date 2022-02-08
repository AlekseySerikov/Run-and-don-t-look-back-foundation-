using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioSource GainAudio;                        //Аудио файл
    public GameObject Shop;                              //Панель магазина
    public GameObject Main;                              //Главная панель
    public void StartGame()
    {
        StartCoroutine(RunGame());                    
    }
   public IEnumerator RunGame()
    {
        GainAudio.Play();                                //Вкл аудио файл
        SceneManager.LoadScene(1);                       //Запускает сцену
        yield return new WaitForSeconds(0.5f);           //Задержка
        Main.SetActive(false);                           //Главная панель(Сделать неактивной)

    }
    public void ShopMenu()                               //Метод для магазина
    {
        GainAudio.Play();                                
        Shop.SetActive(true);                            
        Main.SetActive(false);
    }
    public void Back()                                   //Метод возврата на главную панель
    {
        GainAudio.Play();
        Shop.SetActive(false);
        Main.SetActive(true);
    }

    public void QuitGame()                              //Выход из игры на устройстве
    {
        Application.Quit();
    }
}
