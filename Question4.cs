using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question4 : MonoBehaviour {		//Question4 script is attached to the Question4 GameObject in the Hierarchy, it is almost identical to Question1 with a few exceptione
												//Refer to the Question1 script for a more detailed explanation of this script

	public GUIText textHints;
	public GameObject Questions;			//the GameObject assigned to this script is the Question4 GameObject in the Prefabs folder
	public GameObject Number1;
	public GameObject Number2;
	public GameObject Number3;
	public GameObject Number4;
	bool answerbool;


	void Start () {
		answerbool = false;

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Answer == 3) {		//The conditions that need to be met are the Player Colliding with Question4 GameObject and when Answer equals three
			Selecting.canSelect = true;
			textHints.SendMessage ("ShowHint", "Question 4");
			GameObject Question = transform.Find ("Question").gameObject;
			GameObject Quest = Instantiate (Questions, Question.transform.position, Question.transform.rotation) as GameObject;
			Quest.name = "Question";
			StartCoroutine ("AnswerBox");
			answerbool = true;

		} else if (col.gameObject.tag == "Player" && Inventory.Answer == 2) {		//When Answer equals two and the Player collides, then the message will appear on screen
			textHints.SendMessage ("ShowHint", "Question 4 \n Answer Question 3 first");
		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			Selecting.canSelect = false;
			GameObject Question4 = GameObject.FindGameObjectWithTag ("Question4");
			Destroy (Question4);
		}
	}

	IEnumerator AnswerBox (){		//Answer2 is tagged with Right with the rest being tagged as false.
		if (answerbool == false) {
			GameObject a1 = transform.Find ("a1").gameObject;
			GameObject Answer1 = Instantiate (Number1, a1.transform.position, a1.transform.rotation) as GameObject;
			Answer1.tag = "Wrong";
			Destroy (a1);
			GameObject a2 = transform.Find ("a2").gameObject;
			GameObject Answer2 = Instantiate (Number2, a2.transform.position, a2.transform.rotation) as GameObject;
			Answer2.tag = "Right";
			Destroy (a2);
			GameObject a3 = transform.Find ("a3").gameObject;
			GameObject Answer3 = Instantiate (Number3, a3.transform.position, a3.transform.rotation) as GameObject;
			Answer3.tag = "Wrong";
			Destroy (a3);
			GameObject a4 = transform.Find ("a4").gameObject;
			GameObject Answer4 = Instantiate (Number4, a4.transform.position, a4.transform.rotation) as GameObject;
			Answer4.tag = "Wrong";
			Destroy (a4);
			yield return new WaitForSeconds (0);
		}
	}

}