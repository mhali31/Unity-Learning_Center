using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question13 : MonoBehaviour {		//Question13 script is attached to the Question13 GameObject in the Hierarchy, it is almost identical to Question1 with a few exceptions
												//Refer to the Question1 script for a more detailed explanation of this script

	public GUIText textHints;
	public GameObject Questions;			//the GameObject assigned to this script is the Question13 GameObject in the Prefabs folder
	public GameObject Number1;
	public GameObject Number2;
	public GameObject Number3;
	public GameObject Number4;
	bool answerbool;


	void Start () {
		answerbool = false;

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Answer == 12) {	//The conditions that need to be met are the Player Colliding with Question13 GameObject and when Answer equals twelve
			Selecting.canSelect = true;
			textHints.SendMessage ("ShowHint", "Question 13");
			GameObject Question = transform.Find ("Question").gameObject;
			GameObject Quest = Instantiate (Questions, Question.transform.position, Question.transform.rotation) as GameObject;
			Quest.name = "Question";
			StartCoroutine ("AnswerBox");
			answerbool = true;

		} else if (col.gameObject.tag == "Player" && Inventory.Answer == 11) {	//When Answer equals eleven and the Player collides, then the message will appear on screen
			textHints.SendMessage ("ShowHint", "Question 13 \n Answer Question 12 first");
		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			Selecting.canSelect = false;
			GameObject Question13 = GameObject.FindGameObjectWithTag ("Question13");
			Destroy (Question13);



		}
	}

	IEnumerator AnswerBox (){		//Answer3 is tagged with Right with the rest being tagged as false.
		if (answerbool == false) {
			GameObject a1 = transform.Find ("a1").gameObject;
			GameObject Answer1 = Instantiate (Number1, a1.transform.position, a1.transform.rotation) as GameObject;
			Answer1.tag = "Wrong";
			Destroy (a1);
			GameObject a2 = transform.Find ("a2").gameObject;
			GameObject Answer2 = Instantiate (Number2, a2.transform.position, a2.transform.rotation) as GameObject;
			Answer2.tag = "Wrong";
			Destroy (a2);
			GameObject a3 = transform.Find ("a3").gameObject;
			GameObject Answer3 = Instantiate (Number3, a3.transform.position, a3.transform.rotation) as GameObject;
			Answer3.tag = "Right";
			Destroy (a3);
			GameObject a4 = transform.Find ("a4").gameObject;
			GameObject Answer4 = Instantiate (Number4, a4.transform.position, a4.transform.rotation) as GameObject;
			Answer4.tag = "Wrong";
			Destroy (a4);
			yield return new WaitForSeconds (0);
		}
	}

}