using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action playerShoot;

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerShoot?.Invoke();
        }
    }
}
