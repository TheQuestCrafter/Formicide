using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ant : MonoBehaviour, IDamageable, ICharacter
{
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Hitpoints { get; set; }
    public Ant Target { get; set; }
    public int Movement { get; set; }
    public int VisionRadius { get; set; }
    public IWeapon EquippedWeapon { get; set; }

    public Ant()
    {
        Movement = Strength = Defense = Hitpoints = VisionRadius = 5;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUnit()
    {

    }

    public void Attack()
    {
        this.UseWeapon(Target);
    }

    public string UseWeapon(IDamageable other)
    {
        return this.EquippedWeapon.Use(Target) + "\n " + other.TakeDamage(this.CalculateDamage(this.EquippedWeapon.WeaponDamage));
    }

    public int CalculateDamage(int damage)
    {
        Debug.Log("You made it to CalculateDamage()!");
        return 1;
    }

    public string TakeDamage(int damage)
    {
        Debug.Log("You made it to TakeDamage()");
        return "1";
    }
}
