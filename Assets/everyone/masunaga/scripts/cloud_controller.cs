using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_controller : MonoBehaviour
{
    public bool can_kill = false;
    SpriteRenderer renderer;
    public Sprite killed_img;
    GameObject player;
    PlayerController player_controller;
    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(can_kill == true && collision.gameObject.tag == "Player")
        {
            renderer.sprite = killed_img;
            player_controller.StartCoroutine("die");
        }
    }
}
