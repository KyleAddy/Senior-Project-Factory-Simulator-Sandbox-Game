using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingChooseRecipePanel : MonoBehaviour
{


    public void setCraftingRecipe(ItemSO item)
    {
        if (gameGlobal.GLOBAL_selectedObject != null)
        {
            if (!gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().isCrafting)
            {
                gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().crafting = item;
                gameGlobal.GLOBAL_selectedObject.GetComponent<Crafting>().TryToCraft();
            }
        }
    }
}
