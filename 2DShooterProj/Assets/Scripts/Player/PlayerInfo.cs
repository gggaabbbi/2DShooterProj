using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private int lives = 3;

    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;
    private int initialLives;
    private bool isHurt;
    public bool isMoving;

     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialLives = lives;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        LifeHandler();
    }

    void LifeHandler()
    {
        isHurt = true;
        lives--;
        if (lives <= 0)
        {
            playerTransform.position = new Vector3(0, 0, 0);
            lives = initialLives;
            //Destroy(gameObject);
        }
    }

    public Vector2 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public bool CheckPlayerMove()
    {
        return isMoving;
    }

    public bool CheckPlayerHurt()
    {
        return isHurt;
    }

    public void SetPlayerHurt(bool hurt)
    {
        isHurt= hurt;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
