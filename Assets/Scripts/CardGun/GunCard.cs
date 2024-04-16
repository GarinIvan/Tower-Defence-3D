﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCard : MonoBehaviour
{
    public float Damage = 10f;
    public float interval = 1f;
    private float timer = 0f;
    public Building color;
    public Bullet bulletPrefab;
    public Transform[] bulletSpawnPosition;
    private void Update()
    {
        ShotFind();
    }
    private void ShotFind()
    {
        if (color._renderer.material.color == color.colorMaterial)
        {
            bool canShoot = false;
            RaycastHit hit;

            for (int i = 0; i < bulletSpawnPosition.Length; i++)
            {
                if (Physics.Raycast(bulletSpawnPosition[i].position + Vector3.up,
                        bulletSpawnPosition[i].TransformDirection(Vector3.forward), out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        canShoot = true;
                        break; // Если нашли хотя бы одно попадание во врага, выходим из цикла
                    }
                }
            }

            if (canShoot)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    timer = 0f;
                    Shot();
                }
            }
        }
    }
    private void Shot()
    {
        for (int i = 0; i < bulletSpawnPosition.Length; i++)
        {
            Instantiate(bulletPrefab, bulletSpawnPosition[i].position, bulletSpawnPosition[i].rotation);
        }
    }
}
