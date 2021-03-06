using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDoubleView2 : MonoBehaviour {			// this script is attached to notes in the second room which require two GUITextures
	//this script is identical to CentrView2 with one exception, there are two Textures not one. Refer to CentreView1 and CentreView2 for a more detailed explanation of this script.
	public GUITexture TextureTop;
	public GUITexture Texture2Bottom;
	bool time = false;
	float timer = 0;
	bool Finish = false;


	void Start(){
		TextureTop.enabled = false;
		Texture2Bottom.enabled = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			TextureTop.enabled = true;
			Texture2Bottom.enabled = true;
			time = true;

		} 
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			TextureTop.enabled = false;
			Texture2Bottom.enabled = false;
			if (timer < 10) {
				timer = 0;
				time = false;
				Debug.Log ("reset");
			}	
			else if (timer >= 10) {
				Debug.Log ("right");
				col.gameObject.SendMessage ("Room2");
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

