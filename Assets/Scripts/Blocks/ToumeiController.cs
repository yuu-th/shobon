using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToumeiController : MonoBehaviour
{

    //private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
