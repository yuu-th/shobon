using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_foot : MonoBehaviour
{
    bool running = false,jumping = false,stopping = false;
    float horizontal;
    Rigidbody2D rigid2D;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        jumping = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (rigid2D.velocity.x >= 2 && rigid2D.velocity.x <= -2 && collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" && jumping == true)
        {
            rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
            jumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Mathf.Abs(rigid2D.velocity.x) > 3.0f && collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block")
        {
            running = true;
        }

        if (horizontal < 0.5 && horizontal > -0.5 && collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" && running == true)
        {
            if (rigid2D.velocity.x < -1.7 && running == true)
            {
                this.rigid2D.AddForce(new Vector3(100,0,0));
                running = false;
            }
            else if (rigid2D.velocity.x > 1.7 && running == true)
            {
                this.rigid2D.AddForce(new Vector3(-100, 0, 0));
                running = false;
            }
        }

        if (rigid2D.velocity.x == 0 && horizontal == 0)
        {
            stopping = true;
        }

        if (horizontal < 0.1 && horizontal > -0.1 && collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" && stopping == true)
        {
            if (rigid2D.velocity.x < -0.5 && stopping == true)
            {
                this.rigid2D.AddForce(new Vector3(-50, 0, 0));
                stopping = false;
            }
            else if (rigid2D.velocity.x > 0.5 && stopping == true)
            {
                this.rigid2D.AddForce(new Vector3(50, 0, 0));
                stopping = false;
            }
        }
    }
}
