using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public Animator animator;

    public float jumpForce = 5f;

    public AudioSource clipJump;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            clipJump.Play();
            animator.Play("JumpTrampoline");
        }
    }

}
