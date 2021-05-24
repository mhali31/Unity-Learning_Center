using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {		//this script is attached to the CoinPrefab which will be Instantiated after the correct answer is selected in the Warm Up questions
									//this script is similar to the RightCoin and WrongCoin scripts
	public float rotationSpeed = 100.0f; //the rotation speed has been set as a public float so it can be adjusted in the inspector if needed.

	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (new Vector3(0, 0, rotationSpeed*Time.deltaTime));	//the coin will rotate in the z axis by 100 degrees in each frame as long as it still set to 100.0f
	}

	void OnTriggerEnter(Collider col){		
		if (col.gameObject.tag == "Player") {	//when the FPSController (which is tagged with Player) enters the trigger zone 
			col.gameObject.SendMessage ("CoinPickup"); 	//a message will be sent to the inventory script to a function called CoinPickup. The inventory Script is attached to the FPSController

			Destroy (gameObject);	//the Coin will then be destroyed

		}
	}

}

