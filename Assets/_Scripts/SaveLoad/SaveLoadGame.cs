using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadGame : MonoBehaviour
{
    //prefabs
    [SerializeField] GameObject ironOre;
    [SerializeField] GameObject copperOre;

    //ItemSO
    [SerializeField] ItemSO emptyItem;
    [SerializeField] ItemSO ironOreItem;
    [SerializeField] ItemSO copperOreItem;
    [SerializeField] ItemSO ironIngotItem;
    [SerializeField] ItemSO copperIngotItem;
    [SerializeField] ItemSO copperWireItem;
    [SerializeField] ItemSO machineChassisItem;
    [SerializeField] ItemSO electronicPartItem;
    [SerializeField] ItemSO robotItem;
    [SerializeField] ItemSO refineryItem;
    [SerializeField] ItemSO assemblerItem;
    [SerializeField] ItemSO storageBoxItem;



    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Saving Game");
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Loading Game");
            LoadGame();
        }
    }
    
    public SaveState CreateSaveObject()
    {
        SaveState save = new SaveState();

        //saving world data
        save.gameVersion = ConstVariables.gameVersion;
        save.worldSize = GlobalVariables.worldSize;
        save.worldXLength = GlobalVariables.GLOBAL_worldX;
        save.worldZLength = GlobalVariables.GLOBAL_worldZ;

        //saving player data
        save.PlayerPosition[0] = GameObject.Find("Player").transform.position.x;//x pos
        save.PlayerPosition[1] = GameObject.Find("Player").transform.position.z;//z pos
        for (int i = 0; i < save.playerInventory.Length; i++)//player inventory
        {
            if (GetComponent<Inventory>().inventory[i] != null)
            {
                save.playerInventory[i] = GetComponent<Inventory>().inventory[i].itemName;
            }
            else
            {
                save.playerInventory[i] = emptyItem.itemName;
            }
        }

        //save ore type and position
        var ores = GameObject.FindGameObjectsWithTag("oreMine");
        foreach (var ore in ores)
        {
            SaveState.oreData oreInfo;
            oreInfo.oreType = ore.GetComponent<OreMine>().oreType.itemName; //ore type
            oreInfo.orePosition = new int[2]; //ore position
            oreInfo.orePosition[0] = (int) ore.transform.position.x; //x pos
            oreInfo.orePosition[1] = (int) ore.transform.position.z; //z pos
            save.ores.Add(oreInfo);
        }

        //save refinery data
        var refinerys = GameObject.FindGameObjectsWithTag("refinery");
        foreach (var refinery in refinerys)
        {
            SaveState.refineryData refineryInfo;
            refineryInfo.refineryPosition = new int[2]; //refinery position
            refineryInfo.refineryPosition[0] = (int)refinery.transform.position.x; //x pos
            refineryInfo.refineryPosition[1] = (int)refinery.transform.position.z; //z pos
            refineryInfo.refineryInventory = new string[refinery.GetComponent<Inventory>().invSize]; //refinery inventory
            for (int i = 0; i < refinery.GetComponent<Inventory>().invSize; i++) //set inventory
            {
                if (refinery.GetComponent<Inventory>().inventory[i] != null)
                {
                    refineryInfo.refineryInventory[i] = refinery.GetComponent<Inventory>().inventory[i].itemName;
                }
                else
                {
                    refineryInfo.refineryInventory[i] = emptyItem.itemName;
                }                
            }
            if (refinery.GetComponent<Crafting>().crafting != null)
            {
                refineryInfo.currentlyCrafting = refinery.GetComponent<Crafting>().crafting.itemName; //saving what is being crafted
            }
            else
            {
                refineryInfo.currentlyCrafting = "";
            }
            refineryInfo.isCrafting = refinery.GetComponent<Crafting>().isCrafting; //save if it is crafting
            refineryInfo.progNumber = refinery.GetComponent<Crafting>().progNumber; //save prograss of crafting
            refineryInfo.isAnimation = refinery.GetComponent<RefineryAnimation>().isAnimation; //save if animation is on
            save.refinerys.Add(refineryInfo);
        }

        //save assembler data
        var assemblers = GameObject.FindGameObjectsWithTag("assembler");
        foreach (var assembler in assemblers)
        {
            SaveState.assemblerData assemblerInfo;
            assemblerInfo.assemblerPosition = new int[2]; //refinery position
            assemblerInfo.assemblerPosition[0] = (int)assembler.transform.position.x; //x pos
            assemblerInfo.assemblerPosition[1] = (int)assembler.transform.position.z; //z pos
            assemblerInfo.assemblerInventory = new string[assembler.GetComponent<Inventory>().invSize]; //refinery inventory
            for (int i = 0; i < assembler.GetComponent<Inventory>().invSize; i++) //set inventory
            {
                if (assembler.GetComponent<Inventory>().inventory[i] != null)
                {
                    assemblerInfo.assemblerInventory[i] = assembler.GetComponent<Inventory>().inventory[i].itemName;
                }
                else
                {
                    assemblerInfo.assemblerInventory[i] = emptyItem.itemName;
                }
            }
            if (assembler.GetComponent<Crafting>().crafting != null)
            {
                assemblerInfo.currentlyCrafting = assembler.GetComponent<Crafting>().crafting.itemName; //saving what is being crafted
            }
            else
            {
                assemblerInfo.currentlyCrafting = "";
            }
            assemblerInfo.isCrafting = assembler.GetComponent<Crafting>().isCrafting; //save if it is crafting
            assemblerInfo.progNumber = assembler.GetComponent<Crafting>().progNumber; //save prograss of crafting
            //assemblerInfo.isAnimation = assembler.GetComponent<RefineryAnimation>().isAnimation; //save if animation is on
            save.assemblers.Add(assemblerInfo);
        }

        //save storageboxes
        var boxes = GameObject.FindGameObjectsWithTag("storage");
        
        foreach (var box in boxes)
        {
            SaveState.storageBoxData boxInfo;

            boxInfo.storageBoxPosition = new int[2]; //box position
            boxInfo.storageBoxPosition[0] = (int)box.transform.position.x; //x pos
            boxInfo.storageBoxPosition[1] = (int)box.transform.position.z; //z pos
            boxInfo.storageBoxInventory = new string[box.GetComponent<Inventory>().invSize]; //storagebox inventory
            for (int i = 0; i < box.GetComponent<Inventory>().invSize; i++) //set inventory
            {
                if (box.GetComponent<Inventory>().inventory[i] != null)
                {
                    boxInfo.storageBoxInventory[i] = box.GetComponent<Inventory>().inventory[i].itemName;
                }
                else
                {
                    boxInfo.storageBoxInventory[i] = emptyItem.itemName;
                }
            }
            save.StorageBoxes.Add(boxInfo);
        }

        //save robots
        var robots = GameObject.FindGameObjectsWithTag("robot");

        foreach (var robot in robots)
        {
            SaveState.robotData robotInfo;
            robotInfo.robotPosition = new float[3]; //box position
            robotInfo.robotPosition[0] = robot.transform.position.x; //x pos
            robotInfo.robotPosition[1] = robot.transform.position.z; //z pos
            robotInfo.robotPosition[2] = robot.transform.eulerAngles.y; //y rot
            robotInfo.robotGridPos = new int[2]; //create robotGridPos array
            robotInfo.robotGridPos[0] = (int)robot.GetComponent<robot>().gridCoords.x;
            robotInfo.robotGridPos[1] = (int)robot.GetComponent<robot>().gridCoords.z;
            robotInfo.robotInventory = new string[robot.GetComponent<Inventory>().invSize]; //robot inventory
            for (int i = 0; i < robot.GetComponent<Inventory>().invSize; i++) //set inventory
            {
                if (robot.GetComponent<Inventory>().inventory[i] != null)
                {
                    robotInfo.robotInventory[i] = robot.GetComponent<Inventory>().inventory[i].itemName;
                }
                else
                {
                    robotInfo.robotInventory[i] = emptyItem.itemName;
                }
            }
            robotInfo.robotProgram = new string[robot.GetComponent<robot>().progArray.Length]; //robot program
            for (int i = 0; i < robot.GetComponent<robot>().progArray.Length; i++)
            {
                robotInfo.robotProgram[i] = robot.GetComponent<robot>().progArray[i];
            }
            robotInfo.itemSelectionArray = new string[robot.GetComponent<robot>().itemSelectionArray.Length]; //robot itemSelectionArray
            for (int i = 0; i < robot.GetComponent<robot>().itemSelectionArray.Length; i++)
            {
                if (robot.GetComponent<robot>().itemSelectionArray[i] != null)
                {
                    robotInfo.itemSelectionArray[i] = robot.GetComponent<robot>().itemSelectionArray[i].itemName;
                }
                else
                {
                    robotInfo.itemSelectionArray[i] = emptyItem.itemName;
                }
                
            }
            robotInfo.action = robot.GetComponent<robot>().action;//save action
            robotInfo.currentActionIndex = robot.GetComponent<robot>().currentActionIndex;//save current action index
            robotInfo.turnDir = robot.GetComponent<robot>().turnDir; //save turning direction
            robotInfo.totalRot = robot.GetComponent<robot>().totalRot; //save rotation left to turn

            print("totalRot: " + robotInfo.totalRot);

            robotInfo.inAction = robot.GetComponent<robot>().inAction; //save if robot is in a action
            robotInfo.isRunning = robot.GetComponent<robot>().isRunning; //save if robot is running program
            robotInfo.numToLoop = new int[robot.GetComponent<robot>().loop.Length];
            robotInfo.numLeftToLoop = new int[robot.GetComponent<robot>().loop.Length];
            robotInfo.isActive = new bool[robot.GetComponent<robot>().loop.Length];
            for (int i = 0; i < robot.GetComponent<robot>().loop.Length; i++) //save the loop data
            {
                robotInfo.isActive[i] = robot.GetComponent<robot>().loop[i].isActive;
                robotInfo.numLeftToLoop[i] = robot.GetComponent<robot>().loop[i].numLeftToLoop;
                robotInfo.numToLoop[i] = robot.GetComponent<robot>().loop[i].numToLoop;
            }
            robotInfo.currentStatement = robot.GetComponent<robot>().currentStatement.ToArray(); // create a copy of the current statement stack
            robotInfo.ifCondition = new string[robot.GetComponent<robot>().ifCondition.Length]; //create ifCondition array
            robotInfo.toggleIfConditionOutput = new bool[25]; //create toggleIfConditionOutput array
            robotInfo.ifCountAmount = new int[25]; //create ifCountAmount array
            for (int i = 0; i < 25; i++) //save the ifCondition data
            {
                robotInfo.ifCondition[i] = robot.GetComponent<robot>().ifCondition[i];//save if conditions
                robotInfo.toggleIfConditionOutput[i] = robot.GetComponent<robot>().toggleIfConditionOutput[i]; //save toggle if condition
                robotInfo.ifCountAmount[i] = robot.GetComponent<robot>().ifCountAmount[i];//save if count amount 
            }            
            robotInfo.targPos = new int[2];//create targPos array
            robotInfo.targPos[0] = (int)robot.GetComponent<robot>().targPos.x;//x Pos
            robotInfo.targPos[1] = (int)robot.GetComponent<robot>().targPos.z;// z Pos
            robotInfo.movingForward = robot.GetComponent<robot>().movingForward;
            robotInfo.progBar = robot.GetComponent<robot>().progBar.fillAmount;

            save.robots.Add(robotInfo);
        }
        return save;
    }

    public void SaveGame()
    {
        SaveState save = CreateSaveObject();

        BinaryFormatter bf = new BinaryFormatter();
        print(GlobalVariables.levelPath);
        FileStream file = File.Create(Application.persistentDataPath + GlobalVariables.levelPath);
        
        bf.Serialize(file, save);
        print("serialized");
        file.Close();
    }

    public void LoadGame()
    {
        
        if (File.Exists(Application.persistentDataPath + GlobalVariables.levelPath))
        {            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + GlobalVariables.levelPath, FileMode.Open);
            SaveState save = (SaveState)bf.Deserialize(file);
            file.Close();

            //GlobalVariables.GLOBAL_grid = new GameObject[save.worldXLength, save.worldZLength];//create level grid
            GlobalVariables.GLOBAL_worldX = save.worldXLength;
            GlobalVariables.GLOBAL_worldZ = save.worldZLength;

            //loading player data
            GameObject.Find("Player").transform.position = new Vector3(save.PlayerPosition[0], 1, save.PlayerPosition[1]); //player position
            for (int i = 0; i < save.playerInventory.Length; i++)//set player inventory
            {
               GetComponent<Inventory>().inventory[i] = nameFromItem(save.playerInventory[i]);
            }
            
            //load in all the ores
            foreach (SaveState.oreData ore in  save.ores)
            {
                if (ore.oreType == ironOreItem.itemName)
                {
                    GlobalVariables.GLOBAL_grid[ore.orePosition[0], ore.orePosition[1]] = Instantiate(ironOre, new Vector3(ore.orePosition[0], 0, ore.orePosition[1]), Quaternion.identity);
                }
                else if (ore.oreType == copperOreItem.itemName)
                {
                    GlobalVariables.GLOBAL_grid[ore.orePosition[0], ore.orePosition[1]] = Instantiate(copperOre, new Vector3(ore.orePosition[0], 0, ore.orePosition[1]), Quaternion.identity);
                }
            }

            //load all the refinerys
            foreach(SaveState.refineryData refinery in save.refinerys)
            {
                //create refinery
                GlobalVariables.GLOBAL_grid[refinery.refineryPosition[0], refinery.refineryPosition[1]] = Instantiate(refineryItem.itemPrefab, new Vector3(refinery.refineryPosition[0], 0, refinery.refineryPosition[1]), Quaternion.identity);
                for (int i = 0; i < refinery.refineryInventory.Length; i++)//set refinery inventory
                {
                    GlobalVariables.GLOBAL_grid[refinery.refineryPosition[0], refinery.refineryPosition[1]].GetComponent<Inventory>().inventory[i] = nameFromItem(refinery.refineryInventory[i]);
                }
                GlobalVariables.GLOBAL_grid[refinery.refineryPosition[0], refinery.refineryPosition[1]].GetComponent<Crafting>().crafting = nameFromItem(refinery.currentlyCrafting);//set what the refinery is crafting
                GlobalVariables.GLOBAL_grid[refinery.refineryPosition[0], refinery.refineryPosition[1]].GetComponent<Crafting>().isCrafting = refinery.isCrafting; //load if it is crafting
                GlobalVariables.GLOBAL_grid[refinery.refineryPosition[0], refinery.refineryPosition[1]].GetComponent<Crafting>().progNumber = refinery.progNumber; //load progress of crafting
                GlobalVariables.GLOBAL_grid[refinery.refineryPosition[0], refinery.refineryPosition[1]].GetComponent<RefineryAnimation>().isAnimation = refinery.isAnimation; //load if animation is on
            }

            //load all the assemblers
            foreach (SaveState.assemblerData assembler in save.assemblers)
            {
                //create refinery
                GlobalVariables.GLOBAL_grid[assembler.assemblerPosition[0], assembler.assemblerPosition[1]] = Instantiate(assemblerItem.itemPrefab, new Vector3(assembler.assemblerPosition[0], 0, assembler.assemblerPosition[1]), Quaternion.identity);
                for (int i = 0; i < assembler.assemblerInventory.Length; i++)//set assembler inventory
                {
                    GlobalVariables.GLOBAL_grid[assembler.assemblerPosition[0], assembler.assemblerPosition[1]].GetComponent<Inventory>().inventory[i] = nameFromItem(assembler.assemblerInventory[i]);
                }
                GlobalVariables.GLOBAL_grid[assembler.assemblerPosition[0], assembler.assemblerPosition[1]].GetComponent<Crafting>().crafting = nameFromItem(assembler.currentlyCrafting);//set what the assembler is crafting
                GlobalVariables.GLOBAL_grid[assembler.assemblerPosition[0], assembler.assemblerPosition[1]].GetComponent<Crafting>().isCrafting = assembler.isCrafting; //load if it is crafting
                GlobalVariables.GLOBAL_grid[assembler.assemblerPosition[0], assembler.assemblerPosition[1]].GetComponent<Crafting>().progNumber = assembler.progNumber; //load progress of crafting
               // GlobalVariables.GLOBAL_grid[assembler.assemblerPosition[0], assembler.assemblerPosition[1]].GetComponent<AssemblerAnimation>().isAnimation = assembler.isAnimation; //load if animation is on
            }

            //load all the storage boxes
            foreach (SaveState.storageBoxData box in save.StorageBoxes)
            {
                //create refinery
                GlobalVariables.GLOBAL_grid[box.storageBoxPosition[0], box.storageBoxPosition[1]] = Instantiate(storageBoxItem.itemPrefab, new Vector3(box.storageBoxPosition [0], .5f, box.storageBoxPosition[1]), Quaternion.identity);
                for (int i = 0; i < box.storageBoxInventory.Length; i++)//set assembler inventory
                {
                    GlobalVariables.GLOBAL_grid[box.storageBoxPosition[0], box.storageBoxPosition[1]].GetComponent<Inventory>().inventory[i] = nameFromItem(box.storageBoxInventory[i]);
                }
            }
            
            
            //load all the robots
            foreach (SaveState.robotData robot in save.robots)
            {
                //create robot                
                Quaternion rotation = Quaternion.Euler(0, robot.robotPosition[2], 0);
                 GameObject newRobot = Instantiate(robotItem.itemPrefab, new Vector3(robot.robotPosition[0], 0.5f, robot.robotPosition[1]), rotation); //create robot at loaction
                newRobot.GetComponent<LocationInitiation>().loadedIn = true;
                if(robot.action == "moving")//set the robots position on the grid
                {
                    GlobalVariables.GLOBAL_grid[robot.targPos[0], robot.targPos[1]] = newRobot;
                }
                else
                {
                    GlobalVariables.GLOBAL_grid[robot.robotGridPos[0], robot.robotGridPos[1]] = newRobot;
                }
                newRobot.GetComponent<robot>().gridCoords = new Vector3((int)robot.robotGridPos[0], .5f, (int)robot.robotGridPos[1]);
                for (int i = 0; i < robot.robotInventory.Length; i++)//set robot inventory
                {
                    newRobot.GetComponent<Inventory>().inventory[i] = nameFromItem(robot.robotInventory[i]);
                }
                for (int i = 0; i < robot.robotProgram.Length; i++) //load the robots programming array
                {
                    newRobot.GetComponent<robot>().progArray[i] = robot.robotProgram[i];
                }
                for (int i = 0; i < robot.robotInventory.Length; i++)//set robot itemSelectionArray
                {
                    newRobot.GetComponent<robot>().itemSelectionArray[i] = nameFromItem(robot.itemSelectionArray[i]);
                }
                newRobot.GetComponent<robot>().action = robot.action; //load action
                newRobot.GetComponent<robot>().currentActionIndex = robot.currentActionIndex;//load current action index
                newRobot.GetComponent<robot>().turnDir = robot.turnDir; //loading turn direction
                newRobot.GetComponent<robot>().totalRot = robot.totalRot; //load amount turned so far

                print("totalRot: " + robot.totalRot);

                newRobot.GetComponent<robot>().inAction = robot.inAction; //load if robot is in an action
                newRobot.GetComponent<robot>().isRunning = robot.isRunning; //load if thr robot is running the program                
                for (int i = 0; i < robot.isActive.Length; i++) //load the loop data
                {
                    newRobot.GetComponent<robot>().loop[i].isActive = robot.isActive[i];
                    newRobot.GetComponent<robot>().loop[i].numLeftToLoop = robot.numLeftToLoop[i];
                    newRobot.GetComponent<robot>().loop[i].numToLoop = robot.numToLoop[i];
                }
                for(int i = 0; i < robot.currentStatement.Length; i++) //load the currentStatement data
                {
                    newRobot.GetComponent<robot>().currentStatement.Push(robot.currentStatement[i]);
                }
                for(int i = 0; i < 25; i++) 
                {
                    newRobot.GetComponent<robot>().ifCondition[i] = robot.ifCondition[i];//load the ifCondition data
                    newRobot.GetComponent<robot>().toggleIfConditionOutput[i] = robot.toggleIfConditionOutput[i];//load the toggleIfConditionOutput data
                    newRobot.GetComponent<robot>().ifCountAmount[i] = robot.ifCountAmount[i];//load the if count amount data
                }

                newRobot.GetComponent<robot>().targPos = new Vector3((int)robot.targPos[0], .5f, (int)robot.targPos[1]); //load targPos
                newRobot.GetComponent<robot>().movingForward = robot.movingForward;
                newRobot.GetComponent<robot>().progBar.fillAmount = robot.progBar;                  
            }
        }

        else
        {
            Debug.LogWarning("No game saved!");
        }
        
    }

    ItemSO nameFromItem(string item)
    {
         if (item == ironOreItem.itemName)//iron ore
        {
            return ironOreItem;
        }
        else if (item == copperOreItem.itemName)//copper ore
        {
            return copperOreItem;
        }
        else if (item == ironIngotItem.itemName)//iron ingot
        {
            return ironIngotItem;
        }
        else if (item == copperIngotItem.itemName)//copper ingot
        {
            return copperIngotItem;
        }
        else if (item == copperWireItem.itemName)//copper wire
        {
            return copperWireItem;
        }
        else if (item == machineChassisItem.itemName)//machine chassis
        {
            return machineChassisItem;
        }
        else if (item == electronicPartItem.itemName)// electronic part
        {
            return electronicPartItem;
        }
        else if (item == robotItem.itemName)// robot
        {
            return robotItem;
        }
        else if (item == refineryItem.itemName)// refinery
        {
            return refineryItem;
        }
        else if (item == assemblerItem.itemName)// assembler
        {
            return assemblerItem;
        }
        else if (item == storageBoxItem.itemName)// storage box
        {
            return storageBoxItem;
        }
        else
        {
            return emptyItem;
        }
    }
}