using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
