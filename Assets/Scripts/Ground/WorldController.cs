using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public float speed = 0;                                    //скорость движения платформы
    public float minZ;                                         //растояние на котором происходит удаление
    public WorldBuilder worldBuilder;
    public delegate void TryToDellAndAddPlatform();
    public event TryToDellAndAddPlatform OnPlatformMovement;
    public static WorldController instance;
    public int ZoneCoint = 0;
    public bool isStart;


    //Скрипт движения платформ

    //Паттрен Singleton для проверки на наличие 2 такихже обьектов
    private void Awake()
    {
        if (WorldController.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        WorldController.instance = this;
    }


    private void OnDestroy()
    {
        WorldController.instance = null;
    }
    void Start()
    {
        StartCoroutine(OnPlatformMovementCorutine());
    }

    //Постепенное увеличение скорости движения платформы
    void FixedUpdate()
    {

        if (speed >= 3f)
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
            speed += 0.0015f;
        }
        else if (speed >= 8f)
        {
            speed = 8f;
        }
    }

    public void StartGame()
    {
        speed = 3f;
    }
  
    public void Death()
    {
        speed = 0f;
    }

    public void Finish()
    {
        speed = 0f;
    }
    IEnumerator OnPlatformMovementCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (OnPlatformMovement != null)
            {
                OnPlatformMovement();
            }

        }
    }
}
