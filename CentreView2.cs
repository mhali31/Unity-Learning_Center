using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreView2 : MonoBehaviour {		//CentreView2 is attached to the notes in the second room. it is identical to Centreview1 but with a few alterations. NoteDoubleView2 is identical to this with one exception, there are two Textures not one
												//refer to CentreView1 for more detailed explaination of this script
	public GUITexture Texture;
	bool time = false;
	float timer = 0;
	bool Finish = false;


	void Start(){
		Texture.enabled = false;

	}

	void OnTriggerEnter(Collider col){		//unlike in CentreView1, CentreView2 is not dependant on the Welcome Message to finish for the player to be able to interact with the notes in the room. 
		if (col.gameObject.tag == "Player") {
			Texture.enabled = true;
			time = true;

		} 
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			Texture.enabled = false;
			if (timer < 10) {
				timer = 0;
				time = false;
				Debug.Log ("reset");
			}	
			else if (timer >= 10) {
				Debug.Log ("right");
				col.gameObject.SendMessage ("Room2");		//Room2 is in the inventory script and by sending a message to it, it will increment the counter by 1
				time = false;
				timer = 0;
				Finish = true;

			}

		}

	}
	void Update(){
		if(time==true && Finish == false){
			timer += Time.deltaTime;
		}
	}
}
