using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingRecipeDisplayPanel : MonoBehaviour
{
    [SerializeField] GameObject ingredient0;
    [SerializeField] GameObject ingredient1;
    [SerializeField] GameObject ingredient2;
    [SerializeField] GameObject ingredient3;
    [SerializeField] GameObject ingredient4;
    [SerializeField] GameObject ingredientAmount0;
    [SerializeField] GameObject ingredientAmount1;
    [SerializeField] GameObject ingredientAmount2;
    [SerializeField] GameObject ingredientAmount3;
    [SerializeField] GameObject ingredientAmount4;

    [SerializeField] GameObject ingredientsPanel;
    // Start is called before the first frame update
    void Start()
    {
        ingredientsPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRecipe();
    }

    void UpdateRecipe()
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting != null)
            {
                if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.itemName != "")
                {
                    ingredientsPanel.SetActive(true);
                    EnableRecipeText(GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.numOfDifItems);
                    ingredient0.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[0].item.itemName;
                    ingredientAmount0.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[0].numOfItems.ToString();
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.numOfDifItems > 1)
                    {
                        ingredient1.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[1].item.itemName;
                        ingredientAmount1.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[1].numOfItems.ToString();
                    }
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.numOfDifItems > 2)
                    {
                        ingredient2.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[2].item.itemName;
                        ingredientAmount2.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[2].numOfItems.ToString();
                    }
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.numOfDifItems > 3)
                    {
                        ingredient3.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[3].item.itemName;
                        ingredientAmount3.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[3].numOfItems.ToString();
                    }
                    if (GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.numOfDifItems > 4)
                    {
                        ingredient4.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[4].item.itemName;
                        ingredientAmount4.GetComponent<TextMeshProUGUI>().text = GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting.craftingRecipe[4].numOfItems.ToString();
                    }
                }
            }
        }
    }

    void DisableAllRecipeText()
    {
            ingredient4.SetActive(false);
            ingredient3.SetActive(false);
            ingredient2.SetActive(false);
            ingredient1.SetActive(false);
    }

    void EnableRecipeText(int num)
    {
        DisableAllRecipeText();
        if(num > 1)
            ingredient1.SetActive(true);
        if (num > 2)
            ingredient2.SetActive(true);
        if (num > 3)
            ingredient3.SetActive(true);
        if (num == 4)
            ingredient4.SetActive(true);
    }

}
