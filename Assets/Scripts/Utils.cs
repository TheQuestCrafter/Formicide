using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static int Vertical, Horizontal, Columns, Rows;

    public static Vector3 GridToWorldPosition(int x, int y)
    {
        return new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
    }

    public static int GetTile(int x, int y)
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
}
