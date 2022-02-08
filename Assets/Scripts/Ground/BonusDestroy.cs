using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDestroy : MonoBehaviour
{

    //”ничтожает обьект по тегу(в данном случаи бонус)

    private void OnTriggerEnter(Collider coll)
    {
        switch (coll.tag)
        {
            case "Player":
                {
                    Destroy(gameObject);
                    break;
                }
        }
    }
}
