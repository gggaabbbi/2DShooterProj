using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : MonoBehaviour
{
    public static PlayerShotgun instance;

    private Transform aimTransform;
    [SerializeField] private float fireRate;
    float nextFire;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform weapon2;
    [SerializeField] private Transform weapon3;

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
            StartCoroutine(Shoot());
        }
        PlayerInfo.instance.SetRecoil(false);
    }

    IEnumerator Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
            yield return new WaitForSeconds(.01f);
            Instantiate(bulletPrefab, weapon2.position, weapon2.rotation);
            yield return new WaitForSeconds(.01f);
            Instantiate(bulletPrefab, weapon3.position, weapon3.rotation);
            PlayerInfo.instance.SetRecoil(true);
        }
    }

    public Transform GetAimPosition()
    {
        return aimTransform;
    }
}
