using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCard : MonoBehaviour
{
    public float Damage = 10f;
    public float interval = 1f;
    private float timer = 0f;
    public Building color;
    public Bullet bulletPrefab;
    public Transform bulletSpawnPosition;

    private void Update()
    {
        ShotFind();
    }

    private void ShotFind()
    {
        if (color._renderer.material.color == color.colorMaterial)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), out hit))
            {
                timer += Time.deltaTime;
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    if (timer >= interval)
                    {
                        timer = 0f;
                        Shot();
                    }
                }
            }
        }
    }
    private void Shot()
    {
        Instantiate(bulletPrefab, bulletSpawnPosition.position, transform.rotation);
    }
}
