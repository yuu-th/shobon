using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toumei_triger_controller : MonoBehaviour
{
    bool falling = false;
    GameObject invisibility_block,player;
    BoxCollider2D boxcollider;
    Rigidbody2D player_rigid;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        invisibility_block = transform.parent.gameObject;
        Debug.Log(invisibility_block.name);
        boxcollider = GetComponent<BoxCollider2D>();
        player_rigid = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Head" && player.transform.position.y < this.transform.position.y - 0.4 && falling == false && player_rigid.velocity.y > 0)
        {
            invisibility_block.GetComponent<ToumeiController>().hit();
            GameObject.Destroy(gameObject);

        }
    }
}