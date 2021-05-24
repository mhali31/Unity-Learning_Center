using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMat2 : MonoBehaviour {		//this script is attached to the GameObject QuestionMat2.
												//refer to Question1 script for a more detailed explanation.
	public GUIText textHints;
	public GameObject WarmUpQuestionPrefab;
	public GameObject Number1;
	public GameObject Number2;
	public GameObject Number3;
	public GameObject Number4;
	public GameObject Number5;
	bool answerbool;


	// Use this for initialization
	void Start () {
		answerbool = false;
	}



	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.coins == 1) {		//when the Player collides with this GameObject box collider and coins=1, the following will occur
			Selecting.canSelect = true;
			textHints.SendMessage("ShowHint", "Answer the question to receive the coin");
			GameObject WarmUp = transform.Find ("WarmUp").gameObject;
			GameObject WarmUpQ = Instantiate (WarmUpQuestionPrefab, WarmUp.transform.position, WarmUp.transform.rotation) as GameObject;
			WarmUpQ.name = "Warm Up Question";
			StartCoroutine ("AnswerBox");
			answerbool = true;
		}else if(col.gameObject.tag == "Player" && Inventory.coins == 2){		//When coins=2 and Player collides with this GameObject, the the message below will be displayed
			textHints.SendMessage("ShowHint", "You have answered this Question, find the Bus Stop");
	}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			Selecting.canSelect = false;
			GameObject WarmUp2 = GameObject.FindGameObjectWithTag ("WarmUp2");
			Destroy (WarmUp2);

		}
	}
	IEnumerator AnswerBox(){		//Answer2 is tagged with correct and the rest are tagged with incorrect
		if (answerbool == false) {
			GameObject a1 = transform.Find ("a1").gameObject;
			GameObject Answer1 = Instantiate (Number1, a1.transform.position, a1.transform.rotation) as GameObject;
			Answer1.tag = "incorrect";
			Destroy (a1);
			GameObject a2 = transform.Find ("a2").gameObject;
			GameObject Answer2 = Instantiate (Number2, a2.transform.position, a2.transform.rotation) as GameObject;
			Answer2.tag = "correct";
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
