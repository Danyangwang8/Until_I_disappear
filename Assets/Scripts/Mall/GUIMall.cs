using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;


public class GUIMall : MonoBehaviour {

	//Math gui objects
	public Text fame_text, soul_text, vitality_text, money_text, luck_text, time_text, day_text,time_on_panel;
	public int fame_num, soul_num, vitality_num, money_num, time_num, day_num;
	private double luck_num;

	//Anger, Harmony, Beauty
	public Text anger_text, harmony_text, beauty_text;
	public int anger_num, harmony_num, beauty_num;


	//Eat Panel
	public GameObject eatPanel;
	public Text eatInfo;
	public Text buttonText;
	private bool isEating;
	public GameObject clock_eat;
	public GameObject xEatButton;


	//Work Panel
	public GameObject workPanel;
	public Text workInfo;
	public Text workButtonText;
	private bool isWorking;
	public GameObject xWorkButton;
	public GameObject clock;


	//Accesories panel
	public GameObject itemPanel;

	public GameObject itemPanel1;
	public Text itemTitle1;
	public GameObject itemImage1;
	public Text itemBoost1;
	public Text itemMoney1;
	public Button buy1;

	public GameObject itemPanel2;
	public Text itemTitle2;
	public GameObject itemImage2;
	public Text itemBoost2;
	public Text itemMoney2;
	public Button buy2;

	public GameObject itemPanel3;
	public Text itemTitle3;
	public GameObject itemImage3;
	public Text itemBoost3;
	public Text itemMoney3;
	public Button buy3;

	private int itemIndex1;
	private int itemIndex2;
	private int itemIndex3;

	private List<Accessory> itemsOfDay;

	//Audios
	public AudioSource failSound;
	public AudioSource successSound;

	public List<Accessory> items;

	//Feedback panel
	public GameObject feedback_panel;
	public Text feedback_text;
	public bool isSceneChange;

	//Travel panel object	
	public GameObject travelPanel;
	public Text headLine_travelpanel;
	public Text infoText_travelpanel;
	public Text buttonText_travelpanel;


	//Scroll panel of bought items
	public GameObject scrollPanel;
	public GameObject scrollItem1;
	public GameObject scrollItem2;
	public GameObject scrollItem3;

	//The item to show on picture
	public static Sprite bouthItem;

	private int maxMoney = 15;

	public bool canDoAction=true;

	public bool clubUnlocked=false;


	void Start () {

		//Eat panel initilize
		eatPanel.SetActive(false);
		isEating = false;

		//Work panel initialize
		workPanel.SetActive(false);
		isWorking = false;


		//Accessory panel initialize
		itemPanel.SetActive (false);
		itemPanel1.SetActive (true);
		itemPanel2.SetActive (true);
		itemPanel3.SetActive (true);

		feedback_panel.SetActive (true);
		if(fame_num <10)
			feedback_text.text = "You made it to the mall.\nNow raise your fame to 10, then the picker will let you into the nightclub.";

		isSceneChange = false;

		time_num = PlayerPrefs.GetInt("time_global",8);
		fame_num = PlayerPrefs.GetInt("fame_global",2);
		soul_num = PlayerPrefs.GetInt("soul_global",5);
		vitality_num= PlayerPrefs.GetInt("vitality_global",10);
		money_num = PlayerPrefs.GetInt("money_global",5);
		day_num = PlayerPrefs.GetInt("day_global",1);
		beauty_num = PlayerPrefs.GetInt("beauty_global",5);
		harmony_num = PlayerPrefs.GetInt("harmony_global",5);
		anger_num = PlayerPrefs.GetInt("anger_global",5);

		PlayerPrefs.SetString ("isFailed", "no");

		//items setting
		items= new List<Accessory> (Resources.LoadAll<Accessory>("NewAccessories"));
		Debug.Log ("Number of accesories: "+ items.Count);


		OnStartGame.gameStarted = false;
		CutSceneController.comingSceneNo = 2;
		GUIBedroom.beenInMall = true;

		SetCards();

	}

