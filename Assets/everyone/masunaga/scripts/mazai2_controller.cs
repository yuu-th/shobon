using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai2_controller : MonoBehaviour
{
    GameObject player;
    PlayerController player_controller;
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
            player_controller.mazai2 = true;
            GameObject.Destroy(gameObject);
        }
    }
}
