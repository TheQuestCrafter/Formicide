using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Sprite[] sprites;
    public float[,] Grid;
    int Vertical, Horizontal, Columns, Rows;

    // Start is called before the first frame update
    void Start()
    {
        Vertical = (int)Camera.main.orthographicSize;
        Horizontal = Vertical * (Screen.width / Screen.height);
        Columns = Horizontal * 2;
        Rows = Vertical * 2;
        Grid = new float[Columns, Rows];
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    private Vector3 GridToWorldPosition(int x, int y)
    {
        return new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
    }

    private int IsEdge(int x, int y)
    {
        if (y == Rows - 1 && x == 0)
            return 0; // Top Left
        else if (y == Rows - 1 && x != 0 && x != Columns - 1)
            return 1; // Top Middle
        else if (y == Rows - 1 && x == Columns - 1)
            return 2; // Top Right
        else if (x == 0 && y != 0 && y != Rows - 1)
            return 3; // Center Left
        else if (x == Columns - 1 && y != 0 && y != Rows - 1)
            return 5; // Center Right
        else if (x == 0 && y == 0)
            return 6; // Bottom Left
        else if (x != 0 && x != Columns - 1 && y == 0)
            return 7; // Bottom Middle
        else if (x == Columns - 1 && y == 0)
            return 8; // Bottom Right
        else
            return 4; // Center Middle (Not an edge or corner)
    }

    void SpawnTile(int x, int y, float value)
    {
        //GameObject g = new GameObject("X: " + x + "Y: " + y);
        //g.transform.position = new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
        //var s = g.AddComponent<SpriteRenderer>();
        //s.sprite = sprites[0];
        //s.color = new Color(value, value, value);
        SpriteRenderer sr = Instantiate(tilePrefab, GridToWorldPosition(x, y), Quaternion.identity).GetComponent<SpriteRenderer>();
        sr.name = "X: " + x + "Y: " + y;
        sr.sprite = sprites[IsEdge(x, y)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
