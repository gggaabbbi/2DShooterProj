using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;
    private Transform playerTransform;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        playerTransform.Translate(moveX, moveY, 0);
    }
    
}
