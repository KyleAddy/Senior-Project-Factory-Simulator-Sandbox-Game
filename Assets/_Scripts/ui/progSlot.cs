using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progSlot : MonoBehaviour {

	public Sprite upArrow;
	public Sprite downArrow;
	public Sprite leftArrow;
	public Sprite rightArrow;
	public Sprite none;
	public Sprite repeat;
	public Sprite deposit;
	public Sprite withdraw;
    public Sprite mine;
    public Sprite forLoop;
    public Sprite ifStatement;
    public Sprite closeBrace;

    public Sprite f1;
    public Sprite f2;
    public Sprite f3;
    public Sprite f4;
    public Sprite f5;


    public Image m_Image;
	public GameObject menu;
	public Button selectButton;
	//GameObject robot;
	public int index;

    // Update is called once per frame
    void Update () {
        

		if (GlobalVariables.GLOBAL_selectedObject != null)
        {
            if (GlobalVariables.GLOBAL_selectedObject.CompareTag("robot"))
            {
                switch (GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[index].action)
                {
                    case "forward":
                        m_Image.sprite = upArrow;
                        break;

                    case "backward":
                        m_Image.sprite = downArrow;
                        break;

                    case "left":
                        m_Image.sprite = leftArrow;
                        break;

                    case "right":
                        m_Image.sprite = rightArrow;
                        break;

                    case "none":
                        m_Image.sprite = none;
                        break;

                    case "repeat":
                        m_Image.sprite = repeat;
                        break;

                    case "deposit":
                        m_Image.sprite = deposit;
                        break;

                    case "withdraw":
                        m_Image.sprite = withdraw;
                        break;

                    case "mine":
                        m_Image.sprite = mine;
                        break;

                    case "for":
                        m_Image.sprite = forLoop;
                        break;

                    case "if":
                        m_Image.sprite = ifStatement;
                        break;

                    case "closeBrace":
                        m_Image.sprite = closeBrace;
                        break;

                    case "function1":
                        m_Image.sprite = f1;
                        break;

                    case "function2":
                        m_Image.sprite = f2;
                        break;

                    case "function3":
                        m_Image.sprite = f3;
                        break;

                    case "function4":
                        m_Image.sprite = f4;
                        break;

                    case "function5":
                        m_Image.sprite = f5;
                        break;
                }
                if(GlobalVariables.GLOBAL_selectedObject.GetComponent<robot>().robotProgram[index].action == null)
                {
                    m_Image.sprite = none;
                }
            }
            else if (GlobalVariables.GLOBAL_selectedObject.CompareTag("computer"))
            {
                switch (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, index].action)
                {
                    case "forward":
                        m_Image.sprite = upArrow;
                        break;

                    case "backward":
                        m_Image.sprite = downArrow;
                        break;

                    case "left":
                        m_Image.sprite = leftArrow;
                        break;

                    case "right":
                        m_Image.sprite = rightArrow;
                        break;

                    case "none":
                        m_Image.sprite = none;
                        break;

                    case "repeat":
                        m_Image.sprite = repeat;
                        break;

                    case "deposit":
                        m_Image.sprite = deposit;
                        break;

                    case "withdraw":
                        m_Image.sprite = withdraw;
                        break;

                    case "mine":
                        m_Image.sprite = mine;
                        break;

                    case "for":
                        m_Image.sprite = forLoop;
                        break;

                    case "if":
                        m_Image.sprite = ifStatement;
                        break;

                    case "closeBrace":
                        m_Image.sprite = closeBrace;
                        break;

                    case "function1":
                        m_Image.sprite = f1;
                        break;

                    case "function2":
                        m_Image.sprite = f2;
                        break;

                    case "function3":
                        m_Image.sprite = f3;
                        break;

                    case "function4":
                        m_Image.sprite = f4;
                        break;

                    case "function5":
                        m_Image.sprite = f5;
                        break;
                }

                if (RobotPlayerFunctions.playerFunctions[RobotPlayerFunctions.selectedFunction, index].action == null)
                {
                    m_Image.sprite = none;
                }
            }
        }
            
			

		if(GlobalVariables.GLOBAL_selectedIndex == index)
        {
            selectButton.Select();
        }
    }

	public void selectIndex(){
		GlobalVariables.GLOBAL_selectedIndex = index;
	}
}
