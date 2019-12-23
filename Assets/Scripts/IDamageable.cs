using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int Strength { get; set; }
    int Defense { get; set; }
    int Hitpoints { get; set; }
    Ant Target { get; set; }


    int CalculateDamage(int damage);
    string TakeDamage(int damage);

}
