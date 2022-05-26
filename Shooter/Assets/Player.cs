using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float health = 100f;

    public float regenDelay = 1f;
    public float regenAmount = 1f;

    public float timeSinceLastDamage;

    void Update() 
    {
        timeSinceLastDamage += Time.deltaTime;
        StartCoroutine(Regen());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        timeSinceLastDamage = 0f;
    }

    IEnumerator Regen()
    {
        while (timeSinceLastDamage > 5f)
        {
            yield return new WaitForSeconds(regenDelay);
            health += regenAmount;
        }
    }
}
