using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string WeaponType { get; set;}
    public int Bullets { get; set; }
    public float BulletRate { get; set; }
    public Weapon(string weaponType, int bullets , float bulletRate) {
        WeaponType = weaponType;
        Bullets = bullets;
        BulletRate = bulletRate;    
    }
}
