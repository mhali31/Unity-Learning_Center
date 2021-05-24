using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDoors4 : MonoBehaviour {	//This script is attached to the InsideDoorParent 4
	//this script is similar to the Doors script, therefore, for a more detail explanation look to the Doors script, especially if you want to understand how the animator was used
	Animator animator;
	bool InsideDoorOpen;
	public GUIText textHints;
	public AudioClip Door;

	void Start () {
		InsideDoorOpen = false;
		animator = GetComponent<Animator> ();
	}
		
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Answer == 14) {//the conditions that need to be met for the door to open are the Player entering the trigger zone and Answer equalling 14

			Debug.Log ("Open");
			InsideDoorOpen = true;
			InsideDoor ("Open");
			GetComponent<AudioSource> ().PlayOneShot (Door);
		}else if (col.gameObject.tag == "Player") {//if the Player approaches the door without any other conditions, it will trigger a message to be displayed on the screen using the GUIText
			textHints.SendMessage ("ShowHint", "The door won't open!!! \n Answer all the Questions before you can leave");
		}
	}
	void OnTriggerExit(Collider col){
		if (InsideDoorOpen) {
			InsideDoorOpen = false;
			InsideDoor ("Close");
			GetComponent<AudioSource> ().PlayOneShot (Door);
		}
	}

	void InsideDoor(string direction){
		animator.SetTrigger(direction);
	}
}
