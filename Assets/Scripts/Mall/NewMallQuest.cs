using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class NewMallQuest : MonoBehaviour {


	public GameObject mallEventPanel;
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

	private GameObject guiMallGameObject;
	private GUIMall guiMall;

	//access the Trigger class variables.
	private Trigger TriggerScriptToAccess;
	public GameObject WheelObject;
	private WheelController WheelScriptToAccess;
	private bool booleanScriptGetquest;

	//SearhNet panel opbjects
	public GameObject searchNetPanel;
	public Text headLine_searchpanel;
	public Text infoText_searchpanel;
	public Text buttonText_searchpanel;

	public List<Quest> mallQuests;

	//The boost num for wheel
	public static int boostForWheel;

	void Start () {

		mallEventPanel.SetActive (false);
		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);
		searchNetPanel.SetActive (false);

		questText_eventPanel.text = " ";
		leftButtonText.text = " ";
		rightButtonText.text = " ";
		wheelResultInfo.text = " ";

		guiMallGameObject = GameObject.Find ("GUIController");
		guiMall = guiMallGameObject.GetComponent<GUIMall> ();


		trig = wheelPanel.GetComponentInChildren<Trigger>();
		trig.OnWheelStopped += Trig_OnWheelStopped;

		mallQuests= new List<Quest> (Resources.LoadAll<Quest>("MallQuests"));

		WheelScriptToAccess = WheelObject.GetComponent<WheelController> ();
		//WheelScriptToAccess.InitWheelColor = 4;


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

		questText_eventPanel.text = mallQuests [randomIndex].questText.ToString();
		leftButtonText.text = mallQuests [randomIndex].option1Text;
		rightButtonText.text = mallQuests [randomIndex].option2Text;

		if (mallQuests[randomIndex].StatTypeOne.ToString().Equals("ANGER")) {
			//left button image is anger
			leftButton.GetComponent<Image>().sprite = angerbanner;
		}

		if (mallQuests[randomIndex].StatTypeOne.ToString().Equals("HARMONY")) {
			leftButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (mallQuests[randomIndex].StatTypeOne.ToString().Equals("BEAUTY")) {
			leftButton.GetComponent<Image>().sprite = beautybanner;

		}
		if (mallQuests[randomIndex].StatTypeTwo.ToString().Equals("ANGER")) {
			rightButton.GetComponent<Image>().sprite = angerbanner;

		}
		if (mallQuests[randomIndex].StatTypeTwo.ToString().Equals("HARMONY")) {
			rightButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (mallQuests [randomIndex].StatTypeTwo.ToString().Equals("BEAUTY")) {
			rightButton.GetComponent<Image> ().sprite = beautybanner;
		}
	}

	public void GetMallEventClicked(){

		searchNetPanel.SetActive (false);
		randomIndex = Random.Range (0, mallQuests.Count);
		//EventPanelController ();

		if (guiMall.soul_num > 0 && guiMall.fame_num > 0 && guiMall.money_num > 0 && guiMall.vitality_num > 0) {
			ScriptableQuestPanelController ();

			mallEventPanel.SetActive (true);

		}
		else if(guiMall.vitality_num <= 0){
			
			guiMall.feedback_panel.SetActive (true);
			//guiMall.feedback_text.text = "Your vitality is too low to continue!";
		} 
		else if(guiMall.money_num <= 0){

			guiMall.feedback_text.text = "Your money is too low to continue!";
			guiMall.feedback_panel.SetActive (true);

		} 
		else if (guiMall.soul_num <=0 || guiMall.fame_num <= 0){

			//guiMall.feedback_text.text = "Your stats are too low! \nPull yourself together";
			guiMall.feedback_panel.SetActive (true);
			PlayerPrefs.SetString ("isFailed", "yes");

		}
			
	}

	public void AHBLeftButtonClicked(){

		leftbuttonclicked = true;
		rightbuttonclicked = false;
		Debug.Log ( mallQuests[randomIndex].StatTypeOne.ToString());

		if (mallQuests[randomIndex].StatTypeOne.ToString().Equals("ANGER"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
			//boostForWheel = guiMall.anger_num;
			WheelController.ItemNumber = guiMall.anger_num;

		}
		else if (mallQuests[randomIndex].StatTypeOne.ToString().Equals("HARMONY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
			//boostForWheel = guiMall.harmony_num;
			WheelController.ItemNumber = guiMall.harmony_num;

		}
		else if (mallQuests[randomIndex].StatTypeOne.ToString().Equals("BEAUTY"))
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
			//boostForWheel = guiMall.beauty_num;
			WheelController.ItemNumber = guiMall.beauty_num;


		}

		wheelPanel.SetActive (true);
		wheelResultPanel.SetActive (false);
		mallEventPanel.SetActive (false);

	}
	public void AHBRightButtonClicked(){

		rightbuttonclicked = true;
		leftbuttonclicked = false;

		if (mallQuests[randomIndex].StatTypeTwo.ToString().Equals("ANGER"))
		{

			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
			//boostForWheel = guiMall.anger_num;
			WheelController.ItemNumber = guiMall.anger_num;


		}
		else if ( mallQuests[randomIndex].StatTypeTwo.ToString().Equals("HARMONY"))
		{

			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
			//boostForWheel = guiMall.harmony_num;
			WheelController.ItemNumber = guiMall.harmony_num;

		}
		else if ( mallQuests[randomIndex].StatTypeTwo.ToString().Equals("BEAUTY"))
		{

			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
			//boostForWheel = guiMall.beauty_num;
			WheelController.ItemNumber = guiMall.beauty_num;

		}


		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (true);
		wheelResultPanel.SetActive (false);
		mallEventPanel.SetActive (false);
	}

	public void WheelResultDoneExit(){

		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);
		guiMall.vitality_num--;
		PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
		guiMall.time_num++;
		PlayerPrefs.SetInt ("time_global", guiMall.time_num);

		guiMall.StatController ();

		if(guiMall.canDoAction==false  || guiMall.clubUnlocked){
			guiMall.feedback_panel.SetActive (true);
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
				wheelResultInfo.text = " SUCCESS \n "+mallQuests[randomIndex].option1positiveResult;

				if (mallQuests [randomIndex].Option1StatSucces.ToString ().Equals ("FAME")) {
					guiMall.fame_num += mallQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
					StartCoroutine (StatChangedMall(fame_text));

				}
				else if (mallQuests [randomIndex].Option1StatSucces.ToString ().Equals ("SOUL")) {
					guiMall.soul_num += mallQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
					StartCoroutine (StatChangedMall(soul_text));

				}
				else if (mallQuests [randomIndex].Option1StatSucces.ToString ().Equals ("VITALITY")) {
					guiMall.vitality_num += mallQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
					StartCoroutine (StatChangedMall(vitality_text));

				}
				else if (mallQuests [randomIndex].Option1StatSucces.ToString ().Equals ("MONEY")) {
					guiMall.money_num += mallQuests[randomIndex].option1SuccesValue;
					PlayerPrefs.SetInt ("money_global", guiMall.money_num);
					StartCoroutine (StatChangedMall(money_text));

				}


			}

			if (!trig.GetQuest) { //leftbutton clicked and fail
				wheelResultInfo.text = "FAIL \n"+mallQuests[randomIndex].option1negativeResult;

				if (mallQuests [randomIndex].Option1StatFail.ToString ().Equals ("FAME")) {
					guiMall.fame_num += mallQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
					StartCoroutine (StatChangedMall(fame_text));

				}
				else if (mallQuests [randomIndex].Option1StatFail.ToString ().Equals ("SOUL")) {
					guiMall.soul_num += mallQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
					StartCoroutine (StatChangedMall(soul_text));

				}
				else if (mallQuests [randomIndex].Option1StatFail.ToString ().Equals ("VITALITY")) {
					guiMall.vitality_num += mallQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
					StartCoroutine (StatChangedMall(vitality_text));

				}
				else if (mallQuests [randomIndex].Option1StatFail.ToString ().Equals ("MONEY")) {
					guiMall.money_num += mallQuests[randomIndex].option1FailValue;
					PlayerPrefs.SetInt ("money_global", guiMall.money_num);
					StartCoroutine (StatChangedMall(money_text));

				}


			}

		} 

		else if (rightbuttonclicked) {
			Debug.Log ("Right button "+wheelResult);
			if (trig.GetQuest) { // Success
				wheelResultInfo.text = "SUCCESS \n"+mallQuests[randomIndex].option2positiveResult;
				if (mallQuests [randomIndex].Option2StatSucces.ToString ().Equals ("FAME")) {
					guiMall.fame_num += mallQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
					StartCoroutine (StatChangedMall(fame_text));

				}
				else if (mallQuests [randomIndex].Option2StatSucces.ToString ().Equals ("SOUL")) {
					guiMall.soul_num += mallQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
					StartCoroutine (StatChangedMall(soul_text));

				}
				else if (mallQuests [randomIndex].Option2StatSucces.ToString ().Equals ("VITALITY")) {
					guiMall.vitality_num += mallQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
					StartCoroutine (StatChangedMall(vitality_text));

				}
				else if (mallQuests [randomIndex].Option2StatSucces.ToString ().Equals ("MONEY")) {
					guiMall.money_num += mallQuests[randomIndex].option2SuccesValue;
					PlayerPrefs.SetInt ("money_global", guiMall.money_num);
					StartCoroutine (StatChangedMall(money_text));

				}
			}
			if (!trig.GetQuest) {//Fail
				wheelResultInfo.text = "FAIL \n" +mallQuests[randomIndex].option2negativeResult;
				if (mallQuests [randomIndex].Option2StatFail.ToString ().Equals ("FAME")) {
					guiMall.fame_num += mallQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
					StartCoroutine (StatChangedMall(fame_text));

				}
				else if (mallQuests [randomIndex].Option2StatFail.ToString ().Equals ("SOUL")) {
					guiMall.soul_num += mallQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
					StartCoroutine (StatChangedMall(soul_text));

				}
				else if (mallQuests [randomIndex].Option2StatFail.ToString ().Equals ("VITALITY")) {
					guiMall.vitality_num += mallQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
					StartCoroutine (StatChangedMall(vitality_text));

				}
				else if (mallQuests [randomIndex].Option2StatFail.ToString ().Equals ("MONEY")) {
					guiMall.money_num += mallQuests[randomIndex].option2FailValue;
					PlayerPrefs.SetInt ("money_global", guiMall.money_num);
					StartCoroutine (StatChangedMall(money_text));

				}

			}

		}

	}

	public void QuestClicked(){
		searchNetPanel.SetActive (true);
		headLine_searchpanel.text = "ROAM MALL";
		infoText_searchpanel.text = "Roam the mall for opportunities. This is a perfect place to gain attention, and to create SoMe content.\nSpend 1 hour and 1 vitality to search for something useful.";
		buttonText_searchpanel.text = "ROAM";
	}

	public void ExitSearchNetPanelClicked(){
		searchNetPanel.SetActive (false);
	}

	IEnumerator StatChangedMall(Text myText){

		for(int i = 0; i<5 ; i++){
			yield return new WaitForSecondsRealtime (0.5f);

			if (i % 2 == 1) {
				Debug.Log ("works");
				myText.color = new Color (0, 0, 0);
				//myText.color = new Color (5f,5f,5f);
			}
			else 
				myText.color = new Color (255f,255f,255f);

		}

	}
}



