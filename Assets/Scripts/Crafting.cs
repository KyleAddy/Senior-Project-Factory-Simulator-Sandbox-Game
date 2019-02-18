using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public ItemSO crafting;
    [SerializeField]
    GameObject globalGameObj;
    public float progNumber = 0;
    public float progressSpeed = .1f;
    public bool isCrafting = false;

    [SerializeField]
    List<int> ingredient0 = new List<int>();
    [SerializeField]
    List<int> ingredient1 = new List<int>();
    [SerializeField]
    List<int> ingredient2 = new List<int>();
    [SerializeField]
    List<int> ingredient3 = new List<int>();
    [SerializeField]
    List<int> ingredient4 = new List<int>();

    private void Start()
    {
        globalGameObj = GameObject.Find("gameGlobal");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgNumber();
        TryToCraft();
    }

    bool CheckForIngredients()
    {
        if (crafting != null)
        {
            for (int i = 0; i < GetComponent<Inventory>().invSize; i++)
            {
                if (GetComponent<Inventory>().inventory[i] == crafting.craftingRecipe[0].item)
                {
                    if (ingredient0.Count < crafting.craftingRecipe[0].numOfItems)
                        ingredient0.Add(i); //add the index to ingredient0 list
                }
                else if (crafting.numOfDifItems > 1)
                {
                    if (GetComponent<Inventory>().inventory[i] == crafting.craftingRecipe[1].item)
                    {
                        if (ingredient1.Count < crafting.craftingRecipe[1].numOfItems)
                            ingredient1.Add(i); //add the index to ingredient1 list
                    }
                }
                else if (crafting.numOfDifItems > 2)
                {
                    if (GetComponent<Inventory>().inventory[i] == crafting.craftingRecipe[2].item)
                    {
                        if (ingredient2.Count < crafting.craftingRecipe[2].numOfItems)
                            ingredient2.Add(i); //add the index to ingredient2 list
                    }
                }
                else if (crafting.numOfDifItems > 3)
                {
                    if (GetComponent<Inventory>().inventory[i] == crafting.craftingRecipe[3].item)
                    {
                        if (ingredient3.Count < crafting.craftingRecipe[3].numOfItems)
                            ingredient3.Add(i); //add the index to ingredient3 list
                    }
                }
                else if (crafting.numOfDifItems > 4)
                {
                    if (GetComponent<Inventory>().inventory[i] == crafting.craftingRecipe[4].item)
                    {
                        if (ingredient4.Count < crafting.craftingRecipe[4].numOfItems)
                            ingredient4.Add(i); //add the index to ingredient4 list
                    }
                }
            }

            if (ingredient0.Count == crafting.craftingRecipe[0].numOfItems)
                if (crafting.numOfDifItems == 1)
                    return true;
                else if (ingredient1.Count == crafting.craftingRecipe[1].numOfItems)
                    if (crafting.numOfDifItems == 2)
                        return true;
                    else if (ingredient2.Count == crafting.craftingRecipe[2].numOfItems)
                        if (crafting.numOfDifItems == 3)
                            return true;
                        else if (ingredient3.Count == crafting.craftingRecipe[3].numOfItems)
                            if (crafting.numOfDifItems == 4)
                                return true;
                            else if (ingredient0.Count == crafting.craftingRecipe[4].numOfItems)
                                if (crafting.numOfDifItems == 5)
                                    return true;
        }
        ClearAllIngredientLists();
        return false;
    }

    public void TryToCraft()
    {
        if (!isCrafting)
        {
            if (CheckForIngredients())
            {
                DeleteIngredients(ingredient0);
                DeleteIngredients(ingredient1);
                DeleteIngredients(ingredient2);
                DeleteIngredients(ingredient3);
                DeleteIngredients(ingredient4);
                ClearAllIngredientLists();
                SetProgNumber();
            }
        }
    }
    void ClearAllIngredientLists()
    {
        ingredient0.Clear();
        ingredient1.Clear();
        ingredient2.Clear();
        ingredient3.Clear();
        ingredient4.Clear();
    }

    void DeleteIngredients(List<int> listOfIndexes)
    {
        foreach (var index in listOfIndexes)
        {
            GetComponent<Inventory>().inventory[index] = null;
        }
    }

    void SetProgNumber()
    {
        isCrafting = true;
        progNumber = 0;
    }

    void UpdateProgNumber()
    {
        if (isCrafting)
        {
            if (progNumber < 1)
                progNumber += progressSpeed * Time.deltaTime;
            else
            {
                progNumber = 0;
                isCrafting = false;
                CraftItem();
            }
        }

    }

    void CraftItem()
    {
        int index = globalGameObj.GetComponent<gameGlobal>().findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
        if (index != -1)
            GetComponent<Inventory>().inventory[index] = crafting;
    }
}