using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCoin : MonoBehaviour {		//This script is similar to the Coin script, therefore, look to the Coin script for a more detailed explanation.

	public float rotationSpeed = 100.0f;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3(0, 0, rotationSpeed*Time.deltaTime));
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage ("RightPickup");		//The difference between this script and the coin script, is that there are two functions which messages are sent to. One of the functions is to monitor the number of right answers, the other is to monitor the number of questions answered.
			col.gameObject.SendMessage ("AnswerPickup");
			Destroy (gameObject);
		}
	}

}
