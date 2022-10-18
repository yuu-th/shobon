using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_controller : MonoBehaviour
{
    GameObject player;
    Rigidbody2D player_rigid;
    PlayerController player_controller;
    public bool can_kill = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
        player_rigid = player.GetComponent<Rigidbody2D>();
        Debug.Log(player_rigid.name);
    }

    void Update()
    {
        if (player.transform.position.y >= 200)
        {
            player_controller.die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(can_kill == true && collision.gameObject.tag == "Player")
        {
            player_rigid.AddForce(new Vector2(0, 10000));
        }
        else if(can_kill == false && collision.gameObject.tag == "Player")
        {
            player_rigid.AddForce(new Vector2(0, 1000));
        }
    }
}