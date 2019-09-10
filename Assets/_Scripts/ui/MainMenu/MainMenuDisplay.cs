using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuDisplay : MonoBehaviour
{
    [SerializeField]GameObject levelGenDisplay;
    [SerializeField] GameObject newLoadGameDisplay;
    // Start is called before the first frame update
    void Start()
    {
        disableLevelGenOptions();
        enableNewLoadGameDisplay();
    }

    public void disableLevelGenOptions()
    {
        levelGenDisplay.SetActive(false);
    }

    public void enableLevelGenOptions()
    {
        levelGenDisplay.SetActive(true);
    }

    public void disableNewLoadGameDisplay()
    {
        newLoadGameDisplay.SetActive(false);
    }

    public void enableNewLoadGameDisplay()
    {
        newLoadGameDisplay.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
