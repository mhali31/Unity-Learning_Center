using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecting : MonoBehaviour {	//This script is attached to the Pointer GameObject which is a child of the FPSController

	public AudioClip clicksound;		//AudioClip assigned to Play a sound whenever the Fire1 button is pressed
	public Rigidbody SelectorPrefab;	//The Rigidbody which attached to the script which will be brought into the game when instantiated
	public float throwSpeed = 100.0f;			//the throwSpeed can be set to any value in Unity as it is public
	public static bool canSelect = false;		//a public static bool set to false at the start. Since it is public, it can be switched to true in other scripts

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && canSelect) {	//when the Fire1(the left button on the mouse) is pressed and canSelect is true, then the following will occur
			GetComponent<AudioSource> ().PlayOneShot (clicksound);		//the clicksound AudioCLip will be played everytime the button is pressed
			Rigidbody newSelector = Instantiate (SelectorPrefab, transform.position, transform.rotation) as Rigidbody;	//the SelectorPrefab will be brought into the game. the position and rotation of the newSelector,which be its name, will be the same as the GameObject this script is attached to.
			newSelector.name = "Selector";		//The newSelector will be named as Selector in the Hierarchy whenever one comes into the game.
			newSelector.velocity = transform.forward * throwSpeed;		//since the newSelector is a projectile, it will be thrown forward from the position of this GameObject at 100.0f (throwSpeed), unless it has been changed in Unity.  
		}
	}
}
