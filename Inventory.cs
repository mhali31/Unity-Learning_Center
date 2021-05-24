using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;	//this had to be added in order to write the code to use the UserInterface
using UnityEngine;

public class Inventory : MonoBehaviour {	//the Inventory script is connected to the FPSController(Player)

	public static int coins = 0;		//coin counter which is set to public so it can be seen by other scripts
	public Text Coins;					//the Coins Text can be connected to this script
	public static int Count1 = 0;		//Count1 counter is set to public so it can be accessed by other scripts
	public Text Score;					//the Score Text can be connected to this script 
	public static int Right = 0;		//Right counter is set to public so it can be accessed by other scripts
	public static int Wrong = 0;		//Wrong counter is set to public so it can be accessed by other scripts
	public static int Answer = 0;		//Answer counter is set to public so it can be accessed by other scripts
	public static int Count2 = 0;		//Count2 counter is set to public so it can be accessed by other scripts
	public static int Count3 = 0;		//Count3 counter is set to public so it can be accessed by other scripts
	public static int Welcome = 0;		//Welcome counter is set to public so it can be accessed by other scripts
	public AudioClip CoinSound;			//AudioClip CoinSound can be assigned in Unity and used in this script
	public AudioClip Coin1;				//AudioClip Coin1 can be assigned in Unity and used in this script
	public AudioClip Coin2;				//AudioClip Coin2 can be assigned in Unity and used in this script
	public AudioClip Coin3;				//AudioClip Coin3 can be assigned in Unity and used in this script
	public GUIText textHints;			//textHints GUIText can be assigned to this script in Unity
	public static int Door;			//Door counter is set to public so it can be accessed by other scripts
	public static int Test;			//Test counter is set to public so it can be accessed by other scripts
	public static int TestDoor;		//TestDoor counter is set to public so it can be accessed by other scripts
	public static int Warmup;		//Warmup counter is set to public so it can be accessed by other scripts
	bool Warm;						//private bool Warm is set up to be used in this script


	// Use this for initialization
	void Start () {
		coins = 0;		//coins is set to zero at the beginning of the game
		SetCoins ();	//SetCoins function, which can be seen below, is active
		Count1 = 0;		//Count1 is set to zero at the beginning of the game
		Count2 = 0;		//Count2 is set to zero at the beginning of the game
		Count3 = 0;		//Count3 is set to zero at the beginning of the game
		Door = 0;		//Door is set to zero at the beginning of the game
		SetScore ();	// SetScore function, which can be seen below, is active
		Right = 0;		//Right is set to zero at the beginning of the game
		Wrong = 0;		//Wrong is set to zero at the beginning of the game
		Answer = 0;		//Answer is set to zero at the beginning of the game
		Test = 0;		//Test is set to zero at the beginning of the game
		Welcome = 0;	//Welcome is set to zero at the beginning of the game
		TestDoor = 0;	//TestDoor is set to zero at the beginning of the game
		Warmup = 0;		//Warmup is set to zero at the beginning of the game
		Warm = false;	//the Warm bool is set to false at the beginning of the game
	
	
	}


	IEnumerator CoinPickup(){	//instead of void, IEnumerator is used to make use of yield return new WaitForSeconds. CoinPickup occurs when the collision between the coin and Player happens, which sends message to this function in the coin script
		coins = coins + 1;	//the new value for coins will be the current value plus one

		SetCoins ();		//the SetCoins function, which can be seen below, is active
		GetComponent<AudioSource> ().PlayOneShot (CoinSound);		//the CoinSound AudioClip is played from the AudioSource component connected added to this GameObject
		if (Inventory.coins == 1) {		// when coins = 1, there will be a 2 seconds waiting period before, the Coin1 AudioClip is played and a message is shown using the GUIText textHint attached to this script in Unity
			yield return new WaitForSeconds (2);
			GetComponent<AudioSource> ().PlayOneShot (Coin1);
			textHints.SendMessage ("ShowHint", "The next question is behind the petrol station \n Use the Map on the side of Learning Centre if you need help locating the place");
		}
		if (Inventory.coins == 2) {		// when coins = 2, A message will appear on the screen and there will be a 7 seconds waiting period before, the Coin2 AudioClip is played and a message is shown using the GUIText textHint attached to this script in Unity
			textHints.SendMessage ("ShowHint", "There are more Salesman in the UK than the rest of the option, \n therefore, Geoff is most likely to be a Salesman due to the higher base rate");
			yield return new WaitForSeconds (7);
			GetComponent<AudioSource> ().PlayOneShot (Coin2);
			textHints.SendMessage ("ShowHint", "The next question is behind the Bus Stop \n Use the Map on the side of Learning Centre if you need help locating the place");
		}
		if (Inventory.coins == 3) {	// when coins = 3, A message will appear on the screen and there will be a 7 seconds waiting period before, the Coin3 AudioClip is played and a message is shown using the GUIText textHint attached to this script in Unity
			textHints.SendMessage ("ShowHint", "Half of Harvard students said 10p, which is the intuitive answer but wrong!");
			yield return new WaitForSeconds (7);
			GetComponent<AudioSource> ().PlayOneShot (Coin3);
			textHints.SendMessage ("ShowHint", "Go back to the Learning Centre");
		}
	}

