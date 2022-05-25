using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //create a system action to shoot
    System.Action shootInput;

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootInput();
        }
    }


}
