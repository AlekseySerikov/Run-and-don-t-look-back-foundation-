using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    //���������� �� ����
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
