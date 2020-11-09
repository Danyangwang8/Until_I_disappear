using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedroomQuest : MonoBehaviour {

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


	public static List<Quest> questList= new List<Quest>();



	public Text quest;
	public Text leftText;
	public Text rightText;
	public GameObject angerButton;
	public GameObject harmonyButton;
	public GameObject beautyButton;

	public static GameObject banner1;
	public static GameObject banner2;
	private int randomIndex;

	


	void Start () {

		questList.Add (new Quest(1, "Quest1 Alalaksndnfj", 0.5, new Banner(0, "Write something hurtful back at him", "Like a true trollslayer you write “funny you should write that. IT IS ACTUALLY A PICTURE OF YOUR FACE!!","You try to come up with a clever response, but nothing comes up. In the end you decide to write “What about yourself.” Deep in your heart you know that you have failed.", 2, 0,0,0,-2,0,0,0), 
			new Banner(1,"Write something nice to him", "You write “thanks, for your input. I actually do not own a dog.", "You take a deep breath and try to be calm, but it is impossible. \nYou write: dogfucker, I do not own a dog!!!##!!! I hope you choke in dog poo!!!", 0,2,0,0,0,-2,0,0)));



		SetUpEventPanel ();
		randomIndex = 0;//Random.Range (0, questList.Count);
	}


	void SetUpEventPanel () {

		//TODO create random index

		quest.text = questList [randomIndex].quest_text;
		leftText.text = questList [randomIndex].wheel1.banner_text;
		rightText.text = questList [randomIndex].wheel2.banner_text;

		if (questList [randomIndex].wheel1.banner_type == 0) {
			banner1=(GameObject)Instantiate (angerButton, new Vector2 (-3, -3), Quaternion.identity);
					
		}
		if (questList [randomIndex].wheel1.banner_type == 1) {
			banner1= (GameObject)Instantiate (harmonyButton, new Vector2 (-3, -3), Quaternion.identity);

		}
		if (questList [randomIndex].wheel1.banner_type == 2) {
			banner1= (GameObject)Instantiate (beautyButton, new Vector2 (-3, -3), Quaternion.identity);

		}
		if (questList [randomIndex].wheel2.banner_type == 0) {
			banner2= (GameObject)Instantiate (angerButton, new Vector2 (3, -3), Quaternion.identity);

		}
		if (questList [randomIndex].wheel2.banner_type == 1) {
			banner2=(GameObject)Instantiate (harmonyButton, new Vector2 (3, -3), Quaternion.identity);

		}
		if (questList [randomIndex].wheel2.banner_type == 2) {
			banner2=(GameObject)Instantiate (beautyButton, new Vector2 (3, -3), Quaternion.identity);

		}

	}

	public Text resultText;

	void SetUpWheelResultPanel(){
	
		/*
		if (Trigger.GetQuest == true) { // win condition
			if (QuestController.wheelSelection == 0) { // Banner 1 (left wheel)
				resultText.text = questList[randomIndex].wheel1.success_text;
				Debug.Log (questList [randomIndex].wheel1.success_text);
			}
		}
		if (Trigger.GetQuest == false) { // win condition
			if (QuestController.wheelSelection == 0) { // Banner 1 (left wheel)
				resultText.text = questList[randomIndex].wheel1.fail_text;
				Debug.Log (questList [randomIndex].wheel1.fail_text);

			}

		}
		*/
	
	}

}
