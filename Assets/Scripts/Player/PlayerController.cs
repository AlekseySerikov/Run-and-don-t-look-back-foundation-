using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;                     //������� ���������� ����������
    public WorldController WC;                          //������������ ��� ��������� ��������

    private Animator animator;                          //�������� ���������
    public AudioSource MainMusic;                       //����� ����


    public Text TextCoins;                              //������� coins � canvas
    public Text TextTotaltCoins;                        //������� totalcoins � canvas
  
    //public ParticleSystem bonusEffect;                //������ ������� ������
    public ParticleSystem FailEffect;                   //������ ������

    public GameObject UiRestart;                        //������ ��������
    public GameObject ButtonStart;                      //������ ������
    public GameObject ButtonRight;                      //������ ������ �������
    public GameObject ButtonLeft;                       //������ ������ ������
    public GameObject PanelFinish;                      //������ ��� �������� �� ��������� �������

   [SerializeField] private int coins = 0;              //coins
   [SerializeField] private int Totalcoins = 0;         //Totalcoins


    private void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        Totalcoins = PlayerPrefs.GetInt("Totalcoins");
    }

    public void Update()
    {
        TextCoins.text = "" + coins.ToString();         //������� � canvas coins
    }

    public void StartAndroid()                          //��������� �������� ��� ������� �� �����
    {
        StartCoroutine(LetGo());                      
        ButtonStart.SetActive(false);                   //�������� ������ �����
    }
    public void ControlLeft()                           //������ ���������� ����������
    {
        cc.Move(Vector3.left * 1.6f);
    }
    public void ControlRight()                          //������ ���������� ����������
    {
        cc.Move(Vector3.right * 1.6f);
    }


    IEnumerator LetGo()                                //�������� ������������� � ������� WorldController ���������� 
    {                                                  //speed �������� 3 ��� ����� �������� ���������
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("Start");
        WC.StartGame();
    }

    //�������� �������� � ������ ���������
    IEnumerator Death()                               //�������� ���������(��������� ����������,������,�������� 
    {                                                 //��������� ���� � ������� ���� ���������)
        MainMusic.Stop();
        animator.enabled = false;
        WC.Death();
        SavingDate();
        ButtonRight.SetActive(false);
        ButtonLeft.SetActive(false);
        yield return new WaitForSeconds(2.5f);   
        UiRestart.SetActive(true);
    }

    public void SavingDate()
    {
        Totalcoins += coins;
        PlayerPrefs.SetInt("Totalcoins", Totalcoins); // << ���������� ���-�� �����
    }

    //�������������� ������ � ������ ������� �� ��������� � ����
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

            case "coint":
                {
                    coins++;
                    break;
                }
            case "Danger":
                {
                    FailEffect.Play();
                    StartCoroutine(Death());
                    break;
                }
        }
    }
}

