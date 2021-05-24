using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreView3 : MonoBehaviour {		//CentreView3 is identical to CentreView2 with one exception. NoteDoubleView3 is identical to this script with one exception
												//refer to CenreView1 for a more detailed explanation of this script
	public GUITexture Texture;
	bool time = false;
	float timer = 0;
	bool Finish = false;


	void Start(){
		Texture.enabled = false;

	}

	void OnTriggerEnter(Collider col){
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
				col.gameObject.SendMessage ("Room3");	//the counter incremented in the inventory script is in the Room3 function
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
