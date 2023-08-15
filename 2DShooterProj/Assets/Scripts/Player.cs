using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;
    public Transform playerTransform;
    private int lives = 3;

    public static Player instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();

        if(lives <= 0)
        {
            playerTransform.position = new Vector3(0, 0, 0);
            lives = 3;
            //Destroy(gameObject);
        }
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        playerTransform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
        print(lives);
    }
}
