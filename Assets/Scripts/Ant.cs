using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ant : MonoBehaviour, IDamageable
{
    public int movement, strength, defense, hitpoints, visionRadius;

    public Ant()
    {
        movement = strength = defense = hitpoints = visionRadius = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
