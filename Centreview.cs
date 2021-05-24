using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used with the Map on the Learning Centre and the house. 

public class Centreview : MonoBehaviour {			

	public GUITexture CentreTexture;		//The GUITexture attached to this script is a Map which comes on the centre of the screen when the Player enters the trigger zone

	void Start(){						//At the start of the game the GUITexture is not enabled, therefore it is set to false
		CentreTexture.enabled = false;
	}

	void OnTriggerEnter(Collider col){		//When the Player enters the box collider/trigger zone of the GameObject this is attached to, the Texture is enabled by setting it to true.
		if (col.gameObject.tag == "Player") {
			CentreTexture.enabled = true;
		}
	}
	void OnTriggerExit(Collider col){			//When the Player leaves the box collider/trigger zone, the Texture reverts back to being false, therefore it no longer appears on the screen.
		if (col.gameObject.tag == "Player") {
			CentreTexture.enabled = false;
		}
	}
}
