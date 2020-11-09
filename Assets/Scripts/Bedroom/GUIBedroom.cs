using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;


public class GUIBedroom : MonoBehaviour {

	//Math gui objects
	public Text fame_text, soul_text, vitality_text, money_text, luck_text, time_text, day_text, time_on_panel;
	public int fame_num, soul_num, vitality_num, money_num, time_num, day_num;
	private double luck_num;

	//Sleep panel objects
	public GameObject sleepPanel;
	public Text headLine;
	public Text infoText;
	public Text buttonText;
	public GameObject xButton;


	//Travel panel object	
	public GameObject travelPanel;
	public Text headLine_travelpanel;
	public Text infoText_travelpanel;
	public Text buttonText_travelpanel;

	//Anger, Harmony, Beauty
	public Text anger_text, harmony_text, beauty_text;
	public int anger_num, harmony_num, beauty_num;

	//Feedback panel
	public GameObject feedback_panel;
	public Text feedback_text;
	private bool isSceneChange;

	public bool canDoAction=true;



	private bool isSleeping=false;
	private bool isSearching=false;
	private bool isTraveling =true;
	private bool isTravelingToClub=true;
	private float secondsCount;

	public GameObject clock;

	private int maxVitality=10;
	private int fameLimitToMall=5;
	private int fameLimitToClub=10;

	public static bool gameEnded=false;

	public static bool beenInMall;
	public static bool beenInClub;

	public bool mallUnlocked=false;
	public bool clubUnlocked=false;


	void Start () {

		//Setup starting panels
		sleepPanel.SetActive (false);

		travelPanel.SetActive (false);

		if (OnStartGame.gameStarted == true) {
			feedback_panel.SetActive (true);
			feedback_text.text = "Use your computer to \nshake of your social anxiety. \nRaise your fame to 5 - this should give you the confidence to go to the mall. ";
		} 
		else {
			feedback_panel.SetActive (false);
		}

		OnStartGame.gameStarted = false;
		CutSceneController.comingSceneNo = 1;



		clock.SetActive(false);
		gameEnded = false;

	//	StatInit (); //comment out before build

		time_num = PlayerPrefs.GetInt("time_global",8);
		fame_num = PlayerPrefs.GetInt("fame_global",5);
		soul_num = PlayerPrefs.GetInt("soul_global",5);
		vitality_num= PlayerPrefs.GetInt("vitality_global",10);
		money_num = PlayerPrefs.GetInt("money_global",5);
		day_num = PlayerPrefs.GetInt("day_global",1);

		beauty_num = PlayerPrefs.GetInt ("beauty_global", 1);
		anger_num = PlayerPrefs.GetInt ("anger_global", 1);
		harmony_num = PlayerPrefs.GetInt ("harmony_global", 1);

		PlayerPrefs.SetString ("isFailed", "no");
	}
	
	void Update () {

		fame_text.text = fame_num.ToString ();
		soul_text.text = soul_num.ToString ();
		vitality_text.text = vitality_num.ToString ();
		money_text.text = money_num.ToString ();
		day_text.text = day_num.ToString ();
		luck_text.text = "%"+(luck_num * 100).ToString ();
		time_text.text = time_num +":00" ;

		beauty_text.text = beauty_num.ToString ();
		anger_text.text = anger_num.ToString ();
		harmony_text.text = harmony_num.ToString ();

		time_on_panel.text = time_text.text + ":00";

		DayController ();
		StatController ();
	}
		
