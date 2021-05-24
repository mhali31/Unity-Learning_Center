using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour {

	//public GameObject Video;
	VideoPlayer video;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
		//	Video.SetActive (true);
			//yield return new WaitForSeconds (20);
			//Video.SetActive (false);
			video = GetComponent<VideoPlayer>();
			video.Play();
		}

	}
	void Pause (){
		if (video.isPlaying) {
			video.Pause ();
		}
	}
	/*void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			Video.SetActive (true);
		}
	}*/
}
