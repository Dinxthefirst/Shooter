using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandBullet : MonoBehaviour
{
    public float damage;
    public float range;
    public float speed;

    Vector3 startPosition;

    void Start() 
    {
        startPosition = transform.position;
    }
    
    void Update() 
    {
        if (Vector3.Distance(transform.position, startPosition) > range) 
        {
            Destroy(gameObject);
        }
        Move();
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetRange(float range)
    {
        this.range = range;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(damage);
        Destroy(gameObject);
    }

    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
