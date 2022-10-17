using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_entrance_controller : MonoBehaviour
{
    float horizontal, vertical;
    public bool can_warp = false;
    public GameObject pair_pipe;
    GameObject player,player_head,player_foot,pair_pipe_entrance,pair_pipe_entrance_trigger_,parernt_pipe;
    BoxCollider2D player_collider,player_foot_collider,player_head_collider,pair_pipe_trigger_collider;
    Rigidbody2D player_rigid;
    void Start()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player_collider = player.GetComponent<BoxCollider2D>();
            player_head = player.transform.GetChild(0).gameObject;
            player_foot = player.transform.GetChild(1).gameObject;
            player_rigid = player.GetComponent<Rigidbody2D>();
            player_foot_collider = player_foot.GetComponent<BoxCollider2D>();
            player_head_collider = player_head.GetComponent<BoxCollider2D>();
            pair_pipe_entrance = pair_pipe.transform.GetChild(0).gameObject;
            pair_pipe_entrance_trigger_ = pair_pipe_entrance.transform.GetChild(0).gameObject;
            pair_pipe_trigger_collider = pair_pipe_entrance_trigger_.GetComponent<BoxCollider2D>();
            parernt_pipe = this.transform.parent.gameObject;
        }
        catch (UnassignedReferenceException)
        {

        }
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    IEnumerator into_pipe()
    {
        switch (parernt_pipe.transform.localEulerAngles.z)
        {
            case 0:
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(0, -0.1f, 0);
                }
                yield return new WaitForSeconds(1.0f);
                player.transform.position = new Vector3(pair_pipe_entrance.transform.position.x, pair_pipe_entrance.transform.position.y, 0);
                break;

            case 90:
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(0.1f,0, 0);
                }
                yield return new WaitForSeconds(1.0f);
                player.transform.position = new Vector3(pair_pipe_entrance.transform.position.x, pair_pipe_entrance.transform.position.y, 0);
                break;

            case 180:
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(0, 0.1f, 0);
                }
                yield return new WaitForSeconds(1.0f);
                player.transform.position = new Vector3(pair_pipe_entrance.transform.position.x, pair_pipe_entrance.transform.position.y, 0);
                break;

            case 270:
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(-0.1f, 0, 0);
                }
                yield return new WaitForSeconds(1.0f);
                player.transform.position = new Vector3(pair_pipe_entrance.transform.position.x, pair_pipe_entrance.transform.position.y, 0);
                break;

        }
    }

    IEnumerator out_pipe()
    {
        switch (pair_pipe.transform.localEulerAngles.z)
        {
            case 0:
                yield return new WaitForSeconds(2.0f);
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(0, 0.1f, 0);
                }
                break;

            case 90:
                yield return new WaitForSeconds(2.0f);
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(-0.1f,0, 0);
                }
                break;

            case 180:
                yield return new WaitForSeconds(2.0f);
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(0, -0.1f, 0);
                }
                break;

            case 270:
                yield return new WaitForSeconds(2.0f);
                for (int i = 0; i <= 15; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    player.transform.Translate(0.1f,0, 0);
                }
                break;
        }
        
        player_foot_collider.enabled = true;
        player_head_collider.enabled = true;
        player_collider.enabled = true;
        player_rigid.isKinematic = false;
    }

    IEnumerator cancel_warp()
    {
        pair_pipe_trigger_collider.enabled = false;
        yield return new WaitForSeconds(1.5f + 2.0f);
        pair_pipe_trigger_collider.enabled = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        switch (parernt_pipe.transform.localEulerAngles.z)
        {
            case 0:
                if (can_warp == true && vertical < 0)
                {
                    player_foot_collider.enabled = false;
                    player_head_collider.enabled = false;
                    player_collider.enabled = false;
                    player_rigid.isKinematic = true;
                    player_rigid.velocity = new Vector3(0, 0, 0);
                    player.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, 0);

                    StartCoroutine(into_pipe());

                    StartCoroutine(cancel_warp());

                    StartCoroutine(out_pipe());

                }
                break;

            case 90:
                if (can_warp == true && horizontal > 0)
                {
                    player_foot_collider.enabled = false;
                    player_head_collider.enabled = false;
                    player_collider.enabled = false;
                    player_rigid.isKinematic = true;
                    player_rigid.velocity = new Vector3(0, 0, 0);
                    player.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, 0);

                    StartCoroutine(into_pipe());

                    StartCoroutine(cancel_warp());

                    StartCoroutine(out_pipe());

                }
                break;

            case 180:
                if (can_warp == true && vertical > 0)
                {
                    player_foot_collider.enabled = false;
                    player_head_collider.enabled = false;
                    player_collider.enabled = false;
                    player_rigid.isKinematic = true;
                    player_rigid.velocity = new Vector3(0, 0, 0);
                    player.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, 0);

                    StartCoroutine(into_pipe());

                    StartCoroutine(cancel_warp());

                    StartCoroutine(out_pipe());

                }
                break;

            case 270:
                if (can_warp == true && horizontal < 0)
                {
                    player_foot_collider.enabled = false;
                    player_head_collider.enabled = false;
                    player_collider.enabled = false;
                    player_rigid.isKinematic = true;
                    player_rigid.velocity = new Vector3(0, 0, 0);
                    player.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, 0);

                    StartCoroutine(into_pipe());

                    StartCoroutine(cancel_warp());

                    StartCoroutine(out_pipe());

                }
                break;

        }
    }
}
