using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    [SerializeField] GameObject wandBulletprefab;
    [SerializeField] Transform wandBulletSpawn;


    float timeSinceLastShot;
    bool canShoot() => timeSinceLastShot > 1f / (weaponData.fireRate / 60f);

    void Start()
    {
        PlayerShoot.playerShoot += Shoot;
    }

    void Update() 
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(wandBulletSpawn.position, wandBulletSpawn.forward * weaponData.range, Color.red);
    }

    public void Shoot()
    {
        if (canShoot())
        {
            var bullet = Instantiate(wandBulletprefab, wandBulletSpawn.position, wandBulletSpawn.rotation);
            var wandBullet = bullet.GetComponent<WandBullet>();
            wandBullet.SetDamage(weaponData.damage);
            wandBullet.SetRange(weaponData.range);
            wandBullet.SetSpeed(weaponData.speed);

            timeSinceLastShot = 0f;
        }
    }
}
