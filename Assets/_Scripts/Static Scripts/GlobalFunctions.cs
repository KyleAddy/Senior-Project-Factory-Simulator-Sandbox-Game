using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalFunctions
{
    public static bool CheckIfItemSoArrayIsEmpty(ItemSO[] array, int arraySize)
    {
        for (int i = 0; i < arraySize; i++)
        {
            if (array[i] != null)
            {
                if (array[i].itemName != "")
                {
                    return false;
                }                
            }
        }
        return true;
    }

    public static bool CheckIfItemSoArrayIsFull(ItemSO[] array, int arraySize)
    {
        for (int i = 0; i < arraySize; i++)
        {
            if (array[i] == null)
            {
                return false;
            }
            else if (array[i].itemName == "")
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckItemSoArrayForXEmptySlots(ItemSO[] array, int arraySize, int numOfEmptySlots)
    {
        int counter = 0;
        for (int i = 0; i < arraySize; i++)
        {
            if (array[i] == null)
            {
                counter++;
            }
            else if (array[i].itemName == "")
            {
                counter++;
            }        
        }

        if (counter >= numOfEmptySlots)
        {
            return true;
        }

        return false;
    }

    public static int findEmptArraySlot(ItemSO[] array, int arraySize)
    {
        for (int i = 0; i < arraySize; i++)
        {
            if (array[i] == null)
            {               
                    return (i);
            }
            else if (array[i].itemName == "")
            {
                return (i);
            }
        }
        return (-1);
    }
}
