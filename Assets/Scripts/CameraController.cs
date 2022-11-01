using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController: MonoBehaviour
{
    public bool can_y = false;
    public bool canBack = false;
    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;
    protected float nowX;
    float nowY;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
        nowX = this.gameObject.transform.position.x;
        nowY = this.gameObject.transform.position.y;
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
        if(can_y && playerTransform.position.y > nowY)
        {
            nowY = playerTransform.position.y;
            transform.position = new Vector3(transform.position.x,nowY,transform.position.z);
        }
        if(can_y && playerTransform.position.y < 0){
            //nowY = playerTransform.position.y;
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }
        if(can_y && playerTransform.position.y > 0 && playerTransform.position.y < nowY){
            nowY = playerTransform.position.y;
            transform.position = new Vector3(transform.position.x,nowY,transform.position.z);
        }
    }

}