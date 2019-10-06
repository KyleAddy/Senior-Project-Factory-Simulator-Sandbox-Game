using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RobotPlayerFunctions
{
    public struct codeAction
    {
        //program action
        public string action;

        //item selection
        public ItemSO itemSelected;

        //for loop
        public int numToLoop;
        public int numLeftToLoop;

        //if statement
        public string ifCondition;
        public bool toggleIfConditionOuput;
        public int ifCountAmount;
    }

    public static int selectedFunction = 0;

    public static codeAction[,] playerFunctions = new codeAction[5,25];


}
