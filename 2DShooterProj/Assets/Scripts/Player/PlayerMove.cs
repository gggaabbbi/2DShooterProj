using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed;
    private float normalSpeed;
    [SerializeField] private GameObject dash;
    private bool canDash = true;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        normalSpeed = PlayerInfo.instance.GetPlayerSpeed();
        spriteRenderer = PlayerInfo.instance.GetSpriteRenderer();
        speed = normalSpeed;
    }

    void Update()
    {
        MoveHandler();
        DashHandler();
    }

    void DashHandler()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;
        FlipSprite(moveX);

    }

    void FlipSprite(float moveX)
    {
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    IEnumerator Dash()
    {
        speed = 2 * normalSpeed;
        dash.gameObject.SetActive(true);
        canDash = false;
        yield return new WaitForSeconds(.2f);
        speed = normalSpeed;
        dash.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        canDash = true;
    }
}
