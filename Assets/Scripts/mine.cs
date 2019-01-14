using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storage : MonoBehaviour {

	GameObject mineID;
	public string mineType = "none";


	// Use this for initialization
	void Start () {
		mineID = (GameObject)gameObject;
		gameGlobal.GLOBAL_grid [(int)transform.position.x, (int)transform.position.z] = mineID;

	}
}
