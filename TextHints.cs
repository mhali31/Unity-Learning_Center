using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHints : MonoBehaviour {		//TextHints is attached to the GUIText GameObject. This is responsible for displaying all the messages on the screen
											//This script was initially created for the Survival Island game, but has been adapted to suit the needs of this interactive world

	float timer = 0.0f;		//a private float called timer is set to zero


	void Update () {
		if (GetComponent<GUIText>().enabled) {		//When the GUIText the timer will be increased in seconds
			timer += Time.deltaTime;

			if (timer >= 7) {		//when timer is greater than or equal to 7
				GetComponent<GUIText>().enabled = false;		//the GUIText component will no longer be enabled as it is set to false.
				timer = 0.0f;	//the timer is reset to zero
			}
		}

	}
	public void ShowHint (string message){		//this has been made public as it needs to be accessed by other scripts. This function will receive messages from other scripts via the SendMessage command.
		GetComponent<GUIText>().text = message;			//the text parameter of the GUIText has been set up so that sentence string is what is received by the argument (message).
		if (!GetComponent<GUIText>().enabled) {			//The GUIText component will be set to true, whenever a message has been received from another script
			GetComponent<GUIText>().enabled = true; 
		}
	}


}
