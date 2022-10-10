using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teki0Controller : MonoBehaviour
{
    Rigidbody2D rigid2D;
    private float walkSpeed =-5.0f;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        

    }


    void FixedUpdate()
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

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.name == "Foot")
        {
            walkSpeed *= -1;
        }
    }
}


