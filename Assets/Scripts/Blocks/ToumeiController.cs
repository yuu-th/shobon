using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToumeiController : MonoBehaviour
{
    public BoxCollider2D hit_colider;
    GameObject player,player_head;
    //private Renderer renderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Renderer>().enabled = false;
        hit_colider = GetComponent<BoxCollider2D>();
        hit_colider.enabled = false;
    }

    void Update()
    {

    }

    public void hit()
    {
        GetComponent<Renderer>().enabled = true;
        hit_colider.enabled = true;
    }
}
