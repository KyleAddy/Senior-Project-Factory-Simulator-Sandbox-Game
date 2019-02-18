using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robot : MonoBehaviour {

    [SerializeField] GameObject globalGameObj;
	public string action;
	Vector3 targPos;
	public float moveSpeed;
	string turnDir;
	float totalRot;
	float degreesPerSecond;
	public bool inAction = false;
	public bool isRunning = false;
	public GameObject robotCanvas;
	GameObject selectedInv;
	public Image progBar;

    bool movingForward = true;
    public bool forwardTrigger;
    public bool backwardTrigger;

	public string[] progArray = new string[25];
    public ItemSO[] itemSelectionArray = new ItemSO[25];
	public static int progLength;
	public int currentActionIndex = 0;

	public float progressSpeed = .1f;


	void Start () {
        globalGameObj = GameObject.Find("gameGlobal");

        progLength = 18;
		for (int i = 0; i < progArray.GetLength(0); i++)
			progArray[i] = "none";

		action = "none";
		targPos = transform.position;
		moveSpeed = 1f;
		turnDir = "none";
		totalRot = 0f;
		degreesPerSecond = 90f;


	}

	// Update is called once per frame
	void Update () {

		if (gameGlobal.GLOBAL_selectedObject == GetComponent<LocationInitiation>().objectID && gameGlobal.GLOBAL_selectedIndex >= progLength)
			gameGlobal.GLOBAL_selectedIndex = 0;
       
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
                        if (transform.rotation.eulerAngles.y < 5 || transform.rotation.eulerAngles.y > 355)
                            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                        else if (transform.rotation.eulerAngles.y < 95 && transform.rotation.eulerAngles.y > 85)
                            transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                        else if (transform.rotation.eulerAngles.y < 185 && transform.rotation.eulerAngles.y > 175)
                            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                        else if (transform.rotation.eulerAngles.y < 275 && transform.rotation.eulerAngles.y > 265)
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

	void forward(){
		if (action == "none") {
			
			targPos = transform.position;
			switch ((int)transform.rotation.eulerAngles.y) {

			case 0:
				targPos.z += gameGlobal.GLOBAL_gridCellSize;
				break;
			case 90:
				targPos.x += gameGlobal.GLOBAL_gridCellSize;
				break;
			case 180:
				targPos.z -= gameGlobal.GLOBAL_gridCellSize;
				break;
			case 270:
				targPos.x -= gameGlobal.GLOBAL_gridCellSize;
				break;
			}

			if ((int)targPos.x >= 0 && (int)targPos.x <= (gameGlobal.GLOBAL_worldX-1) && (int)targPos.z >= 0 && (int)targPos.z <= (gameGlobal.GLOBAL_worldZ-1)) {
				if (gameGlobal.GLOBAL_grid [(int)targPos.x, (int)targPos.z] == null) {
					action = "moving";
					gameGlobal.GLOBAL_grid [(int)targPos.x, (int)targPos.z] = GetComponent<LocationInitiation>().objectID;
					gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)transform.position.z] = null;
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
				targPos.z -= gameGlobal.GLOBAL_gridCellSize;
				break;
			case 90:
				targPos.x -= gameGlobal.GLOBAL_gridCellSize;
				break;
			case 180:
				targPos.z += gameGlobal.GLOBAL_gridCellSize;
				break;
			case 270:
				targPos.x += gameGlobal.GLOBAL_gridCellSize;
				break;
			}

			if ((int)targPos.x >= 0 && (int)targPos.x <= (gameGlobal.GLOBAL_worldX-1) && (int)targPos.z >= 0 && (int)targPos.z <= (gameGlobal.GLOBAL_worldZ-1)) {
				if (gameGlobal.GLOBAL_grid [(int)targPos.x, (int)targPos.z] == null) {
					action = "moving";
					gameGlobal.GLOBAL_grid [(int)targPos.x, (int)targPos.z] = GetComponent<LocationInitiation>().objectID;
					gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)transform.position.z] = null;
                    movingForward = false;
				} else
					targPos = transform.position;
			} else {
				Debug.Log ("destination is out of range");
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

	void findInventory(){ //serches the left, right, up, and down on the grid for an object that has an inventory (used for the deposite and withdraw function)
		switch ((int)transform.rotation.eulerAngles.y) {

		case 0:
                if (gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z + 1)] != null) 
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z + 1)].tag != "Untagged" && gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)].tag != "oreMine")
				selectedInv = gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z + 1)];
			break;
		case 90:
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x + 1, (int)(transform.position.z)] != null) 
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x + 1, (int)(transform.position.z)].tag != "Untagged" && gameGlobal.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)].tag != "oreMine")
				selectedInv = gameGlobal.GLOBAL_grid [(int)transform.position.x + 1, (int)(transform.position.z)];
			break;
		case 180:
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z - 1)] != null) 
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z - 1)].tag != "Untagged" && gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)].tag != "oreMine")
				selectedInv = gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)(transform.position.z - 1)];
			break;
		case 270:
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x - 1, (int)(transform.position.z)] != null) 
			if (gameGlobal.GLOBAL_grid [(int)transform.position.x - 1, (int)(transform.position.z)].tag != "Untagged" && gameGlobal.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)].tag != "oreMine")
				selectedInv = gameGlobal.GLOBAL_grid [(int)transform.position.x - 1, (int)(transform.position.z)];
			break;
		}
	}

    GameObject findOreMine()
    { //serches the left, right, up, and down on the grid for an object that has an inventory (used for the deposite and withdraw function)
        switch ((int)transform.rotation.eulerAngles.y)
        {

            case 0:
                if (gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)] != null)
                    if (gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)].tag == "oreMine")
                        return(selectedInv = gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z + 1)]);
                break;
            case 90:
                if (gameGlobal.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)] != null)
                    if (gameGlobal.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)].tag == "oreMine")
                        return(selectedInv = gameGlobal.GLOBAL_grid[(int)transform.position.x + 1, (int)(transform.position.z)]);
                break;
            case 180:
                if (gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)] != null)
                    if (gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)].tag == "oreMine")
                        return(selectedInv = gameGlobal.GLOBAL_grid[(int)transform.position.x, (int)(transform.position.z - 1)]);
                break;
            case 270:
                if (gameGlobal.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)] != null)
                    if (gameGlobal.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)].tag == "oreMine")
                        return(gameGlobal.GLOBAL_grid[(int)transform.position.x - 1, (int)(transform.position.z)]);
                break;
        }
        return (null);
    }


    void deposit(){
		findInventory ();
        int foundItemIndex = -1;
        int emptySlot = -1;

        if (selectedInv != null) {
			for (int i = 0; i < GetComponent<Inventory> ().invSize; i++) {
                
                if (GetComponent<Inventory> ().inventory [i] != null)
                    if (itemSelectionArray[currentActionIndex] == null){
                        foundItemIndex = i;
                    }else if (itemSelectionArray[currentActionIndex] == GetComponent<Inventory> ().inventory [i]) {
                        foundItemIndex = i;
                    }
				

				
			}
				if (foundItemIndex != -1)
                    emptySlot = globalGameObj.GetComponent<gameGlobal>().findEmptArraySlot(selectedInv.GetComponent<Inventory>().inventory, selectedInv.GetComponent<Inventory>().invSize);

                if (emptySlot != -1) {
					selectedInv.GetComponent<Inventory> ().inventory [emptySlot] = GetComponent<Inventory> ().inventory [foundItemIndex];
					GetComponent<Inventory> ().inventory [foundItemIndex] = null;
			    }
			}
        else 
        selectedInv = null;
			nextAction ();

		}

	void withdraw(){
		findInventory ();
		if (selectedInv != null) {
			int foundItemIndex = -1;
            int emptySlot = -1;

            for (int p = 0; p < selectedInv.GetComponent<Inventory>().invSize; p++) {
                if (selectedInv.GetComponent<Inventory> ().inventory [p] != null)
                    if (itemSelectionArray[currentActionIndex] == null){
                        foundItemIndex = p;
                    }else if (itemSelectionArray[currentActionIndex] == selectedInv.GetComponent<Inventory> ().inventory [p]) {
                        foundItemIndex = p;
                    }
			}

            if (foundItemIndex != -1)
                emptySlot = globalGameObj.GetComponent<gameGlobal>().findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
           
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
            emptySlot = globalGameObj.GetComponent<gameGlobal>().findEmptArraySlot(GetComponent<Inventory>().inventory, GetComponent<Inventory>().invSize);
            if (emptySlot != -1)
            {
                GetComponent<Inventory>().inventory[emptySlot] = oreMine.GetComponent<OreMine>().oreType;
            }

        }
        nextAction();
    }

}		
