using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewItem", menuName ="ItemSO")]
public class ItemSO : ScriptableObject {

    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
}
