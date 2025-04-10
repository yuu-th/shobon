using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai4_contorller : MonoBehaviour
{
    GameObject player,shader;
    PlayerController player_controller;
    shader_controller shader_controller;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
        try
        {
            shader = GameObject.Find("shader_manager");
            shader_controller = shader.GetComponent<shader_controller>();
        }
        catch (System.NullReferenceException)
        {

        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ikinnnakasu");
            player_controller.get_mazai = true;
            player_controller.mazai1 = false;
            player_controller.mazai2 = false;
            try
            {
                shader_controller.mazai3 = false;
            }
            catch (System.NullReferenceException)
            {
            }
            GameObject.Destroy(gameObject);


        }
    }
}
