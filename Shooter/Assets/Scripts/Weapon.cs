using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform muzzlePosition;
    public Projectile projectile;
    public float msBetweenShots = 1000f;
    public float muzzleVelocity = 10f;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzlePosition.position, muzzlePosition.rotation) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);
        }
    }
}
