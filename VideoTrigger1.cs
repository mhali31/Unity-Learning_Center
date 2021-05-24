using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTrigger1 : MonoBehaviour {		//this script is attached to the triggers for the Videos in the first room of the learning Centre
											//this script is similar to CentreView1 and NotesDoubleView1, with this script being set up to use videos compared to the other two which display textures
	public GameObject Video;			//A GameObject Video will be attached this script in Unity
	bool time = false;				//a bool called time has been set to false at the start
	float timer = 0;			//the float timer has been set zero at the start
	bool Finish = false;			//the bool Finish has been set to false at the start

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Welcome == 0) {		//when the Player enters the box collider of this GameObject and Welcome is equal to zero, then the following will occur
			Video.SetActive (true);			//the GameObject Video is activated. Therefore enabling the Video to start playing.
			time = true;				//the time bool is set to true, which allows the timer to increase in the Updates function
		} 
		}
		
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {		//when the Player leaves the box collider
			Video.SetActive (false);			//The Video GameObject is no longer active, therefore the video has stopped playing
			if (timer < 10) {				//if the timer doesn't reach 10 seconds
				timer = 0;				//then to timer is set back to zero	
				time = false;			//the time bool is also set to false, to prevent the timer from increasing, until it has been activated again in the OnTriggerEnter function
				Debug.Log ("reset");	//for testing purposes, it is important to know whether the Player stayed on the trigger for 10 seconds. If the Player doesn't, reset will appear on the console
			}	
			else if (timer >= 10) {			//if the timer does reach 10 seconds or more
				Debug.Log ("right");		//during testing, right will appear on the console. This will indicate that this GameObject has counted towards opening the door to Room2 and therefore it is not necessary to go back to it.
				col.gameObject.SendMessage ("Room1");			//a message will be sent to the Player's Inventory script which holds the Room1 function.
				time = false;	//the time bool is set to false
				timer = 0;		//the timer is reset
				Finish = true;		//The Finish bool is set to true, which will prevent the timer from increasing again. This is necessary to prevent the Video being counted more than once in opening the door.
			}
		}
	}
	void Update(){		
		if(time==true && Finish == false){		//the timer will only increase when the time bool is true and Finish bool is false. 
			timer += Time.deltaTime;
		}
	}
}