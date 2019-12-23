using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public TileThemeObject[] themes;
    public float[,] Grid;

    // Start is called before the first frame update
    void Start()
    {
        SetupGrid();
    }

    private void SetupGrid()
    {
        Utils.Vertical = (int)Camera.main.orthographicSize;
        Utils.Horizontal = Utils.Vertical * (Screen.width / Screen.height);
        Utils.Columns = Utils.Horizontal * 2;
        Utils.Rows = Utils.Vertical * 2;
        Grid = new float[Utils.Columns, Utils.Rows];
        for (int i = 0; i < Utils.Columns; i++)
        {
            for (int j = 0; j < Utils.Rows; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                //SpawnTile(i, j, Grid[i, j]);
            }
        }
    }
      
    void SpawnTile(int x, int y, float value)
    {
        //GameObject g = new GameObject("X: " + x + "Y: " + y);
        //g.transform.position = new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
        //var s = g.AddComponent<SpriteRenderer>();
        //s.sprite = sprites[0];
        //s.color = new Color(value, value, value);
        //SpriteRenderer sr = Instantiate(tilePrefab, Utils.GridToWorldPosition(x, y), Quaternion.identity).GetComponent<SpriteRenderer>();
        //sr.name = "X: " + x + "Y: " + y;
        //sr.sprite = sprites[Utils.GetTile(x, y)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
