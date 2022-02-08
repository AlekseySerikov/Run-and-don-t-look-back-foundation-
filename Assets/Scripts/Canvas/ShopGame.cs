using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopGame : MonoBehaviour
{
    public AudioSource soundSelect;                                 //����� ����
    public GameObject BuyButton;                                    //������ ��� �������      
    public Text Coins;                                              //text ��� ����������� totalcoins �� canvas
    public Text Skin_1;                                             //��� ����������� ���������� �����
    public Text Skin_2;                                             //��� ����������� ���������� �����

    public int SelectedSkin = 0;                                    //���������� ��� �������� ���������� �����         
    public int NumdSkin = 0;                                        //����� �����
    public int TotalCoins = 0;                                      //����� �����
    public int ActivationCheck;



    private void Start()
    {
        TotalCoins = PlayerPrefs.GetInt("Totalcoins");              //���������� ����� ���������� ���� 
        Skin_1.text = PlayerPrefs.GetString("SelectString");        //����� ���������� ������� ��� ���
        Skin_2.text = PlayerPrefs.GetString("SelectString2");       //����� ���������� ������� ��� ��� 
    }

    private void Update()
    {
        Coins.text = "" + TotalCoins.ToString();                    //������� � canvas ���-�� �����

        ActivationCheck = PlayerPrefs.GetInt("SetActive");          //��������� �������� �� PlayerPrefs
        if (ActivationCheck == 0)                                   //�������� ���� 0 ��� ��� 1 ����
        {
            BuyButton.SetActive(true);
        }
        else if (ActivationCheck == 1)
        {
            BuyButton.SetActive(false);
        }

    }

    //�����, �������� ���� �� ������� �� ������
    public void Select_skin_1()
    {
        soundSelect.Play();                                         //��� ����� ����
        Skin_1.text = "������";                                     //������� ������ ���� ��� ��� 
        Skin_2.text = "�������";
        SelectedSkin = 0;                                           //����������� SelectedSkin �������� 0
        PlayerPrefs.SetInt("temporaryNumb", SelectedSkin);          //����������  �������� 0 � PlayerPrefs
        PlayerPrefs.SetString("SelectString",Skin_1.text);          //���������� PlayerPrefs ��������� �����
        PlayerPrefs.SetString("SelectString2",Skin_2.text);         //���������� PlayerPrefs ��������� �����
    }
    //�����, �������� ���� �� ������� �� ������
    public void Select_skin_2()
    {
        soundSelect.Play();                                         //��� ����� ����
        Skin_2.text = "������";                                     //������� ������ ���� ��� ��� 
        Skin_1.text = "�������";
        SelectedSkin = 1;                                           // ����������� �������� 1
        PlayerPrefs.SetInt("temporaryNumb", SelectedSkin);          //����������  �������� 0 � PlayerPrefs
        PlayerPrefs.SetString("SelectString", Skin_1.text);         //���������� PlayerPrefs ��������� ����� 
        PlayerPrefs.SetString("SelectString2", Skin_2.text);        //���������� PlayerPrefs ��������� �����
    }

    //������������ �������. ���� ������ �� ������ ������ �������, ���� ������ �� �������
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
    
    //������� ������ �� playerPref
    public void Delete()
    {
        PlayerPrefs.DeleteKey("SelectString");
        PlayerPrefs.DeleteKey("SelectString2");
        PlayerPrefs.DeleteKey("Totalcoins");
        PlayerPrefs.DeleteKey("�������");
        PlayerPrefs.DeleteAll();
    }
    
}
