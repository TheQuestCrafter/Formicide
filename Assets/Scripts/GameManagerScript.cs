using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<Ant> PlayerAnts;
    public GameObject SelectedUnit;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnts = new List<Ant>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
