using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    //Game Manager
    public static GameObject gameManager;
    //level grid
    public const float GLOBAL_gridCellSize = 1f;
    public static int GLOBAL_worldX = 100;
    public static int GLOBAL_worldZ = 100;
    public static GameObject[,] GLOBAL_grid= new GameObject[500, 500];

    //selected object
    public static GameObject GLOBAL_selectedObject = null;
    //selected inventory slot
    public static int GLOBAL_selectedIndex = 0;

    //level loading/generation
    public static bool createNewWorld = true;
    public static string levelPath;
    public static string worldSize = "small";
    public static float ironOrePercent = 100;
    public static float copperOrePercent = 100;
}
