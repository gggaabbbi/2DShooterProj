using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPistol : MonoBehaviour
{
    [Header("PowerUp Info")]
    [SerializeField] private Button button;
    [SerializeField] private new string name;
    [SerializeField] private Sprite icon;

    [Header("Prefab Child Components")]
    [SerializeField] private TextMeshProUGUI powerUpNameText;
    [SerializeField] private Image powerUpIcon;

    [Header("Weapons Info")]
    [SerializeField] private GameObject weaponAnchor;
    [SerializeField] private GameObject weaponAnchorShotgun;
    [SerializeField] private GameObject powerUpShotgun;


    void Awake()
    {
        button.onClick.AddListener(SwitchToPistol);
        powerUpIcon.sprite = icon;
        powerUpNameText.text = name;
    }

    private void SwitchToPistol()
    {
        weaponAnchorShotgun.gameObject.SetActive(false);
        weaponAnchor.gameObject.SetActive(true);
        Time.timeScale = 1;
        UIManager.instance.SetPowerUpContainer(false);
        gameObject.SetActive(false);
        powerUpShotgun.gameObject.SetActive(true);
    }
}
