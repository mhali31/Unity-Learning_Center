using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutine : MonoBehaviour {

	bool time = false;
	float timer = 0;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			time = true;



		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			if (timer < 10) {
				timer = 0;
				time = false;
				Debug.Log ("reset");
			}	
			else if (timer >= 10) {
				Debug.Log ("right");
			}

		}
	}
	void Update(){
		if(time==true){
			timer += Time.deltaTime;
		}
	}
}
