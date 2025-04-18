using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{

    private bool stage_finished =false;


    private PostProcessVolume postProcessVolume;

    GameObject cameara_object;
    Camera camera_render;

    Rigidbody2D rigid2D;
    [SerializeField] private Animator animator;
    

    public AudioClip death_sound;
    public AudioClip jump_sound;
    public AudioClip mazai_sound;
    public AudioClip humi_sound;
    public AudioClip goal_sound;

    private AudioSource audioSource;

    private Renderer objectRenderer;


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

    [HideInInspector] public  bool mazai1 = false;
    [HideInInspector] public bool mazai2 = false;
    [HideInInspector] public float mazai_speed;
    [HideInInspector] public bool get_mazai = false;
    public int mazai_counter = 0;
    float get_time = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        beforeChangeRunStateX = rigid2D.position.x;
        stage_name = SceneManager.GetActiveScene().name;
        cameara_object = GameObject.Find("Main Camera");
        camera_render = cameara_object.GetComponent<Camera>();

        this.objectRenderer = gameObject.GetComponent<Renderer>();
    }


    void Update()
    {
        if (stage_finished){
            return;
        }
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("STAGE_SELECTOR");
         }
        if(mazai_counter >= 5)//カフェイン中毒
        {
            mazai_counter = 0;
            dead = true;
            StartCoroutine(die());
        }
        float now_time = 0;
        now_time = Time.time;
        if (get_mazai == true)
        {
            Debug.Log("mazai");
            audioSource.PlayOneShot(this.mazai_sound);
            get_time = Time.time;
            mazai_counter += 1;
            get_mazai = false;
        }
        if ((now_time - get_time) >= 15)
        {
            mazai_counter = 0;
        }
        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && !jump_Jud && dead == false)
        {
            audioSource.PlayOneShot(jump_sound);
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
            audioSource.PlayOneShot(jump_sound);
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
        animator.SetInteger("mazai_counter",mazai_counter);

    }
    void FixedUpdate()
    {
        if (stage_finished)
        {
            return;
        }
        jumpAfterFrame++;

        if (isGoalFalling)
        {
            rigid2D.velocity = new Vector2(0.0f, -goalSpeed);
            return;

        }
        else if (isGoalWalking)
        {
            rigid2D.velocity = new Vector2(goalSpeed, rigid2D.velocity.y);
            return;
        }


        float horizontal = Input.GetAxis("Horizontal");

        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0 && dead == false)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;

        


        //�ړ�
        float x = Input.GetAxis("Horizontal");
        if (mazai1 == true)
        {
            x = x * idoumaxspeed * mazai_speed;
        }
        else
        {
            x = x * idoumaxspeed;
        }
        if (mazai2 == true)
        {
            x = x * -1;
        }
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
            //this.jump_Jud = false;
            //rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
        }
        if (collider.gameObject.tag == "KillAbleEnemy")
        {
            if (collider.gameObject.name == "Head")
            {
                if (jumpAfterFrame < 3)
                {
                    return;
                }
                audioSource.PlayOneShot(this.humi_sound);
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
            audioSource.Stop();
            audioSource.PlayOneShot(this.goal_sound);
        }
        if (isGoalWalking && collider.gameObject.tag == "GoalToride")
        {
            isGoalWalking = false;
            rigid2D.velocity= new Vector2(0,0);
            stage_finished = true;
            StartCoroutine(stage_clear());
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" || collider.gameObject.tag == "pipe" || collider.gameObject.tag == "spring")
        {

            if (isGoalFalling)
            {
                isGoalFalling = false;
                isGoalWalking = true;
            }

            this.jump_Jud = false;
        }

        if (collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" || collider.gameObject.tag == "pipe" || collider.gameObject.tag == "spring")
        {
            StartCoroutine("WaitFor1Frame");
            CancelInvoke("make_jump_Jud_on");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "Tilemap" || collider.gameObject.tag == "Block" || collider.gameObject.tag == "pipe" || collider.gameObject.tag == "spring")
        {
            this.jump_Jud = true;
        }
    }
    IEnumerator WaitFor1Frame()
    {
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
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

    public IEnumerator stage_clear()
    {
        this.objectRenderer.enabled = false;
        //gameObject.SetActive(true);
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene("STAGE_SELECTOR");
    }

    public IEnumerator die()
    {
        GameObject head, foot;
        BoxCollider2D head_collider,foot_collider,player_collider;
        SpriteRenderer render;

        audioSource.Stop();

        audioSource.PlayOneShot(death_sound);

        dead = true;
        head = this.transform.GetChild(0).gameObject;
        foot = this.transform.GetChild(1).gameObject;
        head_collider = head.GetComponent<BoxCollider2D>();
        foot_collider = foot.GetComponent<BoxCollider2D>();
        player_collider = this.GetComponent<BoxCollider2D>();
        render = this.GetComponent<SpriteRenderer>();

        dead = true;
        animator.SetBool("isDead", true);
        rigid2D.velocity = new Vector2(0, 0);

        yield return new WaitForSeconds(0.5f);

        head_collider.enabled = false;
        foot_collider.enabled = false;
        player_collider.enabled = false;
        render.sortingOrder = 2;
        rigid2D.AddForce(new Vector2(0, 800-rigid2D.velocity.y));
        yield return new WaitForSeconds(3.4f);
        gameObject.SetActive(false);
        SceneManager.LoadScene("dead_scene");
    }
}