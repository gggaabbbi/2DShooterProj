using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = PlayerInfo.instance.GetPlayerSpeed();
    }

    void Update()
    {
        MoveHandler();
    }

    void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;
    }
}
