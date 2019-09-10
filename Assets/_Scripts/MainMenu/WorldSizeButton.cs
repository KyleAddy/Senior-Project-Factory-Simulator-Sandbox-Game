using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//when button is clicked this script will set the color of the other buttons to the nonSelected Color and then will set the button clicked to the selected color
public class WorldSizeButton : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;

    [SerializeField] Color selectedColor;
    [SerializeField] Color nonSelectedColor;

    public void UpdateWorldSizeButtonSelection()
    {
        GetComponent<Image>().color = selectedColor;
        button1.GetComponent<Image>().color = nonSelectedColor;
        button2.GetComponent<Image>().color = nonSelectedColor;
    }
}
