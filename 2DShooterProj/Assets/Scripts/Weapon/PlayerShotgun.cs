using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : MonoBehaviour
{
    private Transform aimTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform weapon2;
    [SerializeField] private Transform weapon3;

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
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    void ShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
            Instantiate(bulletPrefab, weapon2.position, weapon2.rotation);
            Instantiate(bulletPrefab, weapon3.position, weapon3.rotation);
        }
    }
}
