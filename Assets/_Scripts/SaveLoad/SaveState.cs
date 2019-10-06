using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveState
{
    [System.Serializable]
    public struct codeAction
    {
        //program action
        public string action;

        //item selection
        public string itemSelected;

        //for loop
        public int numToLoop;
        public int numLeftToLoop;

        //if statement
        public string ifCondition;
        public bool toggleIfConditionOuput;
        public int ifCountAmount;
    }

    //level data
    public float gameVersion;
    public string worldSize;
    public int worldXLength;
    public int worldZLength;

    //player funcitons
    public codeAction[,] playerFunctions;

    //player position
    public float[] PlayerPosition = new float[2];
    public string[] playerInventory = new string[25];

    //ore data
    [System.Serializable] public struct oreData
    {
        public string oreType;
        public int[] orePosition;
    }
    public List<oreData> ores = new List<oreData>();

    //Refinery data
    [System.Serializable] public struct refineryData
    {
        public string[] refineryInventory;
        public int[] refineryPosition;
        public string currentlyCrafting;
        public bool isCrafting;
        public float progNumber;
        public bool isAnimation;        
    }
    public List<refineryData> refinerys = new List<refineryData>();

    //assembler data
    [System.Serializable] public struct assemblerData
    {
        public string[] assemblerInventory;
        public int[] assemblerPosition;
        public string currentlyCrafting;
        public bool isCrafting;
        public float progNumber;
        //public bool isAnimation;
    }
    public List<assemblerData> assemblers = new List<assemblerData>();

    //storagebox data
    [System.Serializable] public struct storageBoxData
    {
        public string[] storageBoxInventory;
        public int[] storageBoxPosition;
    }
    public List<storageBoxData> StorageBoxes = new List<storageBoxData>();

    //computers data    
    public List<float[]> computers = new List<float[]>();

    //robot data
    [System.Serializable] public struct robotData
    {
        [System.Serializable]
        public struct codeAction
        {
            //program action
            public string action;

            //item selection
            public string itemSelected;

            //for loop
            public int numToLoop;
            public int numLeftToLoop;

            //if statement
            public string ifCondition;
            public bool toggleIfConditionOuput;
            public int ifCountAmount;
        }
        
        public string[] robotInventory;
        public float[] robotPosition;
        public int[] robotGridPos;
        public codeAction[] robotProgram;
        public int[] currentStatement;

        public bool inAction;
        public bool isRunning;
        public string action;
        public int currentActionIndex;

        public string turnDir;
        public float totalRot;

        public int[] targPos;
        public bool movingForward;

        public float progBar;
    }
    public List<robotData> robots = new List<robotData>();
}
