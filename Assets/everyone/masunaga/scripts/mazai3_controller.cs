using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai3_controller : MonoBehaviour
{
    GameObject shader;
    shader_controller shader_controller;

    void Start()
    {
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
            shader_controller.shader_on();
            GameObject.Destroy(gameObject);
        }
    }
}
