using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController: MonoBehaviour
{
    public bool canBack = false;
    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    protected float nowX;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
        nowX = 0;
    }

    void FixedUpdate()
    {
         MoveCamera();
    }

    void MoveCamera()
    {
        if(playerTransform.position.x > nowX)
        {
            nowX = playerTransform.position.x;
            transform.position = new Vector3(nowX, transform.position.y, transform.position.z);
        }
        if(canBack &&playerTransform.position.x < nowX)
        {
            nowX = playerTransform.position.x;
            transform.position = new Vector3(nowX, transform.position.y, transform.position.z);
        }
    }

}