	void Update () {

		fame_text.text = fame_num.ToString ();
		soul_text.text = soul_num.ToString ();
		vitality_text.text = vitality_num.ToString ();
		money_text.text = money_num.ToString ();
		day_text.text = day_num.ToString ();
		luck_text.text = "%"+(luck_num * 100).ToString ();
		time_text.text = time_num + ":00" ;

		beauty_text.text = beauty_num.ToString ();
		anger_text.text = anger_num.ToString ();
		harmony_text.text = harmony_num.ToString ();

		time_on_panel.text = time_text.text + ":00";

		DayController ();
		StatController ();
	}

	private void DayController(){

		if (time_num != 0 && time_num % 24 == 0) {
			day_num++;
			time_num = 0;
			PlayerPrefs.SetInt ("time_global", time_num);
			PlayerPrefs.SetInt ("day_global", day_num);
			itemsOfDay.Clear();
			SetCards ();
			itemPanel1.SetActive (true);
			itemPanel2.SetActive (true);
			itemPanel3.SetActive (true);

			feedback_text.text = "A new day begins. You feel the weight of the world on your shoulders. \n-1 soul";
			feedback_panel.SetActive (true);
			soul_num--;
			PlayerPrefs.SetInt ("soul_global", soul_num);
			vitality_num = vitality_num - 0;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);

		}

	}

	public void DoorClicked(){

		headLine_travelpanel.text= "GO TO BEDROOM";
		infoText_travelpanel.text = "Go home. It will cost you 1 vitality and 1 hour to travel home to your bedroom.";
		buttonText_travelpanel.text = "GO";

		travelPanel.SetActive (true);
	}

	public void GoTravelClicked(){

		time_num++;
		PlayerPrefs.SetInt ("time_global", time_num);
		vitality_num--;
		PlayerPrefs.SetInt ("vitality_global", vitality_num);
		//money_num--;
		//PlayerPrefs.SetInt ("money_global", money_num);
		SceneManager.LoadScene ("Bedroom Final");

	}

	public void XTravelPanel(){
		travelPanel.SetActive (false);

	}

	IEnumerator TimeControllerEat(){

		while (isEating && money_num>0) {
			yield return new WaitForSeconds (2);
			time_num++;
			PlayerPrefs.SetInt ("time_global", time_num);
			vitality_num= vitality_num+3;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);
			money_num= money_num -2;
			PlayerPrefs.SetInt ("money_global", money_num);

		}
		if (money_num <= 0) {
			eatInfo.text = "Poor thing.\nYou don't have enough money to eat.";
			buttonText.text = "OK";
			isEating = true;
		}

	}
		
	public void SaladBarClicked(){
		

		if (money_num <= 0) {
			eatInfo.text = "You do not have enough money to eat.";
			buttonText.text = "DONE";
			isEating = true;
		}
		else {
			eatInfo.text = "Salad. It is really healthy.\nspend 1 money to gain 3 vitality.";
			buttonText.text = "EAT";
		
		}
		eatPanel.SetActive (true);
		clock_eat.SetActive (false);
		xEatButton.SetActive (true);
	}

	public void StartEatingClicked(){
		if (money_num > 0) {
			if (!isEating) {
				Debug.Log ("startclicked");
				eatInfo.text = "Eating...va.fw.RV W..RVW.";
				buttonText.text = "STOP";
				isEating = true;
				clock_eat.SetActive (true);
				StartCoroutine (TimeControllerEat ());
				OneTimeEat();
				xEatButton.SetActive (false);

			} else if (isEating) {
				isEating = false;
				StopCoroutine (TimeControllerEat ());
				eatPanel.SetActive (false);
				clock_eat.SetActive (false);
			}

		} else if (money_num <= 0) {
			if (!isEating) {
				Debug.Log ("startclicked");
				eatInfo.text = "You do not have enough money to eat.";
				buttonText.text = "DONE";
				isEating = true;

			} else if (isEating) {
				isEating = false;
				eatPanel.SetActive (false);
			}
				
		}
	
	}

	public void OneTimeEatClicked(){
		OneTimeEat ();
		eatPanel.SetActive (false);

	}

	private void OneTimeEat(){
		if (money_num>0) {
			time_num++;
			PlayerPrefs.SetInt ("time_global", time_num);
			vitality_num= vitality_num+3;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);
			money_num= money_num -1;
			PlayerPrefs.SetInt ("money_global", money_num);

		}

	
	}

	public void XEatClicked(){
		eatPanel.SetActive (false);
	}

	 
	IEnumerator TimeControllerWork(){

		while (isWorking && money_num<maxMoney && vitality_num >1) {
			yield return new WaitForSeconds (2);
			time_num++;
			PlayerPrefs.SetInt ("time_global", time_num);
			vitality_num= vitality_num-1;
			PlayerPrefs.SetInt ("vitality_global", vitality_num);
			money_num = money_num +2;
			PlayerPrefs.SetInt ("money_global", money_num);

		}
		if (money_num >= maxMoney) {
			workInfo.text = "The janitor does not need your help right now.";
			workButtonText.text = "DONE";
			clock.SetActive (false);
			isWorking = true;
		}
		if (vitality_num <= 0) {
			workInfo.text = "Go home and sleep, or eat in the salad bar.\nYou are low on vitality!";
			workButtonText.text = "DONE";
			isWorking = true;
			clock.SetActive (false);
		}

	}

	public void WorkClicked(){
		workInfo.text = "The janitor needs your help cleaning the floors.\nEach hour you work for the janitor you will lose 1 vitality and gain 2 money.";
		workButtonText.text = "WORK";
		workPanel.SetActive (true);
		xWorkButton.SetActive (true);
		clock.SetActive (false);

	}

	public void StartWorkingClicked(){
		if (money_num < maxMoney || vitality_num >1) {
			if (!isWorking) {
				workInfo.text = "Cleaning floors..";
				workButtonText.text = "STOP";
				isWorking = true;
				xWorkButton.SetActive (false);
				clock.SetActive (true);
				StartCoroutine (TimeControllerWork ());

			} else if (isWorking) {
				isWorking = false;
				StopCoroutine (TimeControllerWork ());
				workPanel.SetActive (false);
			}

		} else if (money_num >= maxMoney) {
			if (!isWorking) {
				workInfo.text = "The janitor does not need your help right now.";
				workButtonText.text = "OK";
				clock.SetActive (false);
				isWorking = true;

			} else if (isWorking) {
				isWorking = false;
				workPanel.SetActive (false);
			}
		}
		else if (vitality_num <=  0) {
			if (!isWorking) {
				workInfo.text = "Go home and sleep, or eat in the salad bar.\nYou are low on vitality!";
				workButtonText.text = "OK";
				isWorking = true;

			} else if (isWorking) {
				isWorking = false;
				workPanel.SetActive (false);
			}
		}
	}

	public void XWorkClicked(){
		workPanel.SetActive (false);
	}
		

	private void SetCards(){
	
		itemsOfDay = new List<Accessory> ();

		itemIndex1 = Random.Range (0,items.Count) ;
		itemIndex2 = Random.Range (0,items.Count) ;
		itemIndex3 = Random.Range (0,items.Count) ;


		itemsOfDay.Add (items [itemIndex1]);
		itemsOfDay.Add (items [itemIndex2]);
		itemsOfDay.Add (items [itemIndex3]);

		if (itemsOfDay [0] != null) {
			itemTitle1.text = itemsOfDay [0].Title.ToUpper ();
			itemImage1.GetComponent<Image> ().sprite = itemsOfDay [0].Picture;
			itemBoost1.text = itemsOfDay [0].Boost.ToString () + "  " + items [itemIndex1].StatType.ToString ();
			itemMoney1.text = itemsOfDay [0].Price.ToString () + " MONEY";  
		
		} else {
			
			itemPanel1.SetActive(false);
		}  

		if (itemsOfDay [1] != null) {
			itemTitle2.text = itemsOfDay [1].Title.ToUpper ();
			itemImage2.GetComponent<Image> ().sprite = itemsOfDay [1].Picture;
			itemBoost2.text = itemsOfDay [1].Boost.ToString () + " " + items [itemIndex2].StatType.ToString ();
			itemMoney2.text = itemsOfDay [1].Price.ToString () + " MONEY"; 

		} else {
		
			itemPanel2.SetActive (false);
		}
		if (itemsOfDay [2] != null) {
			itemTitle3.text = itemsOfDay [2].Title.ToUpper();
			itemImage3.GetComponent<Image> ().sprite = itemsOfDay [2].Picture;
			itemBoost3.text = itemsOfDay [2].Boost.ToString() + " " + items [itemIndex3].StatType.ToString();
			itemMoney3.text = itemsOfDay [2].Price.ToString() + " MONEY"; 

		}

	
	}


	public void AccessoryOnClick(){
		//SetItemCards ();
		//SetCards();
		itemPanel.SetActive (true);

	}

	public void Item1BuyOnClick(){


		if(money_num >= itemsOfDay[0].Price){

			if (itemsOfDay[0].StatType.Equals (EStatTypes.BEAUTY)) {

				beauty_num = beauty_num + itemsOfDay[0].Boost;
				PlayerPrefs.SetInt ("beauty_global", beauty_num);

			}
			else if (itemsOfDay[0].StatType.Equals (EStatTypes.ANGER)) {

				anger_num = anger_num +itemsOfDay[0].Boost;
				PlayerPrefs.SetInt ("anger_global", anger_num);

			}
			else if (itemsOfDay[0].StatType.Equals (EStatTypes.HARMONY)) {

				harmony_num = harmony_num + itemsOfDay[0].Boost;
				PlayerPrefs.SetInt ("harmony_global", harmony_num);

			}

			money_num -= itemsOfDay[0].Price;

			successSound.Play ();
			items.RemoveAt (itemIndex1);
			itemPanel1.SetActive (false);

			scrollItem1.GetComponent<Image> ().sprite = itemsOfDay [0].Picture;

		}
		else  {

			//TODO feedback panel cannot buy the item
			Debug.Log("cannot buy the item");
			failSound.Play ();

		}

			

	}

	public void Item2BuyOnClick(){
		

		if(money_num >= itemsOfDay[1].Price){

			if (itemsOfDay[1].StatType.Equals (EStatTypes.BEAUTY)) {

				beauty_num = beauty_num + itemsOfDay[1].Boost;
				PlayerPrefs.SetInt ("beauty_global", beauty_num);

			}
			else if (itemsOfDay[1].StatType.Equals (EStatTypes.ANGER)) {

				anger_num = anger_num +itemsOfDay[1].Boost;
				PlayerPrefs.SetInt ("anger_global", anger_num);

			}
			else if (itemsOfDay[1].StatType.Equals (EStatTypes.HARMONY)) {

				harmony_num = harmony_num + itemsOfDay[1].Boost;
				PlayerPrefs.SetInt ("harmony_global", harmony_num);

			}

			money_num -= itemsOfDay[1].Price;
			successSound.Play ();

			items.RemoveAt (itemIndex2);
			itemPanel2.SetActive (false);

			scrollItem2.GetComponent<Image> ().sprite = itemsOfDay [1].Picture;


		}
		else  {

			//TODO feedback panel cannot buy the item
			Debug.Log("cannot buy the item");
			failSound.Play ();

		}
	}

	public void Item3BuyOnClick(){


		if(money_num >= itemsOfDay[2].Price){

			if (itemsOfDay[2].StatType.Equals (EStatTypes.BEAUTY)) {

				beauty_num = beauty_num + itemsOfDay[2].Boost;
				PlayerPrefs.SetInt ("beauty_global", beauty_num);

			}
			else if (itemsOfDay[2].StatType.Equals (EStatTypes.ANGER)) {

				anger_num = anger_num +itemsOfDay[2].Boost;
				PlayerPrefs.SetInt ("anger_global", anger_num);

			}
			else if (itemsOfDay[2].StatType.Equals (EStatTypes.HARMONY)) {

				harmony_num = harmony_num + itemsOfDay[2].Boost;
				PlayerPrefs.SetInt ("harmony_global", harmony_num);

			}

			money_num -= itemsOfDay[2].Price;
			successSound.Play ();

			items.RemoveAt (itemIndex3);
			itemPanel3.SetActive (false);

			scrollItem3.GetComponent<Image> ().sprite = itemsOfDay [2].Picture;


		}
		else  {

			//TODO feedback panel cannot buy the item
			Debug.Log("cannot buy the item");
			failSound.Play ();

		}
	}

	public void DoneClicked(){
	
		itemPanel.SetActive (false);
		PlayerPrefs.SetInt ("money_global", money_num);

	}

	public void ExitMallOnClick(){

		OnStartGame.gameStarted = false;

		SceneManager.LoadScene ("Bedroom Final");

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

			money_num=8;
			PlayerPrefs.SetInt ("money_global", money_num);

			day_num = day_num+1;
			PlayerPrefs.SetInt ("day_global", day_num);

		}
		if(GUIBedroom.gameEnded){
			CutSceneController.sceneToLoad = "Splash";
			SceneManager.LoadScene ("Cutscene");

		}
	}

	public void StatController(){

		if ((vitality_num) <= 0) {

			feedback_text.text = "You have no more vitality. You pass out of stress and wake up exhausted on the floor of your bedroom. You have no idea how you ended here. All your money and accessories have been stolen. Life sucks.";
			//feedback_panel.SetActive (true);
			//isSceneChange = true;
			PlayerPrefs.SetString ("isFailed", "yes");
			canDoAction = false;

		}
		else if (soul_num <=0){

			//feedback_panel.SetActive (true);
			feedback_text.text = "You have used all your soul. You remember nothing but a weird humming sound for of the next couple of hours and wake up sitting in your shower. All your money and accessories have been stolen. Life sucks.";
			PlayerPrefs.SetString ("isFailed", "yes");
			canDoAction = false;

		}
		else if (money_num <= 0)
		{

			//feedback_panel.SetActive(true);
			feedback_text.text = "You have spend too much money. The only way to solve this is to call your mom or work harder. Life sucks. ";
			//PlayerPrefs.SetString("isFailed", "yes");
			canDoAction = false;

		}
		else if (fame_num <= 0)
		{
			//feedback_panel.SetActive(true);
			feedback_text.text = "Your fame has faded away. You suffer a panic attack and find yourself shaking under your bed. You have no idea how you ended here. All your money and accessories have been stolen. Life sucks.";
			PlayerPrefs.SetString("isFailed", "yes");
			canDoAction = false;

		}

		if(fame_num >= 10 && !clubUnlocked){
			feedback_text.text = "Good job raising your fame. \n You can go to the club now. ";
			//feedback_panel.SetActive (true);
			clubUnlocked = true;
		}

		if (fame_num >= 30) {

			GUIBedroom.gameEnded = true;
			feedback_text.text = "You did it, people know your name now.";
			feedback_panel.SetActive (true);
		
		}
	}


	public void ScrolItem1OnClick(){
	
	//TODO take a photo with item
		bouthItem = itemsOfDay [0].Picture;

		SceneManager.LoadScene ("TakeASelfie");
	}

	public void ScrolItem2OnClick(){

		//TODO take a photo with item
		bouthItem = itemsOfDay [1].Picture;

		SceneManager.LoadScene ("TakeASelfie");
	}

	public void ScrolItem3OnClick(){

		//TODO take a photo with item
		bouthItem = itemsOfDay [2].Picture;

		SceneManager.LoadScene ("TakeASelfie");
	}




}
