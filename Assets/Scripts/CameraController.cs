using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController: MonoBehaviour
{

    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    protected float nowX_p;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
        nowX_p = 0;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if(playerTransform.position.x > nowX_p)
        {
            nowX_p = playerTransform.position.x;
            transform.position = new Vector3(nowX_p, transform.position.y, transform.position.z);
        }
        else if(playerTransform.position.x < nowX_p)
        {
            nowX_p = playerTransform.position.x;
            transform.position = new Vector3(nowX_p, transform.position.y, transform.position.z);
        }

    }

}