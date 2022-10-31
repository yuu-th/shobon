using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class omake_controller : MonoBehaviour
{
    Animator animator;
    AudioSource audio_source;
    GameObject player;
    public GameObject gaster_normal;
    SpriteRenderer player_render;
    public AudioClip battle_start,attak_sound;
    Rigidbody2D player_rigid;
    void Start()
    {
        audio_source = this.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_render = player.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        player_rigid = player.GetComponent<Rigidbody2D>();

        audio_source.PlayOneShot(battle_start);
        StartCoroutine("attak");
    }

    void Update()
    {
   
    }

    public IEnumerator attak()
    {
        for(int i = 0; i <= 6; i++)
        {
            if (i < 3)
            {
                player_render.color = new Color(255, 255, 255, 0);
                yield return new WaitForSeconds(0.1f);
                player_render.color = new Color(255, 255, 255, 255);
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                player_render.color = new Color(255, 255, 255, 0);
                yield return new WaitForSeconds(0.05f);
                player_render.color = new Color(255, 255, 255, 255);
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return new WaitForSeconds(1f);
        audio_source.PlayOneShot(attak_sound);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(down_up_down(true));
        yield return new WaitForSeconds(0.5f);
        audio_source.PlayOneShot(attak_sound);
        animator.SetTrigger("down_to_right");
        yield return new WaitForSeconds(0.2f);
        Instantiate(gaster_normal, new Vector3(17, -3.5f, 0), Quaternion.identity);
    }

    public IEnumerator down_up_down(bool power)
    {
        animator.SetTrigger("down_to_up");
        if (power)
        {
            player_rigid.AddForce(new Vector2(0, 1000));
        }
        yield return new WaitForSeconds(0.4f);
        animator.SetTrigger("up_to_down");
        if (power)
        {
            player_rigid.AddForce(new Vector2(0, -1000));
        }
    }
}
