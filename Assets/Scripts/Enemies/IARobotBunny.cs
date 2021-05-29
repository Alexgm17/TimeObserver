using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARobotBunny : MonoBehaviour
{

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    public float jumpSpeed = 2;

    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime = 2;

    private int i = 0;

    private Vector2 actualPosition;

    public AudioSource clipJump;

    Rigidbody2D rb2D;

    public bool canJump = false;


    void Start()
    {
        waitTime = startWaitTime;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.1f)
        {
            if (waitTime<=0)
            {
                if(moveSpots[i]!=moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
                Jump();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void Jump()
    {
        if (canJump==true)
        {
            clipJump.Play();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        /*if (rb2D.velocity.y < 0 )
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.velocity.y >= 0)
        {
            animator.SetBool("Falling", false);
        }*/
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPosition = transform.position;

        yield return new WaitForSeconds(0.5f);


        if (transform.position.x>actualPosition.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x<actualPosition.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }        
        else if (transform.position.x==actualPosition.x)
        {
            animator.SetBool("Idle", true);
        }
    }
}
