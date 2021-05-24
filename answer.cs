using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer : MonoBehaviour {

	public AudioClip correct;   //AudioClip for right answer in warm up questions and test questions
	public AudioClip wrong;		//AudioClip for wrong answer in the test questions
	public AudioClip TryAgain;  //AudioClip for wrong answers in warm up questions
	public GameObject coinPrefab;	//GameObject/Coin which will appear the moment the right answer is selected
	public float removeTime = 2.0f;		//The time that this GameObject will stay in the scene until it is destroyed
	public GameObject RightAns;		//GameObject/Coin that will appear when a right answer is selected in the test
	public GameObject WrongAns;		//GameObject/Coin that will appear when a wrong answer is selected in the test


	// Use this for initialization
	void Start () {
		Destroy (gameObject, removeTime);	//Destroying this GameObject the 2.0f after it has been instantiated

	}

	void OnTriggerEnter (Collider col){		//OnTriggerEnter function that will happen between this GameObject/SelectorPrefab and the answer boxes which will be tagged when they are instantiated in the Question and Question Mat scripts
		if (col.gameObject.tag == "correct") {	//when an answer box is tagged with the correct tag
			GetComponent<AudioSource> ().PlayOneShot (correct);		//the correct answer sound will be played
			Destroy (col.gameObject);		//the answer box will be destroyed after the collision
			GameObject newcoin = Instantiate (coinPrefab, transform.position, transform.rotation) as GameObject;	//the coin will be appear in the scene in the position where the answer box use to be
			newcoin.name = "Collect Coin";	// in the hierarchy the coin will appear with the name Collect Coin
			IncorrectAnswers ();		//The IncorrectAnswer function will take place which can be seen below


		} else if (col.gameObject.tag == "incorrect") {		// this is what happens when the box is tagged with incorrect and the selectorPrefab enters it trigger zone
			GetComponent<AudioSource> ().PlayOneShot (TryAgain);		//the AudioClip TryAgain will be played once
			Destroy (col.gameObject);		//the GameObject/Answer Box which was collided with is destroyed
	
		}
		else if (col.gameObject.tag == "Right") {		//this is what occurs during the test questions and the answer box is tagged with "Right"
			GetComponent<AudioSource> ().PlayOneShot (correct);		//the correct answer AudioClip is played once
			Destroy (col.gameObject);		//the answer box which were tagged "Right" and collided were are destroyed
			Instantiate (RightAns, transform.position, transform.rotation);		// the right answer coin appears in the scene in position the collision took place
			WrongAnswers ();		//The WrongAnswers function will take place which can be seen below
		} 

		else if (col.gameObject.tag == "Wrong") {	//this is what happens when a answer box with the "Wrong" tag in the test questions is hit by the GameObject SelectorPrefab
			GetComponent<AudioSource> ().PlayOneShot (wrong);	//The wrong answer AudioClip is played once
			Destroy (col.gameObject);			//the answer box is destroyed
			Instantiate (WrongAns, transform.position, transform.rotation);			//a wrong answer coin appears in the scene in the place the collision took place
			WrongAnswers ();	//the WrongAnswers function takes place, see below
			RightAnswer ();		//the RightAnswer fuction takes place, see below

		}

	}
		void IncorrectAnswers(){	//this function occurs when the correct answer is selected in the warm up questions and, therefore, the incorrect answer boxes need to be destroyed
	GameObject [] incorrectanswer = GameObject.FindGameObjectsWithTag("incorrect");		//this is done by finding all the GameObjects in the scene with the incorrect tag. The [] is to represent that this is an array
		foreach (GameObject inc in incorrectanswer) {	//this states that for each of the gameobjects with the tag incorrect, will be labelled inc
			Destroy (inc);			// the gameobjects inc are all destroyed.
		}
		}
	void RightAnswer(){		// this function occur during a test question and a wrong answer is selected. The right answer for the question (The box with the "Right" tag) will be destroyed
		GameObject correctanswer = GameObject.FindGameObjectWithTag ("Right");		//unlike IncorrectAnswers and WrongAnswers, there is only expected to be one right answer in the scene therefore FindGameObjectWithTag is used instead of FindGameObjectsWithTag
		Destroy (correctanswer);		//once the gameobject is found, it is destroyed.
	}
	void WrongAnswers(){	//this function occurs during a test question and a wrong or right answer is selected. 
		GameObject[] wronganswer = GameObject.FindGameObjectsWithTag ("Wrong");	//Similar to what happened in the IncorrectAnswers function, all the gameobjects in the scene with the tag "Wrong" are found
		foreach (GameObject wro in wronganswer) {	// they are then labelled "wro" 	
			Destroy (wro);		//the gameobjects wro are all destroyed
		}
	}
	}
	
