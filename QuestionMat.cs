using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMat : MonoBehaviour {		//this script is attached to the GameObject QuestionMat1. 
												//refer to the Question1 script for a more detailed explanation
	public GUIText textHints;
	public GameObject WarmUpQuestionPrefab;		
	public GameObject Number1;
	public GameObject Number2;
	public GameObject Number3;
	public GameObject Number4;
	public GameObject Number5;				//an addition answer box is used in the warm up questions
	bool answerbool;

	void Start(){
		answerbool = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.coins == 0 && Inventory.Warmup == 2) {		//the conditions that need to be met, are the PLayer entering the trigger zone, coins=0 and Warmup=2
			Selecting.canSelect = true;
			textHints.SendMessage("ShowHint", "Stay on the Question Mat and use the left mouse key to answer the question, Collect the coin when you get it right.");
			GameObject WarmUp = transform.Find ("WarmUp").gameObject;
			GameObject WarmUpQ = Instantiate (WarmUpQuestionPrefab, WarmUp.transform.position, WarmUp.transform.rotation) as GameObject;
			WarmUpQ.name = "Warm Up Question";
			StartCoroutine ("AnswerBox");
			answerbool = true;
		}else if(col.gameObject.tag == "Player" && Inventory.coins == 1)		//if coins is equal to one and the Player collides, the message below is displayed on the screen
			textHints.SendMessage("ShowHint", "You have answered this Question, find the petrol station");
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			Selecting.canSelect = false;
			GameObject WarmUp1 = GameObject.FindGameObjectWithTag ("WarmUp1");
			Destroy (WarmUp1);
		
		}
	}

	IEnumerator AnswerBox(){		//Answer1 is tagged correct and the rest are tagged incorrect
		if (answerbool == false) {
			GameObject a1 = transform.Find ("a1").gameObject;
			GameObject Answer1 = Instantiate (Number1, a1.transform.position, a1.transform.rotation) as GameObject;
			Answer1.tag = "correct";
			Destroy (a1);
			GameObject a2 = transform.Find ("a2").gameObject;
			GameObject Answer2 = Instantiate (Number2, a2.transform.position, a2.transform.rotation) as GameObject;
			Answer2.tag = "incorrect";
			Destroy (a2);
			GameObject a3 = transform.Find ("a3").gameObject;
			GameObject Answer3 = Instantiate (Number3, a3.transform.position, a3.transform.rotation) as GameObject;
			Answer3.tag = "incorrect";
			Destroy (a3);
			GameObject a4 = transform.Find ("a4").gameObject;
			GameObject Answer4 = Instantiate (Number4, a4.transform.position, a4.transform.rotation) as GameObject;
			Answer4.tag = "incorrect";
			Destroy (a4);
			GameObject a5 = transform.Find ("a5").gameObject;
			GameObject Answer5 = Instantiate (Number5, a5.transform.position, a5.transform.rotation) as GameObject;
			Answer5.tag = "incorrect";
			Destroy (a5);
			yield return new WaitForSeconds (0);
		}
	}

}
