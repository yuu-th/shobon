using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class omake_controller : MonoBehaviour
{
    Animator animator;
    AudioSource audio_source;
    GameObject player;
    public GameObject gaster_right,gaster_left,gaster_up,gaster_down;
    SpriteRenderer player_render;
    public AudioClip battle_start,attak_sound,win;
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
        Instantiate(gaster_right, new Vector3(17, -4f, 0), Quaternion.identity);
        Instantiate(gaster_left, new Vector3(-17, -4f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(down_up_down(false));
        yield return new WaitForSeconds(0.5f);
        audio_source.PlayOneShot(attak_sound);
        Instantiate(gaster_up, new Vector3(2.1f, 17, 0), Quaternion.Euler(0,0,90));
        Instantiate(gaster_up, new Vector3(-2.1f, 17, 0), Quaternion.Euler(0, 0, 90));
        animator.SetTrigger("right_to_down");
        audio_source.PlayOneShot(attak_sound);
        yield return new WaitForSeconds(1f);
        for (int i = 0;i <= 3; i++)
        {
            if(i % 2 == 0)
            {
                audio_source.PlayOneShot(attak_sound);
                Instantiate(gaster_right, new Vector3(17, -5.5f+(1f*i), 0), Quaternion.identity);
                yield return new WaitForSeconds(1.2f);
            }
            else
            {
                audio_source.PlayOneShot(attak_sound);
                Instantiate(gaster_left, new Vector3(-17, -5.5f+(1f*i), 0), Quaternion.identity);
                yield return new WaitForSeconds(1.2f);
            }
        }
        audio_source.PlayOneShot(attak_sound);
        Instantiate(gaster_right, new Vector3(17, -4f, 0), Quaternion.identity);
        Instantiate(gaster_right, new Vector3(17, 1f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        for(int i = 0;i <= 3;i++)
        {
            Instantiate(gaster_right, new Vector3(17, -4+(i*0.2f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        Instantiate(gaster_up, new Vector3(0.5f, 17, 0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(1.5f);
        audio_source.PlayOneShot(attak_sound);
        animator.SetTrigger("down_to_right");
        player_rigid.AddForce(new Vector2(10000, 0));
        yield return new WaitForSeconds(0.8f);
        for (int i = 0;i <= 9; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(gaster_up, new Vector3(2.5f-0.5f*i, 17, 0), Quaternion.Euler(0, 0, 90));
        }
        yield return new WaitForSeconds(1.4f);
        animator.SetTrigger("right_to_up");
        audio_source.PlayOneShot(attak_sound);
        for (int i = 0; i <= 9; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(gaster_up, new Vector3(-3f + 0.5f * i, 17, 0), Quaternion.Euler(0, 0, 90));
        }
        yield return new WaitForSeconds(0.5f);
        Instantiate(gaster_left, new Vector3(-17, -4f, 0), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        audio_source.PlayOneShot(win);
        yield return new WaitForSeconds(3f);
        for (int i = 0; i <= 3; i++)
        {
            Instantiate(gaster_left, new Vector3(-17, -4 + (i * 0.2f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("seima_unko2");

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
