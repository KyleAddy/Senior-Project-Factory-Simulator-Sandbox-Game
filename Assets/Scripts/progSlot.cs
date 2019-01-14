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

	public Image m_Image;
	public GameObject menu;
	public Button selectButton;
	//GameObject robot;
	public int index;

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {

		if (gameGlobal.GLOBAL_selectedObject != null)
			switch (gameGlobal.GLOBAL_selectedObject.GetComponent<robot>().progArray [index]) {
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
		}


		if(gameGlobal.GLOBAL_selectedIndex == index)
			selectButton.Select();  

	}

	public void selectIndex(){
		gameGlobal.GLOBAL_selectedIndex = index;
	}
		  


}
