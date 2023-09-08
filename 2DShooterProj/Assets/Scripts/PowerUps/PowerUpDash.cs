using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDash : MonoBehaviour
{
    [Header("PowerUp Info")]
    [SerializeField] private Button button;
    [SerializeField] private new string name;
    [SerializeField] private Sprite icon;

    [Header("Prefab Child Components")]
    [SerializeField] private TextMeshProUGUI powerUpNameText;
    [SerializeField] private Image powerUpIcon;

    void Awake()
    {
        button.onClick.AddListener(Dash);
        powerUpIcon.sprite = icon;
        powerUpNameText.text = name;
    }

    private void Dash()
    {
        PlayerMove.instance.SetPowerUpDash(true);
        Time.timeScale = 1;
        UIManager.instance.SetPowerUpContainer(false);
        gameObject.SetActive(false);
    }
}
