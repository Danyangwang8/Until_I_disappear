using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStartGame : MonoBehaviour {

	private int fame_num, soul_num, vitality_num, money_num, time_num, day_num;
	private int anger_num, harmony_num, beauty_num;

	public static bool gameStarted;

	public GameObject panel1;
	public GameObject panel2;

	void Start () {

		StatInit ();
		panel1.SetActive (false);
		panel2.SetActive (false);

		CutSceneController.sceneToLoad = "Bedroom Final"; 
	}
	
	void Update () {
		
	}

	public void StatInit(){
		time_num= 8;
		PlayerPrefs.SetInt ("time_global", time_num);

		fame_num = 4;
		PlayerPrefs.SetInt ("fame_global", fame_num);

		soul_num = 8;
		PlayerPrefs.SetInt ("soul_global", soul_num);

		vitality_num = 10;
		PlayerPrefs.SetInt ("vitality_global", vitality_num);

		money_num=8;
		PlayerPrefs.SetInt ("money_global", money_num);

		day_num = 1;
		PlayerPrefs.SetInt ("day_global", day_num);

		beauty_num = 3;
		PlayerPrefs.SetInt ("beauty_global", beauty_num);

		anger_num = 3;
		PlayerPrefs.SetInt ("anger_global", anger_num);

		harmony_num = 3;
		PlayerPrefs.SetInt ("harmony_global", harmony_num);


	}

	public void StartGame(){
		panel1.SetActive (true);
		panel2.SetActive (false);
	}

	public void InfoPanel1OnClick(){
		
		panel1.SetActive (false);
		panel2.SetActive (true);
	}

	public void InfoPanel2OnClick(){

		panel1.SetActive (false);
		panel2.SetActive (false);
		gameStarted = true;
		CutSceneTextController.comingSceneNo = 0;
		SceneManager.LoadScene ("Cutscene");
	}


}
