using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnd : MonoBehaviour {		//this is attached to the Start GameObject and will be the first thing the Player will interact with in the game.

	bool Start1;		//a private bool called Start1
	public AudioClip Intro;		//An AudioClip attached to the script in Unity, which will introduce the user to the Game
	public GUITexture Texture;

	// Use this for initialization
	void Start () {
		Start1 = false;		//at the Start, Start1 will be set to false
		Texture.enabled = false;
	}
	
	IEnumerator OnTriggerEnter (Collider col){			//An IEnumerator is used to make use of WaitForSeconds
		if (col.gameObject.tag == "Player" && Start1 == false) {		//When the Player collides and Start1 is false then the following will occur
			yield return new WaitForSeconds (2);		//There will be a Wait time of 2 seconds before anything happens
			GetComponent<AudioSource> ().PlayOneShot (Intro);		//The Intro AudioClip will be played from the AudioSource
			Start1 = true;		//Start1 will be set to true. This occurs to prevent the introduction message from being played more than once.
			yield return new WaitForSeconds (4);
			Texture.enabled = true;
			yield return new WaitForSeconds (2);
			Texture.enabled = false;

		}
		if (col.gameObject.tag == "Player" && Inventory.Answer == 14) {		//when the Player collides and Answer, in the Inventory, is equal to 14 the following will occure
			yield return new WaitForSeconds (2);		//there will be an initial waiting period of 2 seconds
			Application.Quit ();		//The game will be ended. This will only occur when the game has been built. It should be noted that this is the only way to quit the game, you have to answer all 14 questions before this gets activated 
			Debug.Log ("Quit");		//to make sure this is working during testing, the debug.log was used so that the message Quit will appear on the console during GameMode
		}
	}

}
