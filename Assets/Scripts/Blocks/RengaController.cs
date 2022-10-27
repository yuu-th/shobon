using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RengaController : MonoBehaviour
{
    public AudioClip broken_sound;
    private AudioSource audioSource;

    public Vector2 start_pos, end_pos;
    public bool can_kill = false, Downward = false;
    bool entered = false;
    public float speed;
    GameObject player;
    PlayerController player_controller;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
        audioSource = player.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if ((start_pos.x >= player.gameObject.transform.position.x) && (player.gameObject.transform.position.x >= end_pos.x) && (start_pos.y >= player.gameObject.transform.position.y) && (player.gameObject.transform.position.y >= end_pos.y))
        {
            entered = true;
        }
        if (entered == true && Downward == false)
        {
            this.transform.Translate(0, speed, 0);
        }
        else if (entered == true && Downward == true)
        {
            this.transform.Translate(0, -speed, 0);
        }
        if (this.transform.position.y > 100 || this.transform.position.y < -100)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Head" && can_kill == false)
        {
            audioSource.PlayOneShot(broken_sound);
            Destroy(gameObject,0.05f);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (collision.gameObject.tag == "Player" && can_kill == true)
            {
                Debug.Log("ok");
                player_controller.StartCoroutine("die");
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
