using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    Transform player;

    float x_offset;
    float z_offset;
    float height = 10f;
    float x_rotation = 45f;
    float y_rotation = 45f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        x_offset = Mathf.Cos(x_rotation * Mathf.Deg2Rad) * height;
        z_offset = Mathf.Sin(y_rotation * Mathf.Deg2Rad) * height;
        
        transform.position = new Vector3(player.position.x - x_offset, player.position.y + height, player.position.z - z_offset);
        transform.rotation = Quaternion.Euler(x_rotation, y_rotation, 0f);
    }

    private void FixedUpdate() {
        
    }
}
