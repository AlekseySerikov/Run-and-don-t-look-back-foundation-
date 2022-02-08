using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveCoinsTotal : MonoBehaviour
{
    public Text Coins;

    public void Update()
    {
        Coins.text = "" + PlayerPrefs.GetInt("Totalcoins").ToString(); //Сохраняет на устройство кол-во coins
    } 
    
}
