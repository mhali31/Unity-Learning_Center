using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question1 : MonoBehaviour {	//This script is attached to Question1 GameObject and is primarily used to import the questions and answer boxes into the scene
											// The scripts for Question 2-14 are similar and therefore the explanation for this script will apply to them, with the differences being mentioned in the individual scripts
											//the scripts QuestionMat 1-3 are also similar to this script

	public GUIText textHints;			//A GUIText will be attached to this script
	public GameObject Questions;		//The Question GameObject (which is in the Prefabs) will be attached, for this script Question 1 is used
	public GameObject Number1;			//The Number1 GameObject will be attached, this is in the Prefabs folder
	public GameObject Number2;			//The Number2 GameObject will be attached, this is in the Prefabs folder
	public GameObject Number3;			//The Number3 GameObject will be attached, this is in the Prefabs folder
	public GameObject Number4;			//The Number4 GameObject will be attached, this is in the Prefabs folder
	bool answerbool;					// a private bool  called answerbool is required



	// Use this for initialization
	void Start () {
		answerbool = false;		//at the start the answerbool is set to false
	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && Inventory.Answer == 0 && Inventory.Test == 1) {// when the Player enters the collider and in the Inventory, Answer=1 and Test=1, then the following will occur
			Selecting.canSelect = true;		//the canSelect bool is now true, which is present in the Selecting script
			textHints.SendMessage("ShowHint", "Question 1");		//The ShowHint function in the script on the GUIText will show Question 1 on the screen when the above conditions are met
			GameObject Question = transform.Find ("Question").gameObject;		//the GameObject in the Hierarchy is found and it Transform in the Inspector is noted
			GameObject Quest = Instantiate (Questions, Question.transform.position, Question.transform.rotation) as GameObject;		//The Questions GameObject is Instantiated into the scene in the same Position and Rotation of the Question GameObject. This new GameObject in the game is called Quest
			Quest.name = "Question";	//Quest is renamed in the Hierarchy to Question. This isn't really necessary for the functionality of the game
			StartCoroutine ("AnswerBox");		//A Coroutine called AnswerBox is initiatied. This can been seen below as an IEnumerator
			answerbool = true;		//The answerbool is now set to true

		}
	}

	void OnTriggerExit (Collider col){			
		if (col.gameObject.tag == "Player") {			//when the Player the leaves the Collider, the following occurs
			Selecting.canSelect = false;			//the canSelect bool in the Selecting Script is set to false again.
			GameObject Question1 = GameObject.FindGameObjectWithTag ("Question1");		//The GameObject with the Question1 tag is found and labelled Question1
			Destroy (Question1);		//Question1 is then destroyed
	

		}
	}

	IEnumerator AnswerBox (){		//IEnumerator is used, but void would of worked perfectly fine, with the only changes needing to be made are the removal of the yield and the changing of the StartCoroutine to Answer Box ()
		if (answerbool == false) {		//when the answerbool is set to false, the following will occur. The use of the answerbool is highly significant in the functionality of the game, to make sure this function only occurs once, if this function tries to occur more than once there will be errors due to missing GameObjects(the GameObjects destroyed in this function)
			GameObject a1 = transform.Find ("a1").gameObject;		//the GameObject in the Hierarchy is found and it Transform in the Inspector is noted
			GameObject Answer1 = Instantiate (Number1, a1.transform.position, a1.transform.rotation) as GameObject;		//a new GameObject is created called Answer1, which is the Number1 GameObject attached to the script with the position and rotation of a1.
			Answer1.tag = "Wrong";		//Answer1 is given the tag Wrong
			Destroy (a1);		//the a1 GameObject has now been destroyed
			GameObject a2 = transform.Find ("a2").gameObject;		//the GameObject in the Hierarchy is found and it Transform in the Inspector is noted
			GameObject Answer2 = Instantiate (Number2, a2.transform.position, a2.transform.rotation) as GameObject;	//a new GameObject is created called Answer2, which is the Number2 GameObject attached to the script with the position and rotation of a2.
			Answer2.tag = "Wrong";		//Answer2 is given the tag Wrong
			Destroy (a2);			//the a2 GameObject has now been destroyed
			GameObject a3 = transform.Find ("a3").gameObject;		//the GameObject in the Hierarchy is found and it Transform in the Inspector is noted
			GameObject Answer3 = Instantiate (Number3, a3.transform.position, a3.transform.rotation) as GameObject;		//a new GameObject is created called Answer3, which is the Number3 GameObject attached to the script with the position and rotation of a3.
			Answer3.tag = "Wrong";		//Answer3 is given the tag Wrong
			Destroy (a3);			//the a3 GameObject has now been destroyed
			GameObject a4 = transform.Find ("a4").gameObject;		//the GameObject in the Hierarchy is found and it Transform in the Inspector is noted
			GameObject Answer4 = Instantiate (Number4, a4.transform.position, a4.transform.rotation) as GameObject;		//a new GameObject is created called Answer4, which is the Number4 GameObject attached to the script with the position and rotation of a4.
			Answer4.tag = "Right";		//Answer4 is given the tag Wrong
			Destroy (a4);			//the a4 GameObject has now been destroyed
			yield return new WaitForSeconds (0);		//all IEnumerators require a yield, but since no we don't need a wait time the WaitForSeconds has been set to zero.
		}
	}
}
