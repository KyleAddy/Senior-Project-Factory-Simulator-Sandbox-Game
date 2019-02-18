using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameGlobal : MonoBehaviour {

	public static float GLOBAL_gridCellSize;
	public static int GLOBAL_worldX;
	public static int GLOBAL_worldZ;
	public static GameObject[,] GLOBAL_grid = new GameObject[10, 10];

	public static GameObject GLOBAL_selectedObject = null;
	public static int GLOBAL_selectedIndex = 0;

	// Use this for initialization
	void Start () {

		GLOBAL_gridCellSize = 1f;
		GLOBAL_worldX = 10;
		GLOBAL_worldZ = 10;
	}

    public int findEmptArraySlot(ItemSO[] array, int arraySize)
    {
        for (int i = 0; i < arraySize; i++)
        {
            if (array[i] == null)
            {
                return (i);
            }
        }
        return (-1);
    }
}
