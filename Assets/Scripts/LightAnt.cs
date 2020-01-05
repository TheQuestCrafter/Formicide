using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnt : Ant
{
    public LightAnt()
    {
        Hitpoints = 10;
        Strength = 4;
        Defense = 4;
        Movement = 2;
        VisionRadius = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetAntPositionToGrid();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    this.gameObject.transform.position = other.gameObject.transform.position;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    this.gameObject.transform.position= collision.gameObject.transform.position;
    //}
}
