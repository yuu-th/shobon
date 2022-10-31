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
    void Start()
    {
        audio_source = this.GetComponent<AudioSource>();
        beam = this.transform.GetChild(0).gameObject;
        beam_renderer = beam.GetComponent<SpriteRenderer>();
        beam_collider = beam.GetComponent<BoxCollider2D>();
        beam_renderer.color = new Color(255, 255, 255, 0);
        beam_collider.enabled = false;

        StartCoroutine(move());
        audio_source.PlayOneShot(shoot_sound);
    }

    void Update()
    {
        
    }

    IEnumerator move()
    {
        for (int i = 0; i <= 20; i++)//‡Œv13
        {
            if (i <= 15)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.Translate(-0.35f, 0, 0);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
                this.transform.Translate(-0.1f, 0, 0);
            }
        }
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(shoot());
        
        for (int i = 0;i <= 50; i++)
        {
            yield return null;
            this.transform.Translate(0.45f, 0, 0);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(beam);
    }

    IEnumerator shoot()
    {
        beam_collider.enabled = true;
        for (int i = 0; i <= 360; i++)
        {
            yield return new WaitForSeconds(0.05f);
            double sin = Math.Sin(i * (Math.PI / 180));
            beam.transform.localScale = new Vector3(20, 0.2f, beam.transform.localScale.z);
            beam_renderer.color = new Color(255, 255, 255, 255 - (float)(50*sin));
        }
    }
}
