using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    GameObject player;
    PlayerController player_controller;
    public Vector2 start_pos, end_pos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((start_pos.x >= player.gameObject.transform.position.x) && (player.gameObject.transform.position.x >= end_pos.x) && (start_pos.y >= player.gameObject.transform.position.y) && (player.gameObject.transform.position.y >= end_pos.y))
        {
            SceneManager.LoadScene("seima_minigame");
        }
    }
}
