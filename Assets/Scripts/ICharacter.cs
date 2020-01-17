using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    int Movement { get; set; }
    int VisionRadius { get; set; }
    IWeapon EquippedWeapon { get; set; }
}
