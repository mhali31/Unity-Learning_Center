using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmUpQuestionApproach : MonoBehaviour {		//This script is attached to the WarmUpApproach GameObject and is used to inform the user how to answer the questions in the Game

	bool Question;		//a private bool named Question is used
	public AudioClip Approach;		//an AudioClip called Approach will be attached

	// Use this for initialization
	void Start () {
	 Question = false;		// at the start of the game, the Question bool is set to false
	}
	
	IEnumerator OnTriggerEnter (Collider col){		//to make use of the a wait time, IEnumerator is preferred over void
		if (col.gameObject.tag == "Player" && Inventory.Warmup == 1 && Question == false) {		//when the Player enters the trigger zone, Warmup=1 and the Question bool is false, the following will occur
			GetComponent<AudioSource> ().PlayOneShot (Approach);		//the Approach AudioClip will be played from the AudioSource component added to this GameObject
			Question = true;		//Question bool is set to true, which will prevent any event occur when the Player enters the GameObject again
			yield return new WaitForSeconds (12);		//a wait time of 12 seconds is set, to give enough time for the AudioClip to finish
			col.gameObject.SendMessage ("WarmUpStart");		//a message is sent to the WarmUpStart function in the Inventory script on the Player
			Destroy (this.gameObject);		//since this is no longer in use, the GameObject will be destroyed
		}
	}
			
}
