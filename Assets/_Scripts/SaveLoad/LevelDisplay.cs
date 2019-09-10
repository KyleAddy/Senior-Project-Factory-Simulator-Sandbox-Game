using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class LevelDisplay : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI text;
    string filePath = "";
    bool levelExist = false;
    string levelSize = "";
    [SerializeField] GameEvent levelGenEvent;
    [SerializeField] GameObject DeleteButton;

    // Start is called before the first frame update
    void Start()
    {
        SetDisplay();
    }

    public void SetDisplay()
    {
        if (checkIfLevelExist())
        {
            levelExist = true;
            text.GetComponent<TextMeshProUGUI>().text = "Load Game: " + level.ToString();
            DeleteButton.SetActive(true);
        }
        else
        {
            levelExist = false;
            text.GetComponent<TextMeshProUGUI>().text = "New Game";
            DeleteButton.SetActive(false);
        }
    }

    bool checkIfLevelExist()
    {
        if(level == 1)
        {
            filePath = ConstVariables.world1Path;
        }
        else if (level == 2)
        {
            filePath = ConstVariables.world2Path;
        }
        else if (level == 3)
        {
            filePath = ConstVariables.world3Path;

        }
        else
        {
            return false;
        }

        if (File.Exists(Application.persistentDataPath + filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + filePath, FileMode.Open);
            SaveState save = (SaveState)bf.Deserialize(file);
            file.Close();

            if (save.gameVersion == ConstVariables.gameVersion)
            {
                levelSize = save.worldSize;
                return true;
            }
        }        
            return false;
    }

   public void ButtonClick()
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
        GlobalVariables.worldSize = levelSize;
        if (levelExist)
        {
            GetComponent<LoadLevel>().loadLevel(levelExist);
        }
        else
        {
            levelGenEvent.Raise();
        }
    }
}
