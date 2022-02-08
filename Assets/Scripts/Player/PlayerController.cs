using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;                     //функция управления персонажем
    public WorldController WC;                          //используется для остановки платформ

    private Animator animator;                          //анимация персонажа
    public AudioSource MainMusic;                       //аудио файл


    public Text TextCoins;                              //выводит coins в canvas
    public Text TextTotaltCoins;                        //выводит totalcoins в canvas
  
    //public ParticleSystem bonusEffect;                //эффект подбора бонуса
    public ParticleSystem FailEffect;                   //эффект смерти

    public GameObject UiRestart;                        //панель рестарта
    public GameObject ButtonStart;                      //кнопка старта
    public GameObject ButtonRight;                      //кнопка скачка направо
    public GameObject ButtonLeft;                       //кнопка скачка налево
    public GameObject PanelFinish;                      //кнопка для перехода на следующий уровень

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
        TextCoins.text = "" + coins.ToString();         //выводит в canvas coins
    }

    public void StartAndroid()                          //запускает корутину при нажатии на экран
    {
        StartCoroutine(LetGo());                      
        ButtonStart.SetActive(false);                   //скрывает кнопку старт
    }
    public void ControlLeft()                           //кнопка управления персонажем
    {
        cc.Move(Vector3.left * 1.6f);
    }
    public void ControlRight()                          //кнопка управления персонажем
    {
        cc.Move(Vector3.right * 1.6f);
    }


    IEnumerator LetGo()                                //корутину устанавливает в скрипте WorldController переменной 
    {                                                  //speed значение 3 тем самым стартуют платформы
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("Start");
        WC.StartGame();
    }

    //Куратина действий в случаи проигрыша
    IEnumerator Death()                               //корутина проигрыша(выключает управление,музыку,анимацию 
    {                                                 //сохраняет игру и выводит меню проигрыша)
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
        PlayerPrefs.SetInt("Totalcoins", Totalcoins); // << сохранение кол-во денег
    }

    //Взаимодействия игрока с тегами которые он встречает в игру
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

