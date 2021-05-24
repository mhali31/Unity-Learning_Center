using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {		//this script is attached to the Test GameObject. it will be activated when the Player enters the final room.

	public GUIText textHints;		//A GUIText is required, therefore it will be attached in unity
	bool TestEnter;					//a private bool TestEnter is needed
	public AudioClip TestIntro;		//The AudioClip TestIntro will be added to this script

	// Use this for initialization
	void Start () {
		TestEnter = false;		//TestEnter bool is initally set to false.
	}
	


	IEnumerator OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player" && TestEnter == false) {		//when the Player collides with this GameObject and TestEnter is false.
			TestEnter = true;			//TestEnter is set to true, preventing the Player interacting which this GameObject again
			GetComponent<AudioSource> ().PlayOneShot (TestIntro);			//The AudioCLip TestIntro will be played once from the AudioSource
			col.gameObject.SendMessage ("TestRoomEnter");			//A message will be sent to the TestRoomEnter function, which is in the Inventory script on the Player. This will lock the Door for Room 3 and prevent the user from leaving the room until they have completed the test
			yield return new WaitForSeconds (22);			//there will be waiting period of 22 seconds before the next instruction is carried out
			col.gameObject.SendMessage ("TestStart");		//a message will be sent to the TestStart function, which is in the Inventory script on the Player. This will prevent the user from starting the test until the instructions in the AudioClip has finished.
			textHints.SendMessage ("ShowHint", "Go to Question 1");	//a message will be displayed on the screen
		}
	}
}
