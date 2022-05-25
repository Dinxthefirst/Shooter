using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
    public new string name;

    public float damage;
    public float range;
    public float fireRate;

}
