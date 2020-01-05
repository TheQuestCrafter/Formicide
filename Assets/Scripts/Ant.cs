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

    protected void SetAntPositionToGrid()
    {
        float xCoord = this.gameObject.transform.position.x;
        float xRemainder = xCoord % 0.5f;

        float yCoord = this.gameObject.transform.position.y;
        float yRemainder = yCoord % 0.5f;

        xCoord = AlignToGrid(xCoord, xRemainder);
        yCoord = AlignToGrid(yCoord, yRemainder);

        this.gameObject.transform.position = new Vector3(xCoord, yCoord);
    }

    protected float AlignToGrid(float Coord, float Remainder)
    {
        if (Remainder < 0.5f && Remainder > 0)
        {
            Coord -= Remainder;
            Coord += 0.5f;
        }
        else if (Remainder > -0.5f && Remainder < 0)
        {
            Coord -= Remainder;
            Coord -= 0.5f;
        }
        else
        {
            Coord -= Remainder;
        }

        if (Coord % 1f == 0)
        {
            if (Remainder != 0)
            {
                if (Remainder > 0)
                    Coord = 0.5f;
                else
                    Coord = -0.5f;
            }
        }
        return Coord;
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
        // Strength + [(Weapon might + Weapon triangle bonus) x Effective bonus] + Support bonus
        // Defense + Support bonus + Terrain bonus
        // Damage	= (Attack – enemy Defense) x Critical bonus
        Debug.Log("You made it to CalculateDamage()!");
        return 1;
    }

    public string TakeDamage(int damage)
    {
        Debug.Log("You made it to TakeDamage()");
        return "1";
    }
}