	public void FeedbackOnClick(){

		feedback_panel.SetActive (false);

		if (isSceneChange) {
			SceneManager.LoadScene ("Bedroom Final");

		}
		if (PlayerPrefs.GetString ("isFailed", "no").Equals ("yes")) {
			SceneManager.LoadScene ("Bedroom Final");
			time_num= 8;
			PlayerPrefs.SetInt ("time_global", time_num);

			fame_num = 5;
			PlayerPrefs.SetInt ("fame_global", fame_num);

			soul_num = 8;
			PlayerPrefs.SetInt ("soul_global", soul_num);

			vitality_num = 10;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);

			money_num=5;
			PlayerPrefs.SetInt ("money_global", money_num);

			day_num = day_num+1;
			PlayerPrefs.SetInt ("day_global", day_num);

		}
		if(gameEnded){
			CutSceneController.sceneToLoad = "Splash";
			SceneManager.LoadScene ("Cutscene");

		}
	}

	public void DoorClicked(){

		isTravelingToClub = false;

		if (canDoAction) {

			if (fame_num >= fameLimitToMall) {
				headLine_travelpanel.text = "GO TO THE MALL";
				infoText_travelpanel.text = "Where the young and beautiful go to hang out, and those fortunate enough to have money can buy goods to enrich their lives.\n \nIt will cost you 1 vitality and 1 hour to travel to the mall.";
				buttonText_travelpanel.text = " GO ";
				isTraveling = true;

			} else {
				headLine_travelpanel.text = "THE MALL";
				infoText_travelpanel.text = "You do not have the confidence to go outside,\nraise your fame to 5 to go to the mall.";
				buttonText_travelpanel.text = "OK";
			
			}

			travelPanel.SetActive (true);
		} else {
		
			//StatController ();
			feedback_panel.SetActive(true);
		}
	}

	public void GoTravelClicked(){

		if (isTraveling && fame_num >= fameLimitToMall) {
			time_num++;
			PlayerPrefs.SetInt ("time_global", time_num);
			vitality_num--;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);
			CutSceneController.sceneToLoad = "mall";
			if (!beenInMall) {
				SceneManager.LoadScene ("Cutscene");
			} 
			else {
				SceneManager.LoadScene ("mall");
			}
		} 
		else if(isTravelingToClub && fame_num >= fameLimitToClub ){
			time_num++;
			PlayerPrefs.SetInt ("time_global", time_num);
			vitality_num--;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);
			CutSceneController.sceneToLoad = "Nightclub";

			if (!beenInClub) {
				SceneManager.LoadScene ("Cutscene");
			} else {
				SceneManager.LoadScene ("Nightclub");
			}

		}
			
		else {
			travelPanel.SetActive (false);
		}
	}

	public void GoToClubOnClick(){
		isTraveling = false;

		if (fame_num >= fameLimitToClub) {
			
			headLine_travelpanel.text= "THE NIGHTCLUB";
			infoText_travelpanel.text = "The exclusive playground of the rich and the famous. The picker opens up the door for you. Welcome!";
			buttonText_travelpanel.text = "OK";
			travelPanel.SetActive (true);
			isTravelingToClub = true;
		}
		else {
		
			headLine_travelpanel.text= "THE NIGHTCLUB";
			infoText_travelpanel.text = "The exclusive playground of the rich and the famous. The picker would never allow a nobody like you access to the nightclub.";
			buttonText_travelpanel.text = "OK";
			travelPanel.SetActive (true);
			isTravelingToClub = false;
		}
	
	}

	public void TravelPanelX(){
		travelPanel.SetActive (false);
	}
		

	public void BedClicked(){

		sleepPanel.SetActive (true);

		if (canDoAction) {

			headLine.text = "THE BED";
			infoText.text = "The bed is where you regain your vitality. \n Every hour you spend here you will regain 1 vitality.";
			buttonText.text = "SLEEP";
			clock.SetActive (false);
			xButton.SetActive (true);
		} 
		else {
		
			feedback_panel.SetActive (true);
		}

	}

	public void StartSleepButtonClicked(){

		if (!isSleeping && vitality_num < maxVitality) {
			Debug.Log ("startclicked");
			infoText.text = "Sleeping..ZzZ..zZ..";
			buttonText.text = "WAKE UP";
			isSleeping = true;
			clock.SetActive (true);
			xButton.SetActive (false);

			StartCoroutine (TimeController ());

		} else if (isSleeping ) {
			isSleeping = false;
			StopCoroutine (TimeController ());
			sleepPanel.SetActive (false);
			clock.SetActive (false);
			xButton.SetActive (true);
		
		} 

		else if (!isSleeping && vitality_num >= maxVitality) {

			infoText.text = "You are at maximum vitality.\nSleep is for old people.";
            buttonText.text = "OK";
			isSleeping = true;
			clock.SetActive (false);
			xButton.SetActive (true);

		} else {
		
			//infoText.text = "test";

		}
	}

	IEnumerator TimeController(){

		while (isSleeping && vitality_num < maxVitality ) {
				yield return new WaitForSeconds (2);
				time_num++;
				PlayerPrefs.SetInt ("time_global", time_num);
				vitality_num++;
				PlayerPrefs.SetInt ("vitality_global", vitality_num);
		}

		if(vitality_num >=maxVitality){
			infoText.text = "You are at maximum vitality.\nSleep is for old people.";
			buttonText.text = "OK";
			isSleeping = true;
			clock.SetActive (false);
			xButton.SetActive (true);

		}
	}


	public void ExitSleepPanelClicked(){
		isSleeping = false;
		sleepPanel.SetActive (false);

	}

		

	public void DayController(){
		if (time_num != 0 && time_num % 24 == 0 ) {
			day_num++;
			time_num = 0;
			PlayerPrefs.SetInt ("time_global", time_num);
			PlayerPrefs.SetInt ("day_global", day_num);

			infoText_travelpanel.text = "The day has ended and it is time for a new one to begin. You feel the weight of the world on your shoulders. \n-1 soul";
			headLine_travelpanel.text = "END OF THE DAY";
			buttonText_travelpanel.text = "OK";
			isTraveling = false;
			isTravelingToClub = false;
			travelPanel.SetActive (true);
			soul_num--;
			PlayerPrefs.SetInt ("soul_global", soul_num);
		}
	
	}

	public void StatController(){


		if ((vitality_num) <= 2) {

			StatInDanger (vitality_text);
			if((vitality_num) <= 0){

			feedback_text.text = "You have no more vitality. You pass out of stress and wake up exhausted on the floor of your bedroom. You have no idea how you ended here. All your money and accessories have been stolen. Life sucks.";
			//feedback_panel.SetActive (true);
			//isSceneChange = true;
			PlayerPrefs.SetString ("isFailed", "yes");
				canDoAction = false;
			}

		}else if(soul_num <= 2){

			StatInDanger (soul_text);

			if (soul_num <= 0) {

			//feedback_panel.SetActive (true);
				feedback_text.text = "You have used up your soul. You remember nothing but a weird humming sound for of the next couple of hours and wake up sitting in your shower. All your money and accessories have been stolen. Life sucks.";
				PlayerPrefs.SetString ("isFailed", "yes");
				canDoAction = false;

			}
		}else  if(money_num <= 2){

			StatInDanger (money_text);

			if (money_num <= 0) {

			//feedback_panel.SetActive (true);
				feedback_text.text = "You have spent too much money. The only way to solve this is to call your mom. Life sucks.";
			PlayerPrefs.SetString ("isFailed", "yes");
			}
		}  
		else if(fame_num <= 2){

				StatInDanger (fame_text);

				if (fame_num <= 0) {
					
					//feedback_panel.SetActive (true);
					feedback_text.text = "Your fame has faded away. You suffer a panic attack and find yourself shaking under your bed. You have no idea how you ended here. All your money and accessories have been stolen. Life sucks.";
					PlayerPrefs.SetString ("isFailed", "yes");
					canDoAction = false;

				}
		} else if(fame_num >= 5 && fame_num <10 &&!mallUnlocked){
			feedback_text.text = "Good job raising your fame. \n You can go to the mall now. ";
			//feedback_panel.SetActive (true);
			mallUnlocked = true;
		}

		else if(fame_num >= 10 && !clubUnlocked){
			feedback_text.text = "Good job raising your fame. \n You can go to the club now. ";
			//feedback_panel.SetActive (true);
			clubUnlocked = true;
		}

		if (fame_num >= 30) {
		
			gameEnded = true;
			feedback_text.text = "You have done it! Your fame has reached out to 30. This is a story to be told. Think about your actions that lead you to this point.";
			feedback_panel.SetActive (true);
		}
	}
		

	IEnumerator StatInDanger(Text myText){

		for(int i = 0; i<5 ; i++){
			yield return new WaitForSecondsRealtime (1);
			if (i % 2 == 1)
				myText.color = new Color (0,0,0);
			else 
				myText.color = new Color (255f,255f,255f);

		}

	}


}
