using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform [] target;
    private int ChoisSet = 0;

    [Range(0.01f, 1f)]

    private float smoothSpeed = 0.125f;


    [SerializeField] private Vector3 offset;


    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
       ChoisSet += PlayerPrefs.GetInt("temporaryNumb");
    }
    private void LateUpdate()
    {

        Vector3 desiredPosition = target[ChoisSet].position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
