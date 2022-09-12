using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatenaController : MonoBehaviour
{
    GameObject childObj;

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
        if (inItem &&collider.gameObject.name == "Head")
        {
            isOpen = true;
            childObj.SetActive(true);
            Rigidbody2D rb = childObj.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }
    }
    
    
}

