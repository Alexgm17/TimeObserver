using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    public enum Player {Scientist, MaskDude, Frog, PinkMan, VirtualGuay};
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;


    void Start()
    {
        switch (playerSelected)
        {
            case Player.Scientist:
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;
            case Player.MaskDude:
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            case Player.Frog:
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;
            case Player.PinkMan:
                spriteRenderer.sprite = playersRenderer[3];
                animator.runtimeAnimatorController = playersController[3];
                break;
            case Player.VirtualGuay:
                spriteRenderer.sprite = playersRenderer[4];
                animator.runtimeAnimatorController = playersController[4];
                break;
            default:
                break;
        }
    }
}
