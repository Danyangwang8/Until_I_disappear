using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class NewBedroomQuest : MonoBehaviour {


	public GameObject bedroomEventPanel;
	public Sprite angerbanner;
	public Sprite harmonybanner;
	public Sprite beautybanner;
	public Text questText_eventPanel;
	public Text leftButtonText;
	public Text rightButtonText;
	public Button leftButton;
	public Button rightButton;
	private int randomIndex;

	//SearhNet panel opbjects
	public GameObject searchNetPanel;
	public Text headLine_searchpanel;
	public Text infoText_searchpanel;
	public Text buttonText_searchpanel;


	public GameObject wheelResultPanel;
	public Text wheelResultInfo;

	//Wheel panel
	public GameObject wheelPanel;

	private Trigger trig;

	public bool leftbuttonclicked;
	public bool rightbuttonclicked;

	public int wheelResult;

	public Text fame_text, soul_text, vitality_text, money_tex;

	private GameObject guiBedroomGameObject;
	private GUIBedroom guiBedroom;

	private GameObject guiMallGameObject;
	private GUIMall guiMallScript;


	//access the Trigger class variables.
	private Trigger TriggerScriptToAccess;
	public GameObject WheelObject;
	private WheelController WheelScriptToAccess;
	private bool booleanScriptGetquest;


	public List<Quest> bedroomQuests;

	void Start () {

		bedroomEventPanel.SetActive (false);
		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);


		guiBedroomGameObject = GameObject.Find ("GUIController");
		guiBedroom = guiBedroomGameObject.GetComponent<GUIBedroom> ();

		guiMallGameObject = GameObject.Find ("GUIController");
		guiMallScript = guiMallGameObject.GetComponent<GUIMall> ();


		trig = wheelPanel.GetComponentInChildren<Trigger>();
		trig.OnWheelStopped += Trig_OnWheelStopped;

		bedroomQuests= new List<Quest> (Resources.LoadAll<Quest>("BedroomQuests"));

        WheelScriptToAccess = WheelObject.GetComponent<WheelController>();
       // WheelScriptToAccess.InitWheelColor = 9;
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

		bedroomEventPanel.SetActive (true);

	
		questText_eventPanel.text = bedroomQuests [randomIndex].questText.ToString();
		leftButtonText.text = bedroomQuests [randomIndex].option1Text;
		rightButtonText.text = bedroomQuests [randomIndex].option2Text;

		if (bedroomQuests[randomIndex].StatTypeOne.ToString().Equals("ANGER")) {
			leftButton.GetComponent<Image>().sprite = angerbanner;
		}

		if (bedroomQuests[randomIndex].StatTypeOne.ToString().Equals("HARMONY")) {
			leftButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (bedroomQuests[randomIndex].StatTypeOne.ToString().Equals("BEAUTY")) {
			leftButton.GetComponent<Image>().sprite = beautybanner;

		}
		if (bedroomQuests[randomIndex].StatTypeTwo.ToString().Equals("ANGER")) {
			rightButton.GetComponent<Image>().sprite = angerbanner;

		}
		if (bedroomQuests[randomIndex].StatTypeTwo.ToString().Equals("HARMONY")) {
			rightButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (bedroomQuests [randomIndex].StatTypeTwo.ToString().Equals("BEAUTY")) {
			rightButton.GetComponent<Image> ().sprite = beautybanner;
		}
	}

	public void GetBedroomEventClicked(){
		randomIndex = Random.Range (0, bedroomQuests.Count);

		if (guiBedroom.soul_num > 0 && guiBedroom.fame_num > 0 && guiBedroom.money_num > 0 && guiBedroom.vitality_num > 0) {
			ScriptableQuestPanelController ();
			bedroomEventPanel.SetActive (true);

			searchNetPanel.SetActive (false);
			wheelResultPanel.SetActive (false);

		}
		else if(guiBedroom.vitality_num <= 0){

			buttonText_searchpanel.text = "OK";
			searchNetPanel.SetActive (false);
			guiBedroom.feedback_panel.SetActive (true);
			guiBedroom.feedback_text.text = "Your vitality is too low.";
		} 
		else if (guiBedroom.soul_num <=0 || guiBedroom.fame_num <= 0){

			buttonText_searchpanel.text = "OK";
			searchNetPanel.SetActive (false);
			guiBedroom.feedback_panel.SetActive (true);
			guiBedroom.feedback_text.text = "Your have fucked up your soul and fame! Such a failiure. Numb!";
			PlayerPrefs.SetString ("isFailed", "yes");

		}


	
	}

	public void AHBLeftButtonClicked(){

		leftbuttonclicked = true;
		rightbuttonclicked = false;
		Debug.Log ( bedroomQuests[randomIndex].StatTypeOne.ToString());

		if (bedroomQuests[randomIndex].StatTypeOne.ToString().Equals("ANGER"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
			WheelController.ItemNumber = guiBedroom.anger_num;

		}
		else if (bedroomQuests[randomIndex].StatTypeOne.ToString().Equals("HARMONY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
			WheelController.ItemNumber = guiBedroom.harmony_num;


		}
		else if (bedroomQuests[randomIndex].StatTypeOne.ToString().Equals("BEAUTY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
			//WheelController.ItemNumber = guiMallScript.beauty_num;
			//NewMallQuest.boostForWheel = PlayerPrefs.GetInt("beauty_global",0);
			//NewMallQuest.boostForWheel = guiBedroom.beauty_num;
			WheelController.ItemNumber = guiBedroom.beauty_num;


		}

		wheelPanel.SetActive (true);
		wheelResultPanel.SetActive (false);
		bedroomEventPanel.SetActive (false);

	}
	public void AHBRightButtonClicked(){

		rightbuttonclicked = true;
		leftbuttonclicked = false;

		if (bedroomQuests[randomIndex].StatTypeTwo.ToString().Equals("ANGER"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
			//WheelController.ItemNumber = guiMallScript.anger_num;
			//NewMallQuest.boostForWheel = PlayerPrefs.GetInt("anger_global",0);
			//NewMallQuest.boostForWheel = guiBedroom.anger_num;
			WheelController.ItemNumber = guiBedroom.anger_num;


		}
		else if ( bedroomQuests[randomIndex].StatTypeTwo.ToString().Equals("HARMONY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
			//WheelController.ItemNumber = guiMallScript.harmony_num;
			//NewMallQuest.boostForWheel = PlayerPrefs.GetInt("harmony_global",0);
			//NewMallQuest.boostForWheel = guiBedroom.harmony_num;
			WheelController.ItemNumber = guiBedroom.harmony_num;

		}
		else if (bedroomQuests[randomIndex].StatTypeTwo.ToString().Equals("BEAUTY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
			//WheelController.ItemNumber = guiMallScript.beauty_num;
			//NewMallQuest.boostForWheel = PlayerPrefs.GetInt("beauty_global",0);
			//NewMallQuest.boostForWheel = guiBedroom.beauty_num;
			WheelController.ItemNumber = guiBedroom.beauty_num;

		}
			
		wheelPanel.SetActive (true);
		wheelResultPanel.SetActive (false);
		bedroomEventPanel.SetActive (false);
	}

	public void WheelResultDoneExit(){

		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);
		guiBedroom.vitality_num--;
		PlayerPrefs.SetInt ("vitality_global", guiBedroom.vitality_num);
		guiBedroom.time_num++;
		PlayerPrefs.SetInt ("time_global", guiBedroom.time_num);

		guiBedroom.StatController ();

		if(guiBedroom.canDoAction==false || guiBedroom.mallUnlocked || guiBedroom.clubUnlocked){

			guiBedroom.feedback_panel.SetActive (true);

		}
			
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
				wheelResultInfo.text = " SUCCESS \n "+bedroomQuests[randomIndex].option1positiveResult;

				if (bedroomQuests [randomIndex].Option1StatSucces.ToString ().Equals ("FAME")) {
					guiBedroom.fame_num += bedroomQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("fame_global", guiBedroom.fame_num);
					StartCoroutine (StatChanged(fame_text));
				}
				else if (bedroomQuests [randomIndex].Option1StatSucces.ToString ().Equals ("SOUL")) {
					guiBedroom.soul_num += bedroomQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("soul_global", guiBedroom.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (bedroomQuests [randomIndex].Option1StatSucces.ToString ().Equals ("VITALITY")) {
					guiBedroom.vitality_num += bedroomQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("vitality_global", guiBedroom.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (bedroomQuests [randomIndex].Option1StatSucces.ToString ().Equals ("MONEY")) {
					guiBedroom.money_num += bedroomQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("money_global", guiBedroom.money_num);
					StartCoroutine (StatChanged(money_tex));

				}


			}

			if (!trig.GetQuest) { //leftbutton clicked and fail
				wheelResultInfo.text = "FAIL \n"+bedroomQuests[randomIndex].option1negativeResult;

				if (bedroomQuests [randomIndex].Option1StatFail.ToString ().Equals ("FAME")) {
					guiBedroom.fame_num += bedroomQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("fame_global", guiBedroom.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (bedroomQuests [randomIndex].Option1StatFail.ToString ().Equals ("SOUL")) {
					guiBedroom.soul_num += bedroomQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("soul_global", guiBedroom.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (bedroomQuests [randomIndex].Option1StatFail.ToString ().Equals ("VITALITY")) {
					guiBedroom.vitality_num += bedroomQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("vitality_global", guiBedroom.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (bedroomQuests [randomIndex].Option1StatFail.ToString ().Equals ("MONEY")) {
					guiBedroom.money_num += bedroomQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("money_global", guiBedroom.money_num);
					StartCoroutine (StatChanged(money_tex));

				}


			}

		} 

		else if (rightbuttonclicked) {
			Debug.Log ("Right button "+wheelResult);
			if (trig.GetQuest) { // Success
				wheelResultInfo.text = "SUCCESS \n"+bedroomQuests[randomIndex].option2positiveResult;
				if (bedroomQuests [randomIndex].Option2StatSucces.ToString ().Equals ("FAME")) {
					guiBedroom.fame_num += bedroomQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("fame_global", guiBedroom.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (bedroomQuests [randomIndex].Option2StatSucces.ToString ().Equals ("SOUL")) {
					guiBedroom.soul_num += bedroomQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("soul_global", guiBedroom.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (bedroomQuests [randomIndex].Option2StatSucces.ToString ().Equals ("VITALITY")) {
					guiBedroom.vitality_num += bedroomQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("vitality_global", guiBedroom.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (bedroomQuests [randomIndex].Option2StatSucces.ToString ().Equals ("MONEY")) {
					guiBedroom.money_num += bedroomQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("money_global", guiBedroom.money_num);
					StartCoroutine (StatChanged(money_tex));

				}
			}
			if (!trig.GetQuest) {//Fail
				wheelResultInfo.text = "FAIL \n" +bedroomQuests[randomIndex].option2negativeResult;
				if (bedroomQuests [randomIndex].Option2StatFail.ToString ().Equals ("FAME")) {
					guiBedroom.fame_num += bedroomQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("fame_global", guiBedroom.fame_num);
					StartCoroutine (StatChanged(fame_text));

				}
				else if (bedroomQuests [randomIndex].Option2StatFail.ToString ().Equals ("SOUL")) {
					guiBedroom.soul_num += bedroomQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("soul_global", guiBedroom.soul_num);
					StartCoroutine (StatChanged(soul_text));

				}
				else if (bedroomQuests [randomIndex].Option2StatFail.ToString ().Equals ("VITALITY")) {
					guiBedroom.vitality_num += bedroomQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("vitality_global", guiBedroom.vitality_num);
					StartCoroutine (StatChanged(vitality_text));

				}
				else if (bedroomQuests [randomIndex].Option2StatFail.ToString ().Equals ("MONEY")) {
					guiBedroom.money_num += bedroomQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("money_global", guiBedroom.money_num);
					StartCoroutine (StatChanged(money_tex));

				}

			}

		}

	}


	public void ExitSearchNetPanelClicked(){
		searchNetPanel.SetActive (false);
	}

	public void ComputerClicked(){
		searchNetPanel.SetActive (true);
		headLine_searchpanel.text = "SEARCH THE NET FOR ATTENTION";
		infoText_searchpanel.text = "The internet and SoMe are your opportunity to leave this place behind.\nSpend 1 hour and 1 vitality to search for something useful.";
		buttonText_searchpanel.text = "START";
	}


	IEnumerator StatChanged(Text myText){

		for(int i = 0; i<5 ; i++){
			yield return new WaitForSecondsRealtime (0.5f);
			if (i % 2 == 1)
				myText.color = new Color (0,0,0);
			else 
				myText.color = new Color (255f,255f,255f);

		}

	}


}



