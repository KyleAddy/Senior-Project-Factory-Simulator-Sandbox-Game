using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialController : MonoBehaviour
{
    GameObject globalGameObj;
    [SerializeField] ItemSO empty;
    [SerializeField] ItemSO robot;
    [SerializeField] ItemSO storageBox;
    [SerializeField] GameObject copperOre;

    [SerializeField] GameObject forButton;
    [SerializeField] GameObject ifButton;
    [SerializeField] GameObject depositButon;
    [SerializeField] GameObject withdrawButton;
    [SerializeField] GameObject closeBraceButton;
    [SerializeField] GameObject mineButton;

    [SerializeField] float oreFallSpeed;
    bool oreIsFalling;
    GameObject oreToDrop;
    [SerializeField] GameObject impactParticle;

    [SerializeField] GameObject tutorialCanvas;

    [SerializeField] GameObject spaceBar;
    [SerializeField] TextMeshProUGUI tutorialText;

    bool pressedSpace = false;
    [SerializeField] int textNumber;
    [SerializeField] string[] tutorialDialogue;

    bool isDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        globalGameObj = GlobalVariables.gameManager;
        TutorialStart();
        tutorialText.text = tutorialDialogue[textNumber];
        PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        FallingOre();
    }

    void TutorialStart()
    {
        for (int i = 0; i < globalGameObj.GetComponent<Inventory>().inventory.Length; i++)
        {
            globalGameObj.GetComponent<Inventory>().inventory[i] = empty;
        }

        GlobalVariables.GLOBAL_worldX = 10;
        GlobalVariables.GLOBAL_worldZ = 10;
        forButton.SetActive(false);
        ifButton.SetActive(false);
        depositButon.SetActive(false);
        withdrawButton.SetActive(false);
        closeBraceButton.SetActive(false);
        mineButton.SetActive(false);
    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isDisabled)
            {
                isDisabled = false;
                tutorialCanvas.SetActive(true);
            }
            else
            {
                isDisabled = true;
                tutorialCanvas.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && !pressedSpace && !isDisabled)
        {
            NextStep();
        }
    }

    void NextStep()
    {
        textNumber++;
        tutorialText.text = tutorialDialogue[textNumber];//set tutorial text
        int emptyIndex = -1;

        switch (textNumber)
        {
            case 12://add robot to player inventory
                globalGameObj.GetComponent<Inventory>().inventory[0] = robot;
                break;

            case 19://activate the For and Close Brace programming blocks
                forButton.SetActive(true);
                closeBraceButton.SetActive(true);
                break;

            case 21://activate the Mine programming block
                mineButton.SetActive(true);
                break;

            case 23://drop ore down
                DropOre();
                break;

            case 25://drop ore down
                depositButon.SetActive(true);
                withdrawButton.SetActive(true);
                if (globalGameObj.GetComponent<Inventory>().inventory[0] != robot)
                {
                    globalGameObj.GetComponent<Inventory>().inventory[0] = storageBox;
                }
                else
                {
                    globalGameObj.GetComponent<Inventory>().inventory[1] = storageBox;
                }
                break;

            case 29://activate the Mine programming block
                ifButton.SetActive(true);
                break;

            case 32:
                print("tutorial finished, returning to main menu");
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }

    void DropOre()
    {
        int tempX = 0;
        int tempZ = 0;
        bool locationFound = false;
        while (!locationFound)
        {
            if (GameObject.Find("Player").transform.position.x > 4.5f)
            {
                tempX = Random.Range(3, 5);
            }
            else
            {
                tempX = Random.Range(6, 8);
            }

            if (GameObject.Find("Player").transform.position.z > 4.5f)
            {
                tempZ = Random.Range(3, 5);
            }
            else
            {
                tempZ = Random.Range(6, 8);
            }

            if (GlobalVariables.GLOBAL_grid[tempX,tempZ] == null)
            {
                locationFound = true;
            }
        }
        oreToDrop = Instantiate(copperOre, new Vector3(tempX, 10f, tempZ), Quaternion.identity);
        impactParticle.transform.position = new Vector3(oreToDrop.transform.position.x, .5f, oreToDrop.transform.position.z);
        oreIsFalling = true;
    }

    void FallingOre()
    {
        if (oreIsFalling)
        {
            if (oreToDrop.transform.position.y != 0)
            {
                oreToDrop.transform.position = Vector3.MoveTowards(oreToDrop.transform.position, new Vector3(oreToDrop.transform.position.x, 0, oreToDrop.transform.position.z), oreFallSpeed * Time.deltaTime);
            }
            else
            {
                impactParticle.GetComponent<ParticleSystem>().Play();
                oreIsFalling = false;
            }            
        }
    }
}
