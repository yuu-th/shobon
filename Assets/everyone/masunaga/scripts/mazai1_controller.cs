using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai1_controller : MonoBehaviour
{
    GameObject player;
    PlayerController player_controller;
    public float mazai_speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_controller.get_mazai = true;
            player_controller.mazai_speed = mazai_speed;
            player_controller.mazai1 = true;
            GameObject.Destroy(gameObject);
        }
    }
}
