using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaster_trigger_controller : MonoBehaviour
{
    public GameObject gaster;
    public Vector2 pos;
    public bool up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (up)
            {
                Instantiate(gaster, pos, Quaternion.Euler(0,0,90));
                Destroy(gameObject);
            }
            else
            {
                Instantiate(gaster, pos, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
