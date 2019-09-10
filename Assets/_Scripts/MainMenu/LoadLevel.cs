using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void loadLevel(bool levelExist)
    {
        if (levelExist)
        {
            loadGame();
        }

    }
    public void newGame()
    {
        GlobalVariables.createNewWorld = true;
        if (GlobalVariables.worldSize == "small")
        {
            GlobalVariables.GLOBAL_worldX = 100;
            GlobalVariables.GLOBAL_worldZ = 100;
            SceneManager.LoadScene("World_Small");
        }
        else if (GlobalVariables.worldSize == "medium")
        {
            GlobalVariables.GLOBAL_worldX = 250;
            GlobalVariables.GLOBAL_worldZ = 250;
            SceneManager.LoadScene("World_Medium");
        }
        else if (GlobalVariables.worldSize == "large")
        {
            GlobalVariables.GLOBAL_worldX = 500;
            GlobalVariables.GLOBAL_worldZ = 500;
            SceneManager.LoadScene("World_Large");
        }
    }

    public void loadGame()
    {
        GlobalVariables.createNewWorld = false;

        if (GlobalVariables.worldSize == "small")
        {
            GlobalVariables.GLOBAL_worldX = 100;
            GlobalVariables.GLOBAL_worldZ = 100;
            SceneManager.LoadScene("World_Small");
        }
        else if (GlobalVariables.worldSize == "medium")
        {
            GlobalVariables.GLOBAL_worldX = 250;
            GlobalVariables.GLOBAL_worldZ = 250;
            SceneManager.LoadScene("World_Medium");

        }
        else if (GlobalVariables.worldSize == "large")
        {
            GlobalVariables.GLOBAL_worldX = 500;
            GlobalVariables.GLOBAL_worldZ = 500;
            SceneManager.LoadScene("World_Large");
        }                
    }

    public void setLevelPath(int level)
    {
        if (level == 1)
        {
            GlobalVariables.levelPath = ConstVariables.world1Path;
        }
        else if (level == 2)
        {
            GlobalVariables.levelPath = ConstVariables.world2Path;
        }
        else if (level == 3)
        {
            GlobalVariables.levelPath = ConstVariables.world3Path;
        }
    }

    public void LoadTutorialLevel()
    {
        SceneManager.LoadScene("World_Tutorial");
    }
}
