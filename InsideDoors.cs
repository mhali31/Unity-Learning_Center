using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDoors : MonoBehaviour {

	Animator animator;
	bool InsideDoorOpen;
	public AudioClip Door;

	void Start () {
		InsideDoorOpen = false;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			InsideDoorOpen = true;
			InsideDoor("Open");
			GetComponent<AudioSource> ().PlayOneShot (Door);
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
