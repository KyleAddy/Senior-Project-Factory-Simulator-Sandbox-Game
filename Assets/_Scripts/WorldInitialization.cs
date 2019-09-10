using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInitialization : MonoBehaviour
{
    [SerializeField] GameObject ironOre;
    [SerializeField] GameObject copperOre;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVariables.createNewWorld)
        {
            GenerateWorld();
        }
        else
        {
            SetUpLevel();
        }
    }

    void GenerateWorld()
    {
        float ironSpawnPercent = (GlobalVariables.ironOrePercent * 0.01f) * ConstVariables.ironSpawnPercent;
        float copperSpawnPercent = (GlobalVariables.copperOrePercent * 0.01f) * ConstVariables.copperSpawnPercent;

        int numOfIronPlaced = 0;
        int numOfCopperPlaced = 0;
        for (int x = 0; x < GlobalVariables.GLOBAL_worldX; x++)
        {
            for (int z = 0; z < GlobalVariables.GLOBAL_worldZ; z++)
            {
                if (Random.Range(0, 2) == 0) //if 0 then try to place iron / if 1 then try and place copper
                {
                    if (Random.Range(0.0f, 100.0f) <= ironSpawnPercent)
                    {                                   
                        GlobalVariables.GLOBAL_grid[x, z] = Instantiate(ironOre, new Vector3(x, 0, z), Quaternion.identity);
                        numOfIronPlaced++;
                    } else
                    {
                        GlobalVariables.GLOBAL_grid[x, z] = null;
                    }
                }
                else
                {
                    if (Random.Range(0.0f, 100.0f) <= copperSpawnPercent)
                    {
                        GlobalVariables.GLOBAL_grid[x, z] = Instantiate(copperOre, new Vector3(x, 0, z), Quaternion.identity);
                        numOfCopperPlaced++;
                    }
                    else
                    {
                        GlobalVariables.GLOBAL_grid[x, z] = null;
                    }
                }

                
            }
        }
        //if there is no iron then place at least one node
        if (numOfIronPlaced == 0)
        {
            bool hasPlacedIron = false;
            while (!hasPlacedIron)
            {
                int x = Random.Range(0, 100);
                int z = Random.Range(0, 100);
                if (GlobalVariables.GLOBAL_grid[x, z] == null)
                {
                    GlobalVariables.GLOBAL_grid[x, z] = Instantiate(ironOre, new Vector3(x, 0, z), Quaternion.identity);
                    hasPlacedIron = true;
                }
            }
        }

        //if there is no copper then place at least one node
        if (numOfCopperPlaced == 0)
        {
            bool hasPlacedCopper = false;
            while (!hasPlacedCopper)
            {
                int x = Random.Range(0, 100);
                int z = Random.Range(0, 100);
                if (GlobalVariables.GLOBAL_grid[x, z] == null)
                {
                    GlobalVariables.GLOBAL_grid[x, z] = Instantiate(copperOre, new Vector3(x, 0, z), Quaternion.identity);
                    hasPlacedCopper = true;
                }
            }
        }

        //place player in random location on map
        bool playerHasSpawned = false;
        while (!playerHasSpawned)
        {
            int x = Random.Range(0, 100);
            int z = Random.Range(0, 100);
            if (GlobalVariables.GLOBAL_grid[x, z] == null)
            {
                GameObject.Find(ConstVariables.playerName).transform.position = new Vector3(x, 1, z);
                playerHasSpawned = true;
            }
        }
        
        GlobalVariables.createNewWorld = false;
    }

    void SetUpLevel()
    {
        GameObject.Find(ConstVariables.gameManagerName).GetComponent<SaveLoadGame>().LoadGame();
    }
}
