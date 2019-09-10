using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField] GameEvent saveGame;
    [SerializeField] GameObject quitButton;
    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "World_Tutorial")
        {
            quitButton.GetComponent<TextMeshProUGUI>().text = "Quit";
        }
    }
    public void SaveAndQuit()
    {
        if (SceneManager.GetActiveScene().name != "World_Tutorial")
        {
            saveGame.Raise();
        }
        Time.timeScale = 1;
        QuitWorld();
    }

    public void QuitWorld()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
