using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject [] freePlatforms;
    public GameObject [] DifficultPlatform;
    public GameObject [] HardtPlatform;
    public GameObject [] EventtPlatform;
    public GameObject [] FinishPlatform;
    public Transform platformContainer;

    private bool isObstecle;
    public int counter = 0;
    private Transform lastPlatform = null;


    //Скрипт запускает куратину для создания платформ
    void Start()
    {
        CreateFreePlatform();
        Init();
    }

   
    public void Init()
    {

        for (int i = 0; i < 2; i++)
        {
            CreatePlatform();   
        }
    }

    //Метод для чередования создания платформ.Так же используется counter для срабатования эвентов
    public void CreatePlatform()
    {
        switch (isObstecle)
        {
            case true:
                {
                    CreateDifficultPlatform();
                    counter++;
                    break;
                }
            case false:
                {
                    CreateHardtPlatform();
                    counter++;
                    break;
                }
        }
        switch (counter)
        {

            case 5:
                {
                    CreateEventtPlatform();
                    counter++;
                    break;
                }
            case 20:
                {
                    CreateEventtPlatform();
                    counter++;
                    break;
                }
            case 30:
                {
                    CreateEventtPlatform();
                    counter++;
                    break;
                }
        }
    }
    private void CreateFreePlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        int index = Random.Range(0, freePlatforms.Length);
        GameObject res = Instantiate(freePlatforms[index],pos,Quaternion.identity,platformContainer);
        lastPlatform = res.transform;
        isObstecle = false;
    }
    private void CreateDifficultPlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        int index = Random.Range(0, DifficultPlatform.Length);
        GameObject res = Instantiate(DifficultPlatform[index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
        isObstecle = false;
    }
    private void CreateHardtPlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        int index = Random.Range(0, HardtPlatform.Length);
        GameObject res = Instantiate(HardtPlatform[index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
        isObstecle = true;
    }

    private void CreateEventtPlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;
        int index = Random.Range(0, EventtPlatform.Length);
        GameObject res = Instantiate(EventtPlatform[index], pos, Quaternion.identity, platformContainer);
        lastPlatform = res.transform;
    }
}
