using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    private Animator animator;
    private bool isHurt;
 

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationHandler();
    }

    void AnimationHandler()
    {
        bool isMovingAnim = animator.GetBool("isMoving");
        bool isHurtAnim = animator.GetBool("isHurt");
        bool isMoving = PlayerInfo.instance.isMoving;
        bool isHurt = PlayerInfo.instance.CheckPlayerHurt();

        if (isMoving && isMovingAnim == false)
        {
            animator.SetBool("isMoving", true);
        }
        else if (!isMoving && isMovingAnim == true)
        {
            animator.SetBool("isMoving", false);
        }

        if (isHurt && isHurtAnim == false)
        {
            animator.SetBool("isHurt", true);
            PlayerInfo.instance.SetPlayerHurt(false);
        }
        else if (!isHurt && isHurtAnim == true)
        {
            animator.SetBool("isHurt", false);
        }
    }
}
