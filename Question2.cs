using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question2 : MonoBehaviour {		//Question2 script is attached to the Question2 GameObject in the Hierarchy, it is almost identical to Question1 with a few exceptions
												//Refer to the Question1 script for a more detailed explanation of this script
	public GUIText textHints;
	public GameObject Questions;		//the GameObject assigned to this script is the Question2 GameObject in the Prefabs folder
	public GameObject Number1;
	public GameObject Number2;
	public GameObject Number3;
	public GameObject Number4;
	bool answerbool;




	// Use this for initialization
	void Start () {
		answerbool = false;

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Answer == 1) {		//If the Player enters to trigger zone of the GameObject assigned this script is assigned to and Answer, in the Inventory, is equal to one. The following will occur
			Selecting.canSelect = true;
			textHints.SendMessage ("ShowHint", "Question 2");		
			GameObject Question = transform.Find ("Question").gameObject;
			GameObject Quest = Instantiate (Questions, Question.transform.position, Question.transform.rotation) as GameObject;
			Quest.name = "Question";
			StartCoroutine ("AnswerBox");
			answerbool = true;
			//GameObject a5 = transform.Find ("a5").gameObject;
			//GameObject Answer5 = Instantiate (Number5, a5.transform.position, a5.transform.rotation) as GameObject;
			//Answer5.tag = "Wrong";
			//Destroy (a5);
		} else if (col.gameObject.tag == "Player" && Inventory.Answer == 0) {	//if the Player enters the trigger zone and Answer is equal to zero, then the function ShowHint in the textHint GUIText will be sent a message to display the text on the screen.
			textHints.SendMessage ("ShowHint", "Question 2 \n Answer Question 1 first");
		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			Selecting.canSelect = false;
			GameObject Question2 = GameObject.FindGameObjectWithTag ("Question2");		
			Destroy (Question2);
		}
	}

	IEnumerator AnswerBox (){			//Answer4 is tagged with the right answer, with the rest of the Answer boxes being tagged with Wrong
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
			Answer3.tag = "Wrong";		
			Destroy (a3);
			GameObject a4 = transform.Find ("a4").gameObject;
			GameObject Answer4 = Instantiate (Number4, a4.transform.position, a4.transform.rotation) as GameObject;
			Answer4.tag = "Right";	
			Destroy (a4);
			yield return new WaitForSeconds (0);
		}
	}

}
