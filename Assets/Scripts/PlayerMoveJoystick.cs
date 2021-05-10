using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;

    private float verticalMove = 0f;

    public Joystick joystick;

    public float runSpeedHorizontal = 2;

    public float runSpeed = 2;

    public float jumpSpeed = 4;

    Rigidbody2D rb2D;


    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public Transform checkGround;

    public float checkGroundRadio;

    public bool touchingFloor;

    public LayerMask floorChecker;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;

    }

    public void Update()
    {
        if ((horizontalMove>0) && EndLevel.playerEndLevel == false)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if ((horizontalMove < 0) && EndLevel.playerEndLevel == false)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        touchingFloor = Physics2D.OverlapCircle(checkGround.position, checkGroundRadio, floorChecker);
    }

    public void Jump()
    {
        if (touchingFloor == true && EndLevel.playerEndLevel == false)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            animator.SetBool("Jump", false);
        }

        if (touchingFloor == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
    }
}
