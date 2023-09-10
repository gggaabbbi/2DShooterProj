using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPistol : MonoBehaviour
{
    private Transform aimTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;
    [SerializeField] private float fireRate;
    float nextFire;

    void Awake()
    {
        aimTransform = GetComponent<Transform>();
    }

    void Update()
    {
        AimHandler();
        ShootingHandler();
    }
    void AimHandler()
    {
        Vector3 mousePosition = GameManager.instance.GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3 (0, 0, angle);
    }

    void ShootingHandler()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
        }
    }
}
