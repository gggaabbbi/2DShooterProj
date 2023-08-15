using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private int lives = 3;
    private int initialLives;

    private Animator animator;
    public Transform playerTransform;

    private bool isMoving;
    private bool isHurt;
    public static Player instance;

    void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion

        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        initialLives = lives;
    }

    void Update()
    {
        MoveHandler();
        LifeHandler();
        AnimationHandler();
    }


    #region Handlers
    void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        playerTransform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);

        isMoving = moveX != 0 || moveY != 0;

        //if(moveX != 0 || moveY != 0)
        //{
        //    isMoving = true;    
        //}
        //else
        //{
        //    isMoving = false;
        //}
    }

    void LifeHandler()
    {
        if (lives <= 0)
        {
            playerTransform.position = new Vector3(0, 0, 0);
            lives = initialLives;
            //Destroy(gameObject);
        }
    }

    void AnimationHandler()
    {
        bool isMovingAnim = animator.GetBool("isMoving");
        bool isHurtAnim = animator.GetBool("isHurt");

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
            isHurt = false;
        }
        else if (!isHurt && isHurtAnim == true)
        {
            animator.SetBool("isHurt", false);
        }
    }

    #endregion

    void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
        isHurt = true;
        print(lives);
    }
}
