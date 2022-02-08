using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform endPoint;

    //Скрипт отслеживает конец платформы и создает новую платформу
    void Start()
    {
        WorldController.instance.OnPlatformMovement += TryToDellAndAddPlatform;
    }


    private void TryToDellAndAddPlatform()
    {
        if (transform.position.z < WorldController.instance.minZ)
        {
            WorldController.instance.worldBuilder.CreatePlatform();
            Destroy(gameObject);
        }
        
    }

    private void OnDestroy()
    {
        WorldController.instance.OnPlatformMovement -= TryToDellAndAddPlatform;
    }
}
