using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    //”ничтожает по тегу
    private void OnTriggerEnter(Collider coll)
    {
        switch (coll.tag)
        {
            case "Death":
                {
                    Destroy(coll.gameObject);
                    break;
                }
        }
    }
}
