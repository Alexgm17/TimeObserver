using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed=2;

    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplayer = 0.5f;

    public float lowJumpMultiplayer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public Transform checkGround;

    public float checkGroundRadio;

    public GameObject dustLeft;

    public GameObject dustRight;

    public bool touchingFloor;

    public LayerMask floorChecker;

    public AudioSource clipJump;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space") && touchingFloor == true && EndLevel.playerEndLevel == false && PlayerRespawn.playerDead == false)
        {
            clipJump.Play();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        touchingFloor = Physics2D.OverlapCircle(checkGround.position, checkGroundRadio, floorChecker);

        if (touchingFloor == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (touchingFloor == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
        }

        if (rb2D.velocity.y < 0 && touchingFloor == false)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.velocity.y >= 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        if ((Input.GetKey("d") || Input.GetKey("right")) && EndLevel.playerEndLevel==false && PlayerRespawn.playerDead == false)
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

            if (touchingFloor == true) 
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
            else
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(false);
            }
        }
        else if ((Input.GetKey("a") || Input.GetKey("left")) && EndLevel.playerEndLevel==false && PlayerRespawn.playerDead == false)
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

            if (touchingFloor == true)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
            else
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(false);
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);

            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }


        if (betterJump)
        {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;
            }
            if (rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }
    }
}
