using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_checker_controller : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("death_checkr"+collision.gameObject.tag);

        if (collision.transform.parent.gameObject.tag == "Player")
        {
            player_controller.StartCoroutine("die");
        }
        else if (collision.gameObject.name !="Player")
        {
            Debug.Log("death_checkr_" + collision.gameObject.name);
            GameObject.Destroy(collision.transform.parent.gameObject);
        }
    }
}
