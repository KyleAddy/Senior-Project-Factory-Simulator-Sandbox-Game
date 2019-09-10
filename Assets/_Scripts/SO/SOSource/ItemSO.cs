using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewItem", menuName ="ItemSO")]
public class ItemSO : ScriptableObject {

    [System.Serializable]
    public struct recipe
    {
        public ItemSO item;
        public int numOfItems;
    }

    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public GameObject itemPrefab;
    public GameObject itemBlueprint;

    public recipe[] craftingRecipe;
    public int numOfDifItems;

}
