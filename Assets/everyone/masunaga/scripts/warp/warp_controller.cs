using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp_controller : MonoBehaviour
{
    GameObject warp_target,player;
    public GameObject warp_pair;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        warp_target = collider.gameObject.transform.parent.gameObject;
        StartCoroutine(cancel_warp());
        warp_target.transform.position = new Vector3(warp_pair.transform.position.x, warp_pair.transform.position.y,0);
    }

    IEnumerator cancel_warp()
    {
        CircleCollider2D warp_pair_collider = warp_pair.GetComponent<CircleCollider2D>();
        warp_pair_collider.enabled = false;
        yield return new WaitForSeconds(1.0f);
        warp_pair_collider.enabled = true;

    }
}
