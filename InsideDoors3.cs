using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDoors3 : MonoBehaviour {	//This script is attached to the InsideDoorParent 3
	//this script is similar to the Doors script, therefore, for a more detail explanation look to the Doors script, especially if you want to understand how the animator was used
	Animator animator;
	bool InsideDoorOpen;
	public GUIText textHints;
	public AudioClip Door;

	void Start () {
		InsideDoorOpen = false;
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Count3 >= 6 && Inventory.TestDoor == 0) {//the conditions that need to be met for the door to open are the Player entering the trigger zone, Count3 being greater or equal to 6 and TestDoor being zero

			Debug.Log ("Open");
			InsideDoorOpen = true;
			InsideDoor ("Open");
			GetComponent<AudioSource> ().PlayOneShot (Door);
		}else if (col.gameObject.tag == "Player") {//if the Player approaches the door without any other conditions, it will trigger a message to be displayed on the screen using the GUIText
			textHints.SendMessage ("ShowHint", "The door won't open!!! \n Read all the information on the walls and watch the videos \n Make sure you have learnt the material before entering next room \n The next Room is a Test of your Knowledge on Behavioural Economics");
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
