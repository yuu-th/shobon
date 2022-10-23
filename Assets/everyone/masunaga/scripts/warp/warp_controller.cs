using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp_controller : MonoBehaviour
{
    GameObject warp_target;
    public GameObject warp_pair;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        try {
            warp_target = collider.gameObject.transform.parent.gameObject;
            if (warp_target.tag == "Untagged")
            {
                return;
            }
            Debug.Log(warp_pair.transform.position);
            StartCoroutine(cancel_warp());
            warp_target.transform.position = new Vector3(warp_pair.transform.position.x, warp_pair.transform.position.y, 0);
        }
        catch (System.NullReferenceException)
        {
            
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        warp_target = collision.gameObject.transform.parent.gameObject;
        Debug.Log(collision.gameObject.transform.parent.gameObject.name);
        StartCoroutine(cancel_warp());
        warp_target.transform.position = new Vector3(warp_pair.transform.position.x, warp_pair.transform.position.y, 0);
    }*/

    IEnumerator cancel_warp()
    {
        if (warp_pair.gameObject.tag == "trap")
        {
            CircleCollider2D warp_pair_collider = warp_pair.GetComponent<CircleCollider2D>();
            warp_pair_collider.enabled = false;
            yield return new WaitForSeconds(1.0f);
            warp_pair_collider.enabled = true;
        }

    }
}
