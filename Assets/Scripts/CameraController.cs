using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController: MonoBehaviour
{

    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    protected float nowX;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
        //nowX = playerTransform.position.x;
        nowX = 0;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if(playerTransform.position.x > nowX)
        {
            nowX = playerTransform.position.x;
        }

        //â°ï˚å¸ÇæÇØí«è]
        transform.position = new Vector3(nowX, transform.position.y, transform.position.z);
    }

}