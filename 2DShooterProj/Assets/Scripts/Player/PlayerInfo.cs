using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private int lifes = 3;

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

        initialLives = lifes;
        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameManager.instance.SetPlayerLife(lifes);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LifeHandler();
        }
    }

    void LifeHandler()
    {
        isHurt = true;
        lifes--;
        GameManager.instance.SetPlayerLife(lifes);
        if (lifes <= 0)
        {
            playerTransform.position = new Vector3(0, 0, 0);
            lifes = initialLives;
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
        isHurt = hurt;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
