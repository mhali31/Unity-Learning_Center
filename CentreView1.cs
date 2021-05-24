using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreView1 : MonoBehaviour {		//CentreView1 is attached to the trigger for the notes (which only show one texture) for the First room in the Learning Centre. 
												//CentreView2 and CentreView3 are only slightly different to this script. NotesDoubleView1, NoteDoubleView2 and NoteDoubleView3 are similar, with only exception being that there are two GUITextures instead of one

	public GUITexture Texture;			//A texture is attached to this script in Unity
	bool time = false;					//a bool is used, and initially set to false, to make sure that the timer is active and inactive when it needs be.
	float timer = 0;					// a timer is used, which starts from zero, to count up to 10 seconds which is the minimum time a player needs to stay at the notes before it counts towards unlocking the door.
	bool Finish = false;				//a second bool is used to make sure that it is not possible for the Player to enter the trigger zone and make the Note this script is attached count more than once when it comes to unlocking the door.


	void Start(){
		Texture.enabled = false;		//The texture is not enabled at the start of the game, therefore is set to false.

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Welcome == 0) {	//When the player enters the trigger zone and the Welcome Message has finished (the Welcome counter increments by one at the start of the message and reverts back to zero once the message is over
			Texture.enabled = true;	//once the conditions above are met the texture is enabled
			time = true;	//the timer bool is set to true, which will be used in Update() function to increase the time

		} 
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {	//When the player leaves the trigger zone the texture is no longer enabled, therefore it is set to false.
			Texture.enabled = false;
			if (timer < 10) {			// if the timer does not reach 10 seconds
				timer = 0;				// it it set to zero
				time = false;			// and the time bool is set to false
				Debug.Log ("reset");	// for testing purposes, a message is sent to the console to let me know that it did not count towards unlocking the door 
			}	
			else if (timer >= 10) {		//if the timer has reach 10 seconds or above before the player leaves the trigger zone
				Debug.Log ("right");	//For testing purposes, a message is sent to the console to let me know that it has reached 10 seconds and will count towards unlocking the door to room 2
				col.gameObject.SendMessage ("Room1");		// A message is sent to the Room1 function in the Inventory Script to let it know to increase the counter by one
				time = false;			//the time bool is set back to false
				timer = 0;				//the timer is set to zero again
				Finish = true;			//and the Finish bool is used, and set to true. This will prevent the Update() function from increasing the time, which is the thing which prevents the notes this script is attached to being counted more than once, but also allowing the player to continue going back to the same notes.

			}

		}

	}
	void Update(){
		if(time==true && Finish == false){		//in the update function, if the time bool is true and only when the Finish bool is false will the timer be increased.
			timer += Time.deltaTime;
		}
	}
}

