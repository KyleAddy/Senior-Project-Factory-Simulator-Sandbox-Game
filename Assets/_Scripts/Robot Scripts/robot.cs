using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robot : MonoBehaviour {

    [SerializeField] GameObject globalGameObj;
	public string action = "none";
	public Vector3 targPos = new Vector3(.5f,0,0);
    public Vector3 gridCoords;
	public float moveSpeed;
	public string turnDir = "none";
	public float totalRot = 0f;
	float degreesPerSecond;
	public bool inAction = false;
	public bool isRunning = false;
	public GameObject robotCanvas;
	GameObject selectedInv;
	public Image progBar;

    public bool movingForward = true;
    public bool forwardTrigger;
    public bool backwardTrigger;

	public string[] progArray = new string[25];
    public ItemSO[] itemSelectionArray = new ItemSO[25];
	[SerializeField] public int progLength;
	public int currentActionIndex = 0;

	public float progressSpeed = .1f;

    /////////////////for loop code

    public struct forLoop
    {
        public int numToLoop;
        public int numLeftToLoop;
        public bool isActive;
    }

    //keeps the info for each for loop
    //could make this 23 since you cant have a for loop at the end where it does something and is balanced
    [SerializeField]
    public forLoop[] loop = new forLoop[25];

    [SerializeField]
    public Stack<int> currentStatement = new Stack<int>();


    [SerializeField]
    public string[] ifCondition = new string[25];

    public bool[] toggleIfConditionOutput = new bool[25];

    public int[] ifCountAmount = new int[25];

   

    //////////////////////////


	void Start () {
        globalGameObj = GlobalVariables.gameManager;

        if (gridCoords.x == .5f)
        {
            gridCoords = new Vector3(transform.position.x, .5f, transform.position.z);
        }

        
		for (int i = 0; i < progArray.GetLength(0); i++)
        {
            if (progArray[i] == "")
            {
                progArray[i] = "none";
            }
        }			
        if(action == "")
        {
            action = "none";
        }		


        if (GetComponent<LocationInitiation>().loadedIn)
        {
            for (int i = 0; i < 25; i++)
            {
                ifCountAmount[i] = 0;
            }
        }
		moveSpeed = 1f;
		degreesPerSecond = 90f;
	}

	// Update is called once per frame
	void Update () {

		if (GlobalVariables.GLOBAL_selectedObject == GetComponent<LocationInitiation>().objectID && GlobalVariables.GLOBAL_selectedIndex >= progLength) //sets the selected Index to 0 once it reaches the end of the available programming blocks
			GlobalVariables.GLOBAL_selectedIndex = 0;
       
        setAction();

        performingAction();
    }

    void setAction()
    {
        //setting the action
        if (!inAction && isRunning)
            switch (progArray[currentActionIndex])
            {

                case "forward":
                    inAction = true;
                    forward();
                    break;

                case "backward":
                    inAction = true;
                    backward();
                    break;

                case "right":
                    inAction = true;
                    turnRight();
                    break;

                case "left":
                    inAction = true;
                    turnLeft();
                    break;

                case "none":
                    nextAction();
                    break;

                case "repeat":
                    action = "none";
                    currentActionIndex = 0;
                    break;

                case "deposit":
                    inAction = true;
                    action = "deposit";
                    setProgBar(1f);
                    break;

                case "withdraw":
                    inAction = true;
                    action = "withdraw";
                    setProgBar(1f);
                    break;

                case "mine":
                    inAction = true;
                    action = "mine";
                    setProgBar(1f);
                    break;

                case "for":
                    AddStatement();
                    break;

                case "if":
                    IfConditions(ifCondition[currentActionIndex]);
                    break;

                case "closeBrace":
                    EndBrace();
                    break;


            }
    }

    void performingAction()
    {
        //performing the action
        if (action != "none")
        {

            switch (action)
            {

                case "moving":
                    if (targPos == transform.position)
                    {
                        gridCoords = new Vector3(transform.position.x, 0, transform.position.z);
                        nextAction();
                    }
                    else
                    {
                        if (movingForward)
                        {
                            if(!forwardTrigger)
                                transform.position = Vector3.MoveTowards(transform.position, targPos, moveSpeed * Time.deltaTime);
                        }
                        else {
                            if (!backwardTrigger)
                                transform.position = Vector3.MoveTowards(transform.position, targPos, moveSpeed * Time.deltaTime);
                        }
                        
                    }
                    break;

                case "turning":
                    if (totalRot < 90f)
                    { //rotate the robot a few degrees at a timeuntil totalRot is at least 90
                        if (turnDir == "left")
                        {
                            float currentAngle = transform.rotation.eulerAngles.y;
                            transform.rotation = Quaternion.AngleAxis(currentAngle - (Time.deltaTime * degreesPerSecond), Vector3.up);
                            totalRot += Time.deltaTime * degreesPerSecond;
                        }
                        else if (turnDir == "right")
                        {
                            float currentAngle = transform.rotation.eulerAngles.y;
                            transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * degreesPerSecond), Vector3.up);
                            totalRot += Time.deltaTime * degreesPerSecond;
                        }

                    }
                    else
                    { //sets the rotation to exactly 0, 90, 180 or 270 depending on if its rotation is within 5 deg
                        if (transform.rotation.eulerAngles.y < 10 || transform.rotation.eulerAngles.y > 350)
                            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                        else if (transform.rotation.eulerAngles.y < 100 && transform.rotation.eulerAngles.y > 80)
                            transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                        else if (transform.rotation.eulerAngles.y < 190 && transform.rotation.eulerAngles.y > 170)
                            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                        else if (transform.rotation.eulerAngles.y < 280 && transform.rotation.eulerAngles.y > 260)
                            transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
                        totalRot = 0;
                        nextAction();
                        turnDir = "none";
                    }
                    break;

                case "deposit":
                    if (progBar.fillAmount < 1)
                        progBar.fillAmount += progressSpeed * Time.deltaTime;
                    else
                    {
                        inAction = false;
                        robotCanvas.SetActive(false);
                        deposit();
                    }
                    break;

                case "withdraw":
                    if (progBar.fillAmount < 1)
                        progBar.fillAmount += progressSpeed * Time.deltaTime;
                    else
                    {
                        inAction = false;
                        robotCanvas.SetActive(false);
                        withdraw();
                    }
                    break;

                case "mine":
                    if (progBar.fillAmount < 1)
                        progBar.fillAmount += progressSpeed * Time.deltaTime;
                    else
                    {
                        inAction = false;
                        robotCanvas.SetActive(false);
                        Mine();
                    }
                    break;

            }
        }
    }

	void nextAction(){
		action = "none";
		inAction = false;
		currentActionIndex++;
		if (currentActionIndex >= progLength) {
			currentActionIndex = 0;
			isRunning = false;
		}
	}

    void EndBrace()
    {
        if (currentStatement.Count == 0)//check to see to the stack is empty
        {
            currentActionIndex++;
            return;
        }
        
        if (progArray[currentStatement.Peek()] == "for")
        {
            if (loop[currentStatement.Peek()].numLeftToLoop <= 0)//check to see if the for loop has looped the needed amount of times
            {
                currentStatement.Pop();//remove it from the stack
                nextAction();
                return;
            }
            loop[currentStatement.Peek()].numLeftToLoop--;//decrement the number of times needed to loop by 1
            currentActionIndex = (currentStatement.Peek() + 1);//change the currentActionIndex to the start of the loop 
            return;
        } 

        if (progArray[currentStatement.Peek()] == "if")
        {
            nextAction();
        }



    }

    void AddStatement()
    {
        currentStatement.Push(currentActionIndex);//push the current loop to the stack
        if (progArray[currentActionIndex] == "for")
        {
            loop[currentActionIndex].numLeftToLoop = (loop[currentActionIndex].numToLoop - 1); //set the needed times to loop
        }
        nextAction();
    }

    //check If Condition is passed
    void IfConditions(string condition)
    {
        GameObject adjacentInv = null;
        bool conditionPassed = false;
        switch (condition)
        {
            case "invEmpty":
                conditionPassed = GlobalFunctions.CheckIfItemSoArrayIsEmpty(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
                break;

            case "invFull":
                conditionPassed = GlobalFunctions.CheckIfItemSoArrayIsFull(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
                break;

            case "AdjacentInvEmpty":
                 adjacentInv = findInventory();
                if (adjacentInv != null)
                {
                    conditionPassed = GlobalFunctions.CheckIfItemSoArrayIsEmpty(adjacentInv.GetComponent<Inventory>().inventory, adjacentInv.GetComponent<Inventory>().invSize);
                }
                break;

            case "AdjacentInvFull":
                 adjacentInv = findInventory();
                if (adjacentInv != null)
                {
                    conditionPassed = GlobalFunctions.CheckIfItemSoArrayIsFull(adjacentInv.GetComponent<Inventory>().inventory, adjacentInv.GetComponent<Inventory>().invSize);
                }                     
                break;

            case "RobotXEmptySlots":
                conditionPassed = GlobalFunctions.CheckItemSoArrayForXEmptySlots(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize, ifCountAmount[currentActionIndex]);
                break;

            case "AdjacentInvXEmptySlots":
                adjacentInv = findInventory();
                if (adjacentInv != null)
                {
                    conditionPassed = GlobalFunctions.CheckItemSoArrayForXEmptySlots(adjacentInv.GetComponent<Inventory>().inventory, adjacentInv.GetComponent<Inventory>().invSize, ifCountAmount[currentActionIndex]);
                }
                break;
        }

        if (toggleIfConditionOutput[currentActionIndex])
        {
            conditionPassed = !conditionPassed;
        }

        if (conditionPassed)
        {
            nextAction();
        }
        else
        {
            for(int i = currentActionIndex; i < progLength; i++)
            {
                if(progArray[i] == "closeBrace")
                {
                    currentActionIndex = i;
                    nextAction();
                    return;
                }
            }
        }

    }


    void forward(){
		if (action == "none") {
			
			targPos = transform.position;
			switch ((int)transform.rotation.eulerAngles.y) {

			case 0:
				targPos.z += GlobalVariables.GLOBAL_gridCellSize;
				break;
			case 90:
				targPos.x += GlobalVariables.GLOBAL_gridCellSize;
				break;
			case 180:
				targPos.z -= GlobalVariables.GLOBAL_gridCellSize;
				break;
			case 270:
				targPos.x -= GlobalVariables.GLOBAL_gridCellSize;
				break;
			}

			if ((int)targPos.x >= 0 && (int)targPos.x <= (GlobalVariables.GLOBAL_worldX-1) && (int)targPos.z >= 0 && (int)targPos.z <= (GlobalVariables.GLOBAL_worldZ-1)) {
				if (GlobalVariables.GLOBAL_grid [(int)targPos.x, (int)targPos.z] == null) {
					action = "moving";
					GlobalVariables.GLOBAL_grid [(int)targPos.x, (int)targPos.z] = GetComponent<LocationInitiation>().objectID;
					GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)transform.position.z] = null;
                    movingForward = true;
				} else {
					targPos = transform.position;
					nextAction ();
				}
			} else {
				targPos = transform.position;
				nextAction();
			}
		}
	}

	void backward (){
		if (action == "none") {

			targPos = transform.position;
			switch ((int)transform.rotation.eulerAngles.y) {

			case 0:
				targPos.z -= GlobalVariables.GLOBAL_gridCellSize;
				break;
			case 90:
				targPos.x -= GlobalVariables.GLOBAL_gridCellSize;
				break;
			case 180:
				targPos.z += GlobalVariables.GLOBAL_gridCellSize;
				break;
			case 270:
				targPos.x += GlobalVariables.GLOBAL_gridCellSize;
				break;
			}

			if ((int)targPos.x >= 0 && (int)targPos.x <= (GlobalVariables.GLOBAL_worldX-1) && (int)targPos.z >= 0 && (int)targPos.z <= (GlobalVariables.GLOBAL_worldZ-1)) {
				if (GlobalVariables.GLOBAL_grid [(int)targPos.x, (int)targPos.z] == null) {
					action = "moving";
					GlobalVariables.GLOBAL_grid [(int)targPos.x, (int)targPos.z] = GetComponent<LocationInitiation>().objectID;
					GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)transform.position.z] = null;
                    movingForward = false;
				} else
					targPos = transform.position;
			} else {
				targPos = transform.position;
				nextAction();
			}
		}
	}

	void turnLeft (){
		if (action == "none") {
			action = "turning";
			turnDir = "left";
		}
		
	}

	void turnRight(){
		if (action == "none") {
			action = "turning";
			turnDir = "right";
		}
	}

	void setProgBar(float speed){
		robotCanvas.SetActive (true);
		progBar.fillAmount = 0;
		progressSpeed = speed;
	}

	GameObject findInventory(){ //serches the left, right, up, and down on the grid for an object that has an inventory, direction depends on robots (used for the deposite and withdraw function)
		switch ((int)transform.rotation.eulerAngles.y) {

		case 0:
                if (GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z + 1)] != null) 
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z + 1)].tag != "Untagged" && GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)].tag != "oreMine")
				return GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z + 1)];
			break;
		case 90:
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x + 1, (int)(transform.position.z)] != null) 
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x + 1, (int)(transform.position.z)].tag != "Untagged" && GlobalVariables.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)].tag != "oreMine")
				return GlobalVariables.GLOBAL_grid [(int)transform.position.x + 1, (int)(transform.position.z)];
			break;
		case 180:
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z - 1)] != null) 
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z - 1)].tag != "Untagged" && GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)].tag != "oreMine")
				return GlobalVariables.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z - 1)];
			break;
		case 270:
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x - 1, (int)(transform.position.z)] != null) 
			if (GlobalVariables.GLOBAL_grid [(int)transform.position.x - 1, (int)(transform.position.z)].tag != "Untagged" && GlobalVariables.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)].tag != "oreMine")
				return GlobalVariables.GLOBAL_grid [(int)transform.position.x - 1, (int)(transform.position.z)];
			break;
		}
        return null;
	}

    GameObject findOreMine()
    { //serches the left, right, up, and down on the grid for an object that has an inventory, if onbject is found then it returns the object else it returns null (used for the deposite and withdraw function)
        switch ((int)transform.rotation.eulerAngles.y)
        {

            case 0:
                if (GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)] != null)
                    if (GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)].tag == "oreMine")
                        return(selectedInv = GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)]);
                break;
            case 90:
                if (GlobalVariables.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)] != null)
                    if (GlobalVariables.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)].tag == "oreMine")
                        return(selectedInv = GlobalVariables.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)]);
                break;
            case 180:
                if (GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)] != null)
                    if (GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)].tag == "oreMine")
                        return(selectedInv = GlobalVariables.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)]);
                break;
            case 270:
                if (GlobalVariables.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)] != null)
                    if (GlobalVariables.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)].tag == "oreMine")
                        return(GlobalVariables.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)]);
                break;
        }
        return (null);
    }


    void deposit(){
		selectedInv = findInventory ();
        int foundItemIndex = -1;
        int emptySlot = -1;

        if (selectedInv != null) {            
			for (int i = 0; i < GetComponent<Inventory>().invSize; i++) {//iterate through the robots inventory            
                if (GetComponent<Inventory>().inventory[i] != null) {//if the inventory slot is not empty
                    if (itemSelectionArray[currentActionIndex] == null || itemSelectionArray[currentActionIndex].itemName == "") {//if there is no selected item then set foundItemIndex
                        foundItemIndex = i;
                    }
                    else if (itemSelectionArray[currentActionIndex] == GetComponent<Inventory>().inventory[i]){//if the itemselected is the same as the item found then set foundItemIndex
                        foundItemIndex = i;
                    }
                }
			}

			if (foundItemIndex != -1)
            {
                emptySlot = GlobalFunctions.findEmptArraySlot(selectedInv.GetComponent<Inventory>().inventory, selectedInv.GetComponent<Inventory>().invSize);
            }

            if (emptySlot != -1) {
				selectedInv.GetComponent<Inventory> ().inventory [emptySlot] = GetComponent<Inventory> ().inventory [foundItemIndex];
				GetComponent<Inventory> ().inventory [foundItemIndex] = null;
			}

            nextAction();
        }
        else
        {
            nextAction();
        }

    }

	void withdraw(){
        selectedInv = findInventory ();

        int foundItemIndex = -1;
        int emptySlot = -1;
        if (selectedInv != null) {			

            for (int p = 0; p < selectedInv.GetComponent<Inventory>().invSize; p++) {//iterate through the robots inventory
                if (selectedInv.GetComponent<Inventory>().inventory[p] != null)
                {//if the inventory slot is not empty

                    if (itemSelectionArray[currentActionIndex] == null)
                    {//if there is no selected item then set foundItemIndex
                        foundItemIndex = p;
                    }
                    else if (itemSelectionArray[currentActionIndex].itemName == "")//if the item is empty then set foundItemIndex
                    {
                        foundItemIndex = p;
                    }
                    else if (itemSelectionArray[currentActionIndex] == selectedInv.GetComponent<Inventory>().inventory[p])
                    {//if the itemselected is the same as the item found then set foundItemIndex
                        foundItemIndex = p;
                    }
                }
			}

            if (foundItemIndex != -1)
            {
                emptySlot = GlobalFunctions.findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
            }

            if (emptySlot != -1) {
					GetComponent<Inventory> ().inventory [emptySlot] = selectedInv.GetComponent<Inventory> ().inventory [foundItemIndex];
					selectedInv.GetComponent<Inventory> ().inventory [foundItemIndex] = null;
				}
		}
		selectedInv = null;
		nextAction ();

	}

    void Mine()
    {
        GameObject oreMine;
        oreMine = findOreMine();
        int emptySlot = -1;
        
        if (oreMine != null)
        {
            emptySlot = GlobalFunctions.findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
            if (emptySlot != -1)
            {
                GetComponent<Inventory>().inventory[emptySlot] = oreMine.GetComponent<OreMine>().oreType;
            }

        }
        nextAction();
    }

     bool CheckProgramBalance()
    {
        int counter = 0;
        for(int i = 0; i < GetComponent<robot>().progArray.Length; i++)
        {
            if (GetComponent<robot>().progArray[i] == "for" || GetComponent<robot>().progArray[i] == "if")
            {
                counter++;
            }
            if (GetComponent<robot>().progArray[i] == "closeBrace")
            {
                counter--;
            }
        }
        if (counter == 0)
        {
            return true;
        }
        return false;
    }

    public void runCode()
    {
        if (CheckProgramBalance())
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

}		
