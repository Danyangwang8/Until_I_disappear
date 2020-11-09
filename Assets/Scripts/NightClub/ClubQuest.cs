using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class ClubQuest : MonoBehaviour {


	public GameObject clubEventPanel;
	public Sprite angerbanner;
	public Sprite harmonybanner;
	public Sprite beautybanner;
	public Text questText_eventPanel;
	public Text leftButtonText;
	public Text rightButtonText;
	public Button leftButton;
	public Button rightButton;
	private int randomIndex;

	public GameObject wheelResultPanel;
	public Text wheelResultInfo;

	//Wheel panel
	public GameObject wheelPanel;

	private Trigger trig;

	public bool leftbuttonclicked;
	public bool rightbuttonclicked;

	public int wheelResult;

	public Text fame_text, soul_text, vitality_text, money_text;

	private GameObject guiClubGameObject;
	private GUIClub guiClub;

	//access the Trigger class variables.
	private Trigger TriggerScriptToAccess;
	public GameObject WheelObject;
	private WheelController WheelScriptToAccess;
	private bool booleanScriptGetquest;


	public List<Quest> clubQuests;

	//The boost num for wheel
	public static int boostForWheel;

	//SearhNet panel opbjects
	public GameObject searchNetPanel;
	public Text headLine_searchpanel;
	public Text infoText_searchpanel;
	public Text buttonText_searchpanel;


	void Start () {

		clubEventPanel.SetActive (false);
		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);
		searchNetPanel.SetActive (false);


		questText_eventPanel.text = " ";
		leftButtonText.text = " ";
		rightButtonText.text = " ";
		wheelResultInfo.text = " ";

		guiClubGameObject = GameObject.Find ("GUIController");
		guiClub = guiClubGameObject.GetComponent<GUIClub> ();


		trig = wheelPanel.GetComponentInChildren<Trigger>();
		trig.OnWheelStopped += Trig_OnWheelStopped;

		clubQuests= new List<Quest> (Resources.LoadAll<Quest>("NightClubQuests"));
		//WheelScriptToAccess.InitWheelColor = 7;


		//SetUpResultPanel ();
	}



	private void Trig_OnWheelStopped(object sender, System.EventArgs e)
	{
		bool getquest = (bool)sender;
		Debug.Log("Get win/lose" + getquest);
		getquest = trig.GetQuest;
		// TODO Trigger WheelDone() with the getquest variable
		WheelDone();
	}


	public void ScriptableQuestPanelController(){

		questText_eventPanel.text = clubQuests [randomIndex].questText.ToString();
		leftButtonText.text = clubQuests [randomIndex].option1Text;
		rightButtonText.text = clubQuests [randomIndex].option2Text;

		if (clubQuests[randomIndex].StatTypeOne.ToString().Equals("ANGER")) {
			//left button image is anger
			leftButton.GetComponent<Image>().sprite = angerbanner;
		}

		if (clubQuests[randomIndex].StatTypeOne.ToString().Equals("HARMONY")) {
			leftButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (clubQuests[randomIndex].StatTypeOne.ToString().Equals("BEAUTY")) {
			leftButton.GetComponent<Image>().sprite = beautybanner;

		}
		if (clubQuests[randomIndex].StatTypeTwo.ToString().Equals("ANGER")) {
			rightButton.GetComponent<Image>().sprite = angerbanner;

		}
		if (clubQuests[randomIndex].StatTypeTwo.ToString().Equals("HARMONY")) {
			rightButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (clubQuests [randomIndex].StatTypeTwo.ToString().Equals("BEAUTY")) {
			rightButton.GetComponent<Image> ().sprite = beautybanner;
		}
	}

	public void GetClubEventClicked(){
		searchNetPanel.SetActive (false);
		randomIndex = Random.Range (0, clubQuests.Count);
		//EventPanelController ();
		if (guiClub.soul_num > 0 && guiClub.fame_num > 0 && guiClub.money_num > 0 && guiClub.vitality_num > 0) {
			ScriptableQuestPanelController ();

			clubEventPanel.SetActive (true);

		} else if(guiClub.vitality_num <= 0){

			guiClub.feedback_panel.SetActive (true);
			guiClub.feedback_text.text = "Your vitality is to low to continue!";
		} 
		else if (guiClub.soul_num <=0 || guiClub.fame_num <= 0){

			guiClub.feedback_panel.SetActive (true);
			guiClub.feedback_text.text = "Your stats are too low! \nPull yourself together";
			PlayerPrefs.SetString ("isFailed", "yes");

		}

	}

	public void AHBLeftButtonClicked(){

		//TODO instantiate wheel
		//Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);
		leftbuttonclicked = true;
		rightbuttonclicked = false;
		Debug.Log ( clubQuests[randomIndex].StatTypeOne.ToString());

		if (clubQuests[randomIndex].StatTypeOne.ToString().Equals("ANGER"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
			//boostForWheel = guiMall.anger_num;
			WheelController.ItemNumber = guiClub.anger_num;

		}
		else if (clubQuests[randomIndex].StatTypeOne.ToString().Equals("HARMONY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
			//boostForWheel = guiMall.harmony_num;
			WheelController.ItemNumber = guiClub.harmony_num;


		}
		else if (clubQuests[randomIndex].StatTypeOne.ToString().Equals("BEAUTY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
			//boostForWheel = guiMall.beauty_num;
			WheelController.ItemNumber = guiClub.beauty_num;


		}

		wheelPanel.SetActive (true);
		wheelResultPanel.SetActive (false);
		clubEventPanel.SetActive (false);

	}
	public void AHBRightButtonClicked(){

		rightbuttonclicked = true;
		leftbuttonclicked = false;

		if (clubQuests[randomIndex].StatTypeTwo.ToString().Equals("ANGER"))
		{

			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
			//boostForWheel = guiMall.anger_num;
			WheelController.ItemNumber = guiClub.anger_num;


		}
		else if (clubQuests[randomIndex].StatTypeTwo.ToString().Equals("HARMONY"))
		{

			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
			//boostForWheel = guiMall.harmony_num;
			WheelController.ItemNumber = guiClub.harmony_num;

		}
		else if (clubQuests[randomIndex].StatTypeTwo.ToString().Equals("BEAUTY"))
		{
			//WheelScriptToAccess.ItemNumber += guiMall.beauty_num;

			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
			//boostForWheel = guiMall.beauty_num;
			WheelController.ItemNumber = guiClub.beauty_num;

		}


		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (true);
		wheelResultPanel.SetActive (false);
		clubEventPanel.SetActive (false);
	}

	public void WheelResultDoneExit(){

		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);
	}

	IEnumerator ShowResult(){

		yield return new WaitForSeconds (1);
		wheelPanel.SetActive(false);
		wheelResultPanel.SetActive (true);

	}

	public void WheelDone(){

		SetUpResultPanel ();
		StartCoroutine (ShowResult ());

	}


	public void SetUpResultPanel(){

		if (leftbuttonclicked) {
			if (trig.GetQuest) { //leftbutton clicked and success
				wheelResultInfo.text = " SUCCESS \n "+clubQuests[randomIndex].option1positiveResult;

				if (clubQuests [randomIndex].Option1StatSucces.ToString ().Equals ("FAME")) {
					guiClub.fame_num += clubQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("fame_global", guiClub.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (clubQuests [randomIndex].Option1StatSucces.ToString ().Equals ("SOUL")) {
					guiClub.soul_num += clubQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("soul_global", guiClub.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (clubQuests [randomIndex].Option1StatSucces.ToString ().Equals ("VITALITY")) {
					guiClub.vitality_num += clubQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("vitality_global", guiClub.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (clubQuests [randomIndex].Option1StatSucces.ToString ().Equals ("MONEY")) {
					guiClub.money_num += clubQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("money_global", guiClub.money_num);
					StartCoroutine (StatChanged(money_text));

				}


			}

			if (!trig.GetQuest) { //leftbutton clicked and fail
				wheelResultInfo.text = "FAIL \n"+clubQuests[randomIndex].option1negativeResult;

				if (clubQuests [randomIndex].Option1StatFail.ToString ().Equals ("FAME")) {
					guiClub.fame_num += clubQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("fame_global", guiClub.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (clubQuests [randomIndex].Option1StatFail.ToString ().Equals ("SOUL")) {
					guiClub.soul_num += clubQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("soul_global", guiClub.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (clubQuests [randomIndex].Option1StatFail.ToString ().Equals ("VITALITY")) {
					guiClub.vitality_num += clubQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("vitality_global", guiClub.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (clubQuests [randomIndex].Option1StatFail.ToString ().Equals ("MONEY")) {
					guiClub.money_num += clubQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("money_global", guiClub.money_num);
					StartCoroutine (StatChanged(money_text));

				}


			}

		} 

		else if (rightbuttonclicked) {
			Debug.Log ("Right button "+wheelResult);
			if (trig.GetQuest) { // Success
				wheelResultInfo.text = "SUCCESS \n"+clubQuests[randomIndex].option2positiveResult;
				if (clubQuests [randomIndex].Option2StatSucces.ToString ().Equals ("FAME")) {
					guiClub.fame_num += clubQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("fame_global", guiClub.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (clubQuests [randomIndex].Option2StatSucces.ToString ().Equals ("SOUL")) {
					guiClub.soul_num += clubQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("soul_global", guiClub.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (clubQuests [randomIndex].Option2StatSucces.ToString ().Equals ("VITALITY")) {
					guiClub.vitality_num += clubQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("vitality_global", guiClub.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (clubQuests [randomIndex].Option2StatSucces.ToString ().Equals ("MONEY")) {
					guiClub.money_num += clubQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("money_global", guiClub.money_num);
					StartCoroutine (StatChanged(money_text));

				}
			}
			if (!trig.GetQuest) {//Fail
				wheelResultInfo.text = "FAIL \n" +clubQuests[randomIndex].option2negativeResult;
				if (clubQuests [randomIndex].Option2StatFail.ToString ().Equals ("FAME")) {
					guiClub.fame_num += clubQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("fame_global", guiClub.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (clubQuests [randomIndex].Option2StatFail.ToString ().Equals ("SOUL")) {
					guiClub.soul_num += clubQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("soul_global", guiClub.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (clubQuests [randomIndex].Option2StatFail.ToString ().Equals ("VITALITY")) {
					guiClub.vitality_num += clubQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("vitality_global", guiClub.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (clubQuests [randomIndex].Option2StatFail.ToString ().Equals ("MONEY")) {
					guiClub.money_num += clubQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("money_global", guiClub.money_num);
					StartCoroutine (StatChanged(money_text));

				}

			}

		}

	}

	public void ExitSearchNetPanelClicked(){
		searchNetPanel.SetActive (false);
	}

	public void DjClicked(){
		searchNetPanel.SetActive (true);
		headLine_searchpanel.text = "GET SOME ATTENTION AT THE DANCEFLOOR";
		infoText_searchpanel.text = "Hit the dancefloor and search for opportunities!\nSpend 1 hour and 1 vitality to search for something useful.";
		buttonText_searchpanel.text = "LET'S DANCE!";
	}


	IEnumerator StatChanged(Text myText){

		for(int i = 0; i<5 ; i++){
			yield return new WaitForSeconds (0.5f);
			if (i % 2 == 1)
				myText.color = new Color (0,0,0);
			else 
				myText.color = new Color (255f,255f,255f);

		}

	}


}



