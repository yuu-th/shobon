using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazai2_controller : MonoBehaviour
{
    GameObject player;
    PlayerController player_controlelr;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controlelr = player.GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_controlelr.mazai2 = true;
            GameObject.Destroy(gameObject);
        }
    }
}
