using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazai_conter_controller : MonoBehaviour
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
        switch (player_controller.mazai_counter)
        {
            case 0:
                this.GetComponent<Text>().text = "魔剤カウンター　　<color=#FFFFFF>" + player_controller.mazai_counter + "</color>";
                break;
            case 1:
                this.GetComponent<Text>().text = "魔剤カウンター　　<color=#0000FF>" + player_controller.mazai_counter + "</color>";
                break;
            case 2:
                this.GetComponent<Text>().text = "魔剤カウンター　　<color=#00FF00>" + player_controller.mazai_counter + "</color>";
                break;
            case 3:
                this.GetComponent<Text>().text = "魔剤カウンター　　<color=#FFFF00>" + player_controller.mazai_counter + "</color>";
                break;
            case 4:
                this.GetComponent<Text>().text = "魔剤カウンター　　<color=#FF0000>" + player_controller.mazai_counter + "</color>";
                break;
        }
    }
}
