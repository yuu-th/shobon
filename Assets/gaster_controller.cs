using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gaster_controller : MonoBehaviour
{
    AudioSource audio_source;
    public AudioClip shoot_sound;
    GameObject beam;
    SpriteRenderer beam_renderer;
    BoxCollider2D beam_collider;
    Animator animator;
    void Start()
    {
        audio_source = this.GetComponent<AudioSource>();
        beam = this.transform.GetChild(0).gameObject;
        beam_renderer = beam.GetComponent<SpriteRenderer>();
        beam_collider = beam.GetComponent<BoxCollider2D>();
        beam_renderer.color = new Color(255, 255, 255, 0);
        beam_collider.enabled = false;
        animator = this.GetComponent<Animator>(); 

        StartCoroutine(shoot());
        audio_source.PlayOneShot(shoot_sound);
    }

    void Update()
    {
        
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.65f);
        beam_collider.enabled = true;
        
        yield return null;
        beam.transform.localScale = new Vector3(20, 0.2f, beam.transform.localScale.z);
        beam_renderer.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        Destroy(beam);
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
