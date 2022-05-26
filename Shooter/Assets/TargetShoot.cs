using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShoot : MonoBehaviour
{
    public static Action targetShoot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            targetShoot?.Invoke();
        }
    }
}
