using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // The Grid itself
    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w, h];

    /// <summary>
    /// Round a vector. For example, a vector like (1.0001, 2) becomes (1, 2)
    /// </summary>
    /// <param name="v">Vector2 object</param>
    /// <returns>Vector2 with rounded coords</returns>
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
            Mathf.Round(v.y));
    }

    /// <summary>
    /// Find out if a certain coordinate is in between the borders or if it's outside of the borders
    /// </summary>
    /// <param name="pos">Vector2 object</param>
    /// <returns>If the vector is inside or outside the borders</returns>
    public static bool insideBorder(Vector2 pos)
    {
        return ((int) pos.x >= 0 &&
                (int) pos.x < w &&
                (int) pos.y >= 0);
    }

    /// <summary>
    /// Deletes all Blocks in a certain row
    /// </summary>
    /// <param name="y">Vertical index of the row</param>
    public static void deleteRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    /// <summary>
    /// Move the row's blocks to the bottom row
    /// </summary>
    /// <param name="y">Vertical index of the row</param>
    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    /// <summary>
    /// Makes the rows from y position to fall towards the bottom by one unit
    /// </summary>
    /// <param name="y">Vertical index of the row</param>
    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
            decreaseRow(i);
    }

    /// <summary>
    /// Finds out if a row is full of blocks
    /// </summary>
    /// <param name="y">Vertical index of the row</param>
    /// <returns>If it's full or not</returns>
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

    /// <summary>
    /// Deletes all full rows
    /// </summary>
    public static void deleteFullRows()
    {
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
            }
        }
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