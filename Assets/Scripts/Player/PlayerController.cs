using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField] private Animator animator;

    public static string stage_name;


    private float jumpForce = 800.0f;
    //float moveForce = 20.0f;
    //float maxSpeed = 2.0f;
    private float idoumaxspeed = 7.3f;
    private bool jump_Jud = false; //�W�����v�񐔂̐����̂���

    private float stepOnRate;

    private int jumpAfterFrame = 0;

    private bool dead = false;


    private float beforeChangeRunStateX;
    private int runState = 1;

    private bool isGoalFalling = false;
    private bool isGoalWalking = false;
    private float goalSpeed = 4.0f;


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        beforeChangeRunStateX = rigid2D.position.x;
        stage_name = SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && !jump_Jud && dead == false)
        {
            if (rigid2D.velocity.x > 1.0f)
            {
                this.rigid2D.AddForce(transform.up * jumpForce + new Vector3(0, 80.0f));
            }
            else {
                this.rigid2D.AddForce(transform.up * jumpForce );
            }
            jump_Jud = true;
            jumpAfterFrame = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && jump_Jud && jumpAfterFrame <= 6 && dead == false)
        {
            float tmp = -140.0f;
            if (rigid2D.velocity.x > 1.0f)
            {
                tmp -= 70.0f;
            }
            var vec = new Vector2(0f, tmp);
            rigid2D.AddForce(vec);
        }


        animator.SetInteger("runState", runState);
        animator.SetBool("isJumping", jump_Jud);

    }
    void FixedUpdate()
    {
        jumpAfterFrame++;
        //rigid2D.velocity = new Vector2(rigid2D.velocity.x + 0.1f*Input.GetAxis("Horizontal"), rigid2D.velocity.y);

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0 && dead == false)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;


        if (isGoalFalling)
        {
            rigid2D.velocity = new Vector2(0.0f, -goalSpeed);
            return;

        } else if (isGoalWalking)
        {
            rigid2D.velocity = new Vector2(goalSpeed, rigid2D.velocity.y);
        }



        //�ړ�
        float x = Input.GetAxis("Horizontal");
        x = x * idoumaxspeed;
        var vec = new Vector2(x, rigid2D.velocity.y);
        if (dead == false)
        {
            rigid2D.AddForce(3 * (vec - rigid2D.velocity));
        }


        if (Math.Abs(beforeChangeRunStateX - rigid2D.position.x) > 0.75f)
        {
            beforeChangeRunStateX = rigid2D.position.x;
            runState++;
            if (runState == 3)
            {
                runState = 1;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" || collider.gameObject.tag == "pipe" || collider.gameObject.tag == "spring")
        {

            if (isGoalFalling)
            {
                isGoalFalling = false;
                isGoalWalking = true;
            }

            //�W�����v�����̉���
            this.jump_Jud = false;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        }
        if (collider.gameObject.tag == "KillAbleEnemy")
        {
            if (collider.gameObject.name == "Head")
            {
                if (jumpAfterFrame < 3)
                {
                    return;
                }
                rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
                if (rigid2D.velocity.x > 1.0f)
                {
                    this.rigid2D.AddForce(transform.up * jumpForce + new Vector3(0, 80.0f));
                }
                else
                {
                    this.rigid2D.AddForce(transform.up * jumpForce);
                }
                jump_Jud = true;
                jumpAfterFrame = 0;

                if (collider.gameObject.transform.parent.name == "teki1")
                {
                    return;
                }
                else
                {
                    collider.gameObject.transform.parent.gameObject.SetActive(false);//敵殺す
                }
            } else if (collider.gameObject.name == "Body")
            {
                StartCoroutine(die());
                Debug.Log("uho");
            }
        }

        if (collider.gameObject.tag == "Goal" && !isGoalFalling && !isGoalWalking)
        {
            isGoalFalling = true;
        }
        if (isGoalWalking && collider.gameObject.tag == "GoalToride")
        {
            gameObject.SetActive(false);
        }


    }
    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" || collider.gameObject.tag == "pipe" || collider.gameObject.tag == "spring")
        {

            Invoke("make_jump_Jud_on", 0.1f);
            //this.jump_Jud = true;
        }
    }
    IEnumerator WaitFor1Frame()
    {
        yield return new WaitForSeconds(0.1f);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" || collider.gameObject.tag == "pipe" || collider.gameObject.tag == "spring")
        {
            StartCoroutine("WaitFor1Frame");
            CancelInvoke("make_jump_Jud_on");
        }
    }


    void make_jump_Jud_on()
    {
        this.jump_Jud = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "KillAbleEnemy")
        {
            jumpAfterFrame = 0;
            StartCoroutine(die());
            Debug.Log("uho");
        }
    }

    public IEnumerator die()
    {
        GameObject head, foot;
        BoxCollider2D head_collider,foot_collider,player_collider;
        SpriteRenderer render;

        head = this.transform.GetChild(0).gameObject;
        foot = this.transform.GetChild(1).gameObject;
        head_collider = head.GetComponent<BoxCollider2D>();
        foot_collider = foot.GetComponent<BoxCollider2D>();
        player_collider = this.GetComponent<BoxCollider2D>();
        render = this.GetComponent<SpriteRenderer>();

        dead = true;
        animator.SetBool("isDead", true);
        rigid2D.velocity = new Vector2(0, 0);

        head_collider.enabled = false;
        foot_collider.enabled = false;
        player_collider.enabled = false;
        render.sortingOrder = 2;

        rigid2D.AddForce(new Vector2(0, 800-rigid2D.velocity.y));
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        SceneManager.LoadScene("dead_scene");
    }
}