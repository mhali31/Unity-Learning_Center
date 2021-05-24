using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {		//this script is attached to DoorParent in the Hierarchy which is the entrance for the Learning Centre
	
	Animator animator;		//A private Animator component is called animator
	bool doorOpen;			//this checks whether we have already open the doors
	public GUIText textHints;	//A GUIText is needed to display text on the screen
	public AudioClip Door;	//AudioClip will be added in Unity to play a sound for the Door
	public AudioClip DoorLocked;	//AudioClip will be added to play the message for when the Player can't get into the building
	bool End;		//a private bool named End is used in this script


	// Use this for initialization
	void Start () {

		doorOpen = false;		//doorOpen is set to false which is when the door is not open
		animator = GetComponent<Animator>();		//this looks on the gameObject for the component Animator and assigns it to animator
		End = false;		//End is set to false at the start of the game
	}

	IEnumerator OnTriggerEnter(Collider col){		
		if (col.gameObject.tag == "Player" && Inventory.Door == 0) {	//when the GameObject tagged with Player collides with the door, and the counter Door is equal to zero the following occurs
			if (Inventory.coins == 3) {	//If the coins count in the inventory script is also set to 3, the doorOpen bool is set to true and the DoorControl Animation is set to Open.
				doorOpen = true;		
				DoorControl ("Open");	//in the DoorControl function, which can be seen below, the animator transitions from idle to open, using the trigger Open
				GetComponent<AudioSource> ().PlayOneShot (Door);	//the AudioClip Door is played
			} else if (Inventory.coins == 0 && End==false) {		//if the coins count is zero
				End = true;		//end is set to true, to prevent these commands from being implemented again when the Player enters the box collider
				GetComponent<AudioSource> ().PlayOneShot (DoorLocked);//the AudioClip Doorlocked is played from the AudioSource component
				textHints.SendMessage ("ShowHint", "The door is locked...you need answer 3 warm up questions to enter");	//a message appears on the screen using the GUIText attached to this script
				yield return new WaitForSeconds (7); 	//7 seconds wait time before the next instruction can be implemented
				textHints.SendMessage ("ShowHint", "The first one is behind the coffee shop opposite this building \n If you need assistance locating the next location, look at the map on the side of this building");	//a message appears on the screen using the GUIText attached to this script
				yield return new WaitForSeconds (7);	//7 seconds wait time before the next instruction can be implemented
				col.gameObject.SendMessage ("WarmUpQuestion");		//a message to is sent to the WarmUpQuestion function which is in the Inventory script connected to the PLayer
			}

		}
		if (col.gameObject.tag == "Player" && Inventory.Answer == 14) {		//if the Answer count is 14
			textHints.SendMessage ("ShowHint", "To exit the game, you need to go home!");		//a message is sent to the ShowHint function, in the textHints GUIText which is assigned in Unity. it will read out the message when the conditions above are met.
		
		}
			
	}



	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {	//when the Player leaves the trigger zone
			if (doorOpen) {		//and if the bool doopOpen is true
				doorOpen = false;		//doorOpen will be set to false
				DoorControl ("Close");	//the animation state transitions from DoorOpen to DoorClose using the Close trigger 
				GetComponent<AudioSource> ().PlayOneShot (Door);	//the Door AudioClip is played
			}
		}
	}

	void DoorControl(string direction)	//DoorControl will use the triggers in the animator component to go from one state to another. For example when this function is called in the OnTriggerEnter function with the string message Open, it will use the Open trigger in the animator to go from DoorIdle to DoorOpen state
	{
		animator.SetTrigger(direction);
	}
}
