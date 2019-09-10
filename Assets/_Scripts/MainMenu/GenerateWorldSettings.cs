using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateWorldSettings : MonoBehaviour
{

    public float ironOreSpawnPercent = 100;
    public float copperOreSpawnPercent = 100;

    [SerializeField] GameObject ironOreSpawnPercentDisplay;
    [SerializeField] GameObject copperOreSpawnPercentDisplay;

    public string worldSize;

    // Start is called before the first frame update
    void Start()
    {
        worldSize = "small";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOrePercentDisplays();
    }

    void UpdateOrePercentDisplays()//update ore percent displays
    {
        ironOreSpawnPercentDisplay.GetComponent<TextMeshProUGUI>().text = ironOreSpawnPercent.ToString() + "%";
        copperOreSpawnPercentDisplay.GetComponent<TextMeshProUGUI>().text = copperOreSpawnPercent.ToString() + "%";
    }

    public void AdjustIronOreSpawnPercent(float percent)//set iron ore spawn percent 
    {
        ironOreSpawnPercent = percent;
    }

    public void AdjustCopperOreSpawnPercent(float percent)//set copper ore spawn percent
    {
        copperOreSpawnPercent = percent;
    }

    public void SetWorldSize(string size)//set world size
    {
        worldSize = size;
    }

    public void GenerateWorld()
    {
        GlobalVariables.worldSize = worldSize;//set the world size
        GlobalVariables.ironOrePercent = ironOreSpawnPercent;//set the iron spawn percent
        GlobalVariables.copperOrePercent = copperOreSpawnPercent;//set the copper spawn percent
        GetComponent<LoadLevel>().newGame();//load world sccene
    }
}
