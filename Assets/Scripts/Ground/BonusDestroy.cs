using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDestroy : MonoBehaviour
{

    //���������� ������ �� ����(� ������ ������ �����)

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
