﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    string Name { get; set; }
    int WeaponDamage { get; set; }
    
    string Use(Ant Target);
}
