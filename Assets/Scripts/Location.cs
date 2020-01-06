using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public int XCoordinate;
    public int YCoordinate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Ant>().CurrentLocation.XCoordinate = XCoordinate;
        collision.gameObject.GetComponent<Ant>().CurrentLocation.YCoordinate = YCoordinate;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Ant>().CurrentLocation.XCoordinate = XCoordinate;
        collision.gameObject.GetComponent<Ant>().CurrentLocation.YCoordinate = YCoordinate;
    }
}
