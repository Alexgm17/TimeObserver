using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public static bool isGrounded;


    private void onTriggerEnter(Collider2D collision)
    {
        isGrounded = true;
    }

    private void onTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
