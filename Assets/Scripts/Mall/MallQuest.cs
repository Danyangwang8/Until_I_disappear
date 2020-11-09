using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MallQuest : MonoBehaviour {

	public class Quest {

		public int quest_no;
		public string quest_text;
		public double success_rate;
		public Banner wheel1;
		public Banner wheel2;



		public Quest(int q_no, string q_text, double succ_r, Banner whl1, Banner whl2 ){

			quest_no=q_no;
			quest_text=q_text;
			success_rate=succ_r;
			wheel1=whl1;
			wheel2=whl2;

		}

	}

	public class Banner {

		public int banner_type;
		public string banner_text;
		public string success_text;
		public string fail_text;
		public int result_fame_s;
		public int result_soul_s;
		public int result_vitality_s;
		public int result_money_s;
		public int result_fame_f;
		public int result_soul_f;
		public int result_vitality_f;
		public int result_money_f;


		public Banner (int b_type, string ban_text, string succ_text, string f_text, int res_fameS, int res_soulS, int res_vitS, int res_monS, int res_fameF, int res_soulF, int res_vitF, int res_monF){

			banner_type=b_type; // banner type refers to Anger = 0, Harmony =1, Beauty =2
			banner_text=ban_text;
			success_text=succ_text;
			fail_text=f_text;
			result_fame_s=res_fameS;
			result_soul_s=res_soulS;
			result_vitality_s=res_vitS;
			result_money_f=res_monS;
			result_fame_f=res_fameF;
			result_soul_f=res_soulF;
			result_vitality_f=res_vitF;
			result_money_f=res_monF;

		}

	}

	public List<Quest> questList;

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

	//public GameObject wheelPrefab;
	public bool leftbuttonclicked;
	public bool rightbuttonclicked;
	public GameObject wheelPanel;

	public int wheelResult;

	public Text fame_text, soul_text, vitality_text, money_text, luck_text;
	public Text anger_num, beauty_num, harmony_num;

	private GameObject guiMallGameObject;
	public GUIMall guiMall;

	private Trigger TriggerScriptToAccess;
	private bool booleanScriptGetQuest=false;
	public GameObject WheelObject;
	private WheelController WheelScriptToAccess;

	public List<Quest> mallQuests;


	void Start () {

		mallEventPanel.SetActive (false);
		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);

		questList = new List<Quest> ();

		questList.Add (new Quest(1, " After walking the corridors for some time, you see some teenagers laughing while pulling down the pants of a nerdy boy.\n", 0.5, 
			new Banner(0, "Picture opportunity!\nTry to snap a picture for your blog.\n","You quickly snap a picture of the hillarys naked boy and post it online. \n","You drop your phone while taking it out of your pocket and the screen cracks. Everybody laughs at you.\n ", 4, 0,0,0,0,0,0,-2), 
			new Banner(2,"Charm the teenagers so the nerd can escape\n ", "You catwalk in a circle around the teenagers. They are hypnotized by your beauty. They all grab their phones and take pictures of you.", "You try to catwalk in front of the teenagers, but somehow you stumble and fall to the ground. The teenagers forget the nerd and start to laugh at you instead.\n", 3,0,0,0,-2,0,0,0)));

		questList.Add (new Quest(2, "Just outside the pet shop you see a small, frightened rabbit that has escaped its cage.\n", 0.5, 
			new Banner(1, "“Pick up the rabbit and deliver it back to the store”\n", "You pick up the rabbit and bring it back. The store owner is so happy he gives you a reward!\n","You pick up the rabbit with all the best intentions of returning it the pet store, but suddenly you are on your way to the toilets.\nAt the toilets, you poke a hole in the rabbit with the sharpened pencil you used for your math exam. You sit on the toilet and watch it slowly bleed to death.\n", 0, 1,0,2,0,-5,0,0), 
			new Banner(2,"Pick up the rabbit and take some super cute selfies.\n", " You and a rabbit, no one on SoMe can resist all that cuteness.\n", "After you post the picture on SoMe, you realized that the rabbit has shit on your t-shirt.\nYou are the laughing stock of the internet town.\n", 3,0,0,0,-1,0,0,0)));


		questText_eventPanel.text = " ";
		leftButtonText.text = " ";
		rightButtonText.text = " ";
		wheelResultInfo.text = " ";

		//guiBedroomGameObject = GameObject.Find ("GUIController");
		//guiBedroom = guiBedroomGameObject.GetComponent<GUIMall> ();

		guiMallGameObject = GameObject.Find ("GUIController");
		guiMall = guiMallGameObject.GetComponent<GUIMall> ();


		EventPanelController ();
		SetUpResultPanel ();
	}


	public void EventPanelController(){

		//randomIndex = Random.Range (0, questList.Count);

		questText_eventPanel.text = questList [randomIndex].quest_text;
		leftButtonText.text = questList [randomIndex].wheel1.banner_text;
		rightButtonText.text = questList [randomIndex].wheel2.banner_text;

		if (questList [randomIndex].wheel1.banner_type == 0) {
			//banner1=(GameObject)Instantiate (angerButton, new Vector2 (-3, -3), Quaternion.identity);
			//left button image is anger
			leftButton.GetComponent<Image>().sprite = angerbanner;
		}

		if (questList [randomIndex].wheel1.banner_type == 1) {
			//banner1= (GameObject)Instantiate (harmonyButton, new Vector2 (-3, -3), Quaternion.identity);
			leftButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (questList [randomIndex].wheel1.banner_type == 2) {
			//banner1= (GameObject)Instantiate (beautyButton, new Vector2 (-3, -3), Quaternion.identity);
			leftButton.GetComponent<Image>().sprite = beautybanner;

		}
		if (questList [randomIndex].wheel2.banner_type == 0) {
			//banner2= (GameObject)Instantiate (angerButton, new Vector2 (3, -3), Quaternion.identity);
			rightButton.GetComponent<Image>().sprite = angerbanner;

		}
		if (questList [randomIndex].wheel2.banner_type == 1) {
			//banner2=(GameObject)Instantiate (harmonyButton, new Vector2 (3, -3), Quaternion.identity);
			rightButton.GetComponent<Image>().sprite = harmonybanner;

		}
		if (questList [randomIndex].wheel2.banner_type == 2) {
			//banner2=(GameObject)Instantiate (beautyButton, new Vector2 (3, -3), Quaternion.identity);
			rightButton.GetComponent<Image>().sprite = beautybanner;

		}

	}

	public void GetMallEventClicked(){
		randomIndex = Random.Range (0, questList.Count);
		EventPanelController ();
		mallEventPanel.SetActive (true);

	}

	public void AHBLeftButtonClicked(){

		//TODO instantiate wheel
		//Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);
		leftbuttonclicked = true;
		wheelResult = Random.Range (0, 100);
		//SetUpResultPanel ();
		//wheelResultPanel.SetActive (true);
		wheelPanel.SetActive(true);
		if (Trigger.playTime >= 2) {
			SetUpResultPanel ();
			wheelResultPanel.SetActive (true);
			Debug.Log ("Trigger works");
		}
		//SetUpResultPanel ();
		wheelResultPanel.SetActive (false);
		mallEventPanel.SetActive (false);

		if (leftbuttonclicked = true && questList[randomIndex].wheel1.banner_type == 0)
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";

		}
		else if (leftbuttonclicked = true && questList[randomIndex].wheel1.banner_type == 1)
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
		}
		else if (leftbuttonclicked = true && questList[randomIndex].wheel1.banner_type == 2)
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
		}

	}
	public void AHBRightButtonClicked(){

		//TODO instantiate wheel
		//Instantiate(wheelPrefab, new Vector2(0,0), Quaternion.identity);
		rightbuttonclicked = true;
		wheelResult = Random.Range (0, 100);
		Debug.Log (wheelResult);
		//SetUpResultPanel ();
		//wheelResultPanel.SetActive (true);
		wheelPanel.SetActive(true);
		if (Trigger.playTime >= 2) {
			SetUpResultPanel ();
			wheelResultPanel.SetActive (true);
			Debug.Log ("Trigger works");
		}
		//SetUpResultPanel ();
		wheelResultPanel.SetActive (false);
		mallEventPanel.SetActive (false);

		if (rightbuttonclicked = true && questList[randomIndex].wheel2.banner_type == 0)
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "ANGERWHEEL";
		}
		else if (rightbuttonclicked = true && questList[randomIndex].wheel2.banner_type == 1)
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "HARMONYWHEEL";
		}
		else if (rightbuttonclicked = true && questList[randomIndex].wheel2.banner_type == 2)
		{
			//Change the wheel's tag;
			WheelObject.gameObject.tag = "BEAUTYWHEEL";
		}
	}

	public void WheelResultDoneExit(){

		wheelResultPanel.SetActive (false);
		wheelPanel.SetActive (false);
		//bedroomEventPanel.SetActive (false);
	}
	public void WheelDone(){

		SetUpResultPanel ();
        wheelPanel.SetActive(false);
		wheelResultPanel.SetActive (true);

	}


	public void SetUpResultPanel(){

		//wheelResultInfo.text = questList [randomIndex].wheel1.success_text;
		//Debug.Log (guiBedroom.leftbuttonclicked);

		if (leftbuttonclicked) {
			Debug.Log (wheelResult);
			if (TriggerScriptToAccess.GetQuest) { //leftbutton clicked and success
				wheelResultInfo.text = " SUCCESS \n "+questList [randomIndex].wheel1.success_text;
				guiMall.fame_num += questList [randomIndex].wheel1.result_fame_s;
				PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
				guiMall.soul_num += questList [randomIndex].wheel1.result_soul_s;
				PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
				guiMall.vitality_num += questList [randomIndex].wheel1.result_vitality_s;
				PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
				guiMall.money_num += questList [randomIndex].wheel1.result_money_s;
				PlayerPrefs.SetInt ("money_global", guiMall.money_num);
			}

			if (!TriggerScriptToAccess.GetQuest) { //leftbutton clicked and fail
				wheelResultInfo.text = "FAIL \n"+questList [randomIndex].wheel1.fail_text;
				guiMall.fame_num += questList [randomIndex].wheel1.result_fame_f;
				PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
				guiMall.soul_num += questList [randomIndex].wheel1.result_soul_f;
				PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
				guiMall.vitality_num += questList [randomIndex].wheel1.result_vitality_f;
				PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
				guiMall.money_num += questList [randomIndex].wheel1.result_money_f;
				PlayerPrefs.SetInt ("money_global", guiMall.money_num);

			}

		} 

		else if (rightbuttonclicked) {
			Debug.Log ("Right button "+wheelResult);
			if (TriggerScriptToAccess.GetQuest) { // Success
				wheelResultInfo.text = "SUCCESS \n"+questList [randomIndex].wheel2.success_text;
				guiMall.fame_num += questList [randomIndex].wheel2.result_fame_s;
				PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
				guiMall.soul_num += questList [randomIndex].wheel2.result_soul_s;
				PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
				guiMall.vitality_num += questList [randomIndex].wheel2.result_vitality_s;
				PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
				guiMall.money_num += questList [randomIndex].wheel2.result_money_s;
				PlayerPrefs.SetInt ("money_global", guiMall.money_num);
			}
			if (!TriggerScriptToAccess.GetQuest) {//Fail
				wheelResultInfo.text = "FAIL \n" +questList [randomIndex].wheel2.fail_text;
				guiMall.fame_num += questList [randomIndex].wheel2.result_fame_f;
				PlayerPrefs.SetInt ("fame_global", guiMall.fame_num);
				guiMall.soul_num += questList [randomIndex].wheel2.result_soul_f;
				PlayerPrefs.SetInt ("soul_global", guiMall.soul_num);
				guiMall.vitality_num += questList [randomIndex].wheel2.result_vitality_f;
				PlayerPrefs.SetInt ("vitality_global", guiMall.vitality_num);
				guiMall.money_num += questList [randomIndex].wheel2.result_money_f;
				PlayerPrefs.SetInt ("money_global", guiMall.money_num);

			}

		}

	}

}




