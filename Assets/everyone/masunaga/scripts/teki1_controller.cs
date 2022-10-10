using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki1_controller : MonoBehaviour
{
    Rigidbody2D rigid2D;
    SpriteRenderer renderer;
    public Sprite inside_img;
    private float walkSpeed = -5.0f,dif;
    private bool kicked = false;
    public bool inside = false;
    public BoxCollider2D head_2d,body_2d,side_2d;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.renderer = GetComponent<SpriteRenderer>();
        if(inside == true)
        {
            renderer.sprite = inside_img;
        }
    }


    void FixedUpdate()
    {
        if (inside == false)
        {
            float horizontal = rigid2D.velocity.x;

            Vector3 scale = gameObject.transform.localScale;
            if (horizontal > 0 && scale.x > 0 || horizontal < 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;

            var vec = new Vector2(walkSpeed, rigid2D.velocity.y);
            rigid2D.AddForce(3 * (vec - rigid2D.velocity));
        }
        else if(inside == true && kicked == true)
        {
            if(dif < 0)
            {
                this.transform.Translate(-0.1f,0,0);
            }
            else if(dif > 0)
            {
                this.transform.Translate(0.1f, 0, 0);
            }
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.name == "Foot")
        {
            if (inside == false)
            {
                inside = true;
                renderer.sprite = inside_img;
                head_2d.offset = new Vector2(0, 0.1f);
                body_2d.size = new Vector2(0.25f, 0.12f);
                side_2d.offset = new Vector2(0, -0.15f);
            }
            else if (inside == true && kicked == false)
            {
                kicked = true;
                dif = this.transform.position.x - colider.gameObject.transform.position.x;
            }
            else if (inside == true && kicked == true)
            {
                kicked = false;
            }
        }
        else if (colider.gameObject.tag != "Player")
        {
            walkSpeed *= -1;
            dif = dif * -1;
        }
    }
}
