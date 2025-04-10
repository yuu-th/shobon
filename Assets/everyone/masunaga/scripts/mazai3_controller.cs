using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai3_controller : MonoBehaviour
{
    GameObject shader,player;
    shader_controller shader_controller;
    PlayerController player_controller;

    void Start()
    {
        shader = GameObject.Find("shader_manager");
        shader_controller = shader.GetComponent<shader_controller>();
        player = GameObject.FindWithTag("Player");
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
            shader_controller.mazai3 = true;
            GameObject.Destroy(gameObject);
        }
    }
}
