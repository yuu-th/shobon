using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatenaController : MonoBehaviour
{
    GameObject childObj;

    GameObject player;

    public Sprite opened_sprite;
    private SpriteRenderer spriteRenderer;

    public AudioClip coin_sound;
    public AudioClip appear_sound;
    private AudioSource audioSource;

    bool inItem = false;

    bool isOpen = false;

    bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.childCount >0 )
        {
            inItem = true;
            childObj = gameObject.transform.GetChild(0).gameObject;
            /*
            Vector3 pos = childObj.transform.position;
            pos.x = 0;
            pos.y = 0;
            */
            childObj.transform.position = new Vector2(transform.position.x, transform.position.y+0.5f);
            childObj.SetActive(false);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inItem && isOpen && !finished)
        {
            if(childObj.transform.position ==new Vector3(transform.position.x, transform.position.y + 1.0f))
            {
                finished = true;
                Rigidbody2D rb = childObj.GetComponent<Rigidbody2D>();
                rb.isKinematic = false;
                Debug.Log("finish");
            }
            childObj.transform.position = Vector2.MoveTowards(childObj.transform.position, new Vector2(transform.position.x, transform.position.y + 1.0f), 0.05f);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isOpen)
        {
            return;
        }
        if (!inItem && collider.gameObject.name == "Head")
        {
            audioSource.PlayOneShot(coin_sound);
            isOpen = true;
            spriteRenderer.sprite = opened_sprite;
        }
        if (inItem &&collider.gameObject.name == "Head")
        {
            audioSource.PlayOneShot(appear_sound);
            isOpen = true;
            childObj.SetActive(true);
            Rigidbody2D rb = childObj.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            spriteRenderer.sprite = opened_sprite;
        }
    }
    
    
}

