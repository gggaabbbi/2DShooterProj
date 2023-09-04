using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public int gameScore = 0;
    [HideInInspector] public int playerLifes;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public int GetScore()
    {
        return gameScore;
    }

    public void SetGameScore(int score)
    {
        gameScore += score;
        UIManager.instance.SetScoreText(gameScore);
    }

    public void SetPlayerLife(int lifes)
    {
        playerLifes = lifes;
        UIManager.instance.SetLifesText(playerLifes);
    }

    public void SetLevelInfo(int currentLevel, int currentXP, int toLevelUpXP)
    {
        UIManager.instance.SetXPInfoText(currentXP, toLevelUpXP);
        UIManager.instance.SetPlayerLevelText(currentLevel);
    }
    public void OnLevelUp()
    {
        Time.timeScale = 0;
        UIManager.instance.SetPowerUpContainer(true);
    }
}
