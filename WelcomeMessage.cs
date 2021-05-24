using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeMessage : MonoBehaviour {		//this script is attached to the Welcome GameObject and is used to instruct the user on what to do in the learning centre

	public GUIText textHints;		//A GUIText is needed to text on the screen
	bool Message = false;		//the Message bool is initally set to false
	public AudioClip WMessage;	//an AudioClip with the Welcome message will be attached in Unity

	IEnumerator OnTriggerEnter(Collider col){		//IEnumerator is used to make use of the wait time
		if (col.gameObject.tag == "Player" && Message == false) {	//when the Player collides and Message is false, then the following will occur
			//col.gameObject.SendMessage ("Terrain");
			Message = true;			//the bool is set to true, preventing this function from occuring again
			col.gameObject.SendMessage ("DoorLock");		//the DoorLock function will be activated
			col.gameObject.SendMessage ("WelcomeStart");	//the WelcomeStart function will be activated.
			GetComponent<AudioSource> ().PlayOneShot (WMessage); //the WMessage AudioCLip will be played from the AudioSource of this GameObject, along with text instruction appearing on the screen using the GUIText attached
			textHints.SendMessage ("ShowHint", "Welcome to your lesson Behavioural Economics \n The Entrance to the building is now locked until you have visited all 4 rooms and completed the test");
			yield return new WaitForSeconds (7); 	//7 seconds waiting period before next instruction can be implemented
			textHints.SendMessage ("ShowHint", "The first three rooms consist of videos and notes about different topics in this subject area");
			yield return new WaitForSeconds (7);	//7 seconds waiting period before next instruction can be implemented
			textHints.SendMessage ("ShowHint", "To watch the videos stand on the play button and look towards the wall it is facing.\n WHEN YOU LEAVE THE PLAY BUTTON THE VIDEO WILL RESET!");
			yield return new WaitForSeconds (7);	//7 seconds waiting period before next instruction can be implemented
			textHints.SendMessage ("ShowHint", "To Read the Notes by walking up to them. To proceed through the rooms you don't need to watch and read everything");
			yield return new WaitForSeconds (7);	//7 seconds waiting period before next instruction can be implemented
			textHints.SendMessage ("ShowHint", "The bare minimum is to stay for 10 seconds at 6 learning locations in each room. \n Doing this will open the door to the next room");
			yield return new WaitForSeconds (7);	//7 seconds waiting period before next instruction can be implemented
			textHints.SendMessage ("ShowHint", "But, if you want to do well in the test, take your time.\n The final room is the Test. \n YOU WON'T BE ABLE TO LEAVE UNTIL THE TEST IS COMPLETE");
			yield return new WaitForSeconds (9);	//9 seconds waiting period before next instruction can be implemented
			col.gameObject.SendMessage ("WelcomeEnd"); //the WelcomeEnd function will be activated. WelcomeEnd, WelcomeStart and DoorLock are all present in the Inventory script on the Player
			textHints.SendMessage ("ShowHint", "You may begin");		//a message displayed on the screen by the GUIText
			yield return new WaitForSeconds (2);	//2 second waiting period before next instructioN
			Destroy (this.gameObject);		//The GameObject this script is attached to is destroyed as it is not longer in use.
		}
	}
}
