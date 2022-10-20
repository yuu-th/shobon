using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai4_contorller : MonoBehaviour
{
    GameObject player,shader;
    PlayerController player_controlelr;
    shader_controller shader_controller;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controlelr = player.GetComponent<PlayerController>();
        shader = GameObject.Find("shader_manager");
        shader_controller = shader.GetComponent<shader_controller>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_controlelr.mazai1 = false;
            player_controlelr.mazai2 = false;
            shader_controller.mazai3 = false;
            GameObject.Destroy(gameObject);
        }
    }
}
