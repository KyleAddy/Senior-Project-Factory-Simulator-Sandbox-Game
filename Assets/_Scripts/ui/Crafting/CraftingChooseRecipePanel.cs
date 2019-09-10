using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingChooseRecipePanel : MonoBehaviour
{
    public void setCraftingRecipe(ItemSO item)
    {
        if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (!GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().isCrafting)
            {
                GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().crafting = item;
                GlobalVariables.GLOBAL_selectedObject.GetComponent<Crafting>().TryToCraft();
            }
        }
    }

    public void AddItemToCraftingQeue(ItemSO item)
    {
        GlobalVariables.gameManager.GetComponent<playerCrafting>().AddItemToQeue(item);
    }
}
