using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki3_controller : MonoBehaviour
{
    private float walkSpeed = -5.0f;
    private bool entered = false;
    public Vector2 start_pos, end_pos;
    public float speed;
    public bool Downward = false;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(Downward == true)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y * -1, 0);
        }
    }
    
    void FixedUpdate()
    {
        if((start_pos.x >= player.gameObject.transform.position.x) && (player.gameObject.transform.position.x >= end_pos.x) && (start_pos.y >= player.gameObject.transform.position.y) && (player.gameObject.transform.position.y >= end_pos.y))
        {
            entered = true;
        }
        if(entered == true && Downward == false)
        {
            this.transform.Translate(0, speed, 0);
        }
        else if(entered == true && Downward == true)
        {
            this.transform.Translate(0, -speed, 0);
        }
        if(this.transform.position.y > 100 || this.transform.position.y < -100)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
