using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsMouse : MonoBehaviour
{
    void Update() 
    {
        Vector3 playerPos = transform.position;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;
            target.y = playerPos.y;
            transform.LookAt(target);
        }
    }
}
