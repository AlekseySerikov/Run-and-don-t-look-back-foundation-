using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopGame : MonoBehaviour
{
    public AudioSource soundSelect;                                 //аудио файл
    public GameObject BuyButton;                                    //кнопка для покупки      
    public Text Coins;                                              //text для отображения totalcoins на canvas
    public Text Skin_1;                                             //для отображения выбранного скина
    public Text Skin_2;                                             //для отображения выбранного скина

    public int SelectedSkin = 0;                                    //переменная для хранения выбранного скина         
    public int NumdSkin = 0;                                        //номер скина
    public int TotalCoins = 0;                                      //всего очков
    public int ActivationCheck;



    private void Start()
    {
        TotalCoins = PlayerPrefs.GetInt("Totalcoins");              //записывает ранее сохраненые очки 
        Skin_1.text = PlayerPrefs.GetString("SelectString");        //текст отображает выбанно или нет
        Skin_2.text = PlayerPrefs.GetString("SelectString2");       //текст отображает выбанно или нет 
    }

    private void Update()
    {
        Coins.text = "" + TotalCoins.ToString();                    //выводит в canvas кол-во очков

        ActivationCheck = PlayerPrefs.GetInt("SetActive");          //считывает значение из PlayerPrefs
        if (ActivationCheck == 0)                                   //проверка есть 0 вкл ели 1 выкл
        {
            BuyButton.SetActive(true);
        }
        else if (ActivationCheck == 1)
        {
            BuyButton.SetActive(false);
        }

    }

    //Метод, выбирает скин по нажатию на кнопку
    public void Select_skin_1()
    {
        soundSelect.Play();                                         //вкл аудио файл
        Skin_1.text = "ВЫБРАН";                                     //выводит выбран скин или нет 
        Skin_2.text = "ВЫБРАТЬ";
        SelectedSkin = 0;                                           //присваивает SelectedSkin значение 0
        PlayerPrefs.SetInt("temporaryNumb", SelectedSkin);          //записывает  значение 0 в PlayerPrefs
        PlayerPrefs.SetString("SelectString",Skin_1.text);          //записывает PlayerPrefs выбранный текст
        PlayerPrefs.SetString("SelectString2",Skin_2.text);         //записывает PlayerPrefs выбранный текст
    }
    //Метод, выбирает скин по нажатию на кнопку
    public void Select_skin_2()
    {
        soundSelect.Play();                                         //вкл аудио файл
        Skin_2.text = "ВЫБРАН";                                     //выводит выбран скин или нет 
        Skin_1.text = "ВЫБРАТЬ";
        SelectedSkin = 1;                                           // Присваивает значение 1
        PlayerPrefs.SetInt("temporaryNumb", SelectedSkin);          //записывает  значение 0 в PlayerPrefs
        PlayerPrefs.SetString("SelectString", Skin_1.text);         //записывает PlayerPrefs выбранный текст 
        PlayerPrefs.SetString("SelectString2", Skin_2.text);        //записывает PlayerPrefs выбранный текст
    }

    //Осуществляет покупку. Если обьект не куплен кнопка активна, если куплет не активна
    public void BuySkin()
    {
        if (TotalCoins >= 300)
        {
            TotalCoins -= 300;
            PlayerPrefs.SetInt("Totalcoins", TotalCoins);
            ActivationCheck += 1;
            PlayerPrefs.SetInt("SetActive", ActivationCheck);

        }
    }
    
    //Удаляет данные из playerPref
    public void Delete()
    {
        PlayerPrefs.DeleteKey("SelectString");
        PlayerPrefs.DeleteKey("SelectString2");
        PlayerPrefs.DeleteKey("Totalcoins");
        PlayerPrefs.DeleteKey("КУПЛЕНО");
        PlayerPrefs.DeleteAll();
    }
    
}
