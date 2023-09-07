using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health = 20;

    private Transform enemyTransform;
    private Vector2 targetPosition;

    void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }

    void Update()
    {
        MovementHandler();
        HealthHandler();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
    }

    void MovementHandler()
    {
        targetPosition = PlayerInfo.instance.GetPlayerPosition();
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, speed * Time.deltaTime);
    }

    private void HealthHandler()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.SetGameScore(5);
        }
    }
}
