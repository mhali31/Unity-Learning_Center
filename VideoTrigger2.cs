using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTrigger2 : MonoBehaviour {// this script is attached to the triggers for the Videos in the second room
												//this script is similar to VideoTrigger1, therefore, to get a more detailed explanation refer to that script.
	public GameObject Video;
	bool time = false;
	float timer = 0;
	bool Finish = false;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Video.SetActive (true);
			time = true;
		} 
	}



	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			Video.SetActive (false);
			if (timer < 10) {
				timer = 0;
				time = false;
				Debug.Log ("reset");
			}	
			else if (timer >= 10) {
				Debug.Log ("right");
				col.gameObject.SendMessage ("Room2");		//a message will be sent to the Room2 function in the Inventory script attached to the Player
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