	void RightPickup(){		//a message is sent to this function from RightCoin script during the collision between the Player and Right Answer Coin
		Right = Right + 1;	//the new value for Right is the old value plus one.
		GetComponent<AudioSource> ().PlayOneShot (CoinSound);		//The AudioClip CoinSound is played to let the Player know the coin has been picked up
		SetScore ();		//the SetScore function,  is active. This will show the new score after each Right Answer coin is collected
	}
		
	void WrongPickup(){			//a message is sent to this function from the WrongCoin script during the collision between the Player and the Wrong Answer Coin
		Wrong = Wrong + 1;		//the new value for Wrong is the old value plus one.
		GetComponent<AudioSource> ().PlayOneShot (CoinSound);		//The coinSound is played from the AudioSource letting the Player know the coin has been picked up
	}

	void AnswerPickup(){		//a message is sent to this function from the WrongCoin and RightCoin scripts, whenever a collisions occur between the Player and the Coins the scripts are attached to.
		Answer = Answer + 1;		//the new value for the Answer is the old value plus one.
		if (Answer == 14 && Right >=8) {		// when Answer is equal to 14, the DoorOpen and TestRoomExit, which are both below, will be activated. Additionally if Right is greater than or equal to 8 message will appear on the screen
			textHints.SendMessage ("ShowHint", "You have performed well in the test, Well Done. \n The entrance is now open for you to leave");
			DoorOpen (); 
			TestRoomExit ();
		}
		if (Answer == 14 && Right <= 7) {		// when Answer is equal to 14, the DoorOpen and TestRoomExit, which are both below, will be activated. Additionally if Right is lesser than or equal to 7 message will appear on the screen
			textHints.SendMessage ("ShowHint", "You underperformed in the test. Consider spending more time learning the material \n The entrance is now open for you to leave");
			DoorOpen (); 
			TestRoomExit ();
		}
	}

	void SetCoins (){			//This function is present in the Start and CoinPickup function. This will display  on the screen, during GameMode, the text "coins:" followed by the current value of coins (the public static int)
		Coins.text = "coins: " + coins.ToString ();
	}

	void Room1(){			//a message will have been sent from the VideoTrigger1, CentreView1 and DoubleNotesView1 script, after the 10 seconds the Player needs to stay in the trigger zone before the timer resets
		Count1 = Count1 + 1;		//The new Count1 value is the old value plus one
		Debug.Log ("1");			//This is being used during testing to make sure everything is working currently
	
	}

	void Room2(){		//a message will have been sent from the VideoTrigger2, CentreView2 and DoubleNoteView2 script, after the 10 seconds the Player needs to stay in the trigger zone before the timer resets
		Count2 = Count2 + 1;		//The new Count2 value is the old value plus one
		Debug.Log ("1");			//This is being used during testing to make sure everything is working currently

	}

	void Room3(){		//a message will have been sent from the VideoTrigger3, CentreView3 and DoubleNoteView3 script, after the 10 seconds the Player needs to stay in the trigger zone before the timer resets
		Count3 = Count3 + 1;		//The new Count2 value is the old value plus one
		Debug.Log ("1");		//This is being used during testing to make sure everything is working currently

	}
	void SetScore(){		//This function is present in the Start and RightPickup function. This will display  on the screen, during GameMode, the text "Score:" followed by the current value of Right (the public static int)
		Score.text = "Score:" + Right.ToString ();
	}
	void DoorLock (){		//a message will have been sent from the WelcomeMessage script, which will lock InsideDoor4 and the Entrance to prevent the Player from leaving or starting the test before they have visited the rooms
		Door = Door + 1;		//the new value for Door is the old value plus one.
	}
	void DoorOpen (){		//This function is activated when Answer has reached 14, it will be used to unlock the InsideDoor4 and the Entrance so that the Player can leave the building
		Door = Door - 1;		//The new value for Door is the old value minus one
	}

	void TestStart(){		//When a message is received from the Test script the new value for Test will be the old value plus one
		Test = Test + 1;
	}

	void TestRoomEnter(){		//When a message is received from the Test script the new value for TestDoor will be the old value plus one

		TestDoor = TestDoor + 1;
	}

	void TestRoomExit(){		//When answer is equal to 14, the function TestRoomExit will make the new value one less than the old.
		TestDoor = TestDoor - 1;
	}

	void WelcomeStart (){		//a message will have been sent from the WelcomeMessage script, which occurs at the start of the Welcome message. This prevents the player from going to the videos or notes before they listened to the message
		Welcome = Welcome + 1; //Welcome new value is the old value plus one
	}

	void WelcomeEnd (){		//a message will have been sent from the WelcomeMessage script, which occurs once the Welcome message has ended.
		Welcome = Welcome - 1;		//Welcome new value is the old value minus one
	}

	void WarmUpQuestion(){		//a message will be sent to this function from the Doors script when the Player interacts with the DoorParent trigger and coins=0
		if (Warm == false) {	//when the bool is false 
			Warmup = Warmup + 1;	// the next value for Warmup is the old value plus one
			Warm = true;		//by making the Warm bool true, it means that if the Player interacts with the DoorParent again, it will not increase WarmUp again
		}
	}

	void WarmUpStart(){		//a message will be sent to this function from the WarmUpQuestionApproach script, which occurs after the PLayer has received instruction on how to answer the questions
		Warmup = Warmup + 1;		//Warmup new value is its old value plus one
	}
		
}
