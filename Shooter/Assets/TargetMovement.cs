using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 10f;
    Vector3 destination;
    bool MovePointSet;

    Transform player;
    
    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() 
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 15f)
        {
            LookAtPlayer();
        }
        else 
        {
            MoveToRandomDestination();
        }        
    }

    void MoveToRandomDestination()
    {
        if (!MovePointSet) 
        {
            destination = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));
            MovePointSet = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, destination) < .5f)
            {
                MovePointSet = false;
            }
        }
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);
    }
}
