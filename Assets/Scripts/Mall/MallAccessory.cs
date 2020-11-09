using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallAccessory : MonoBehaviour {

	public class Accessory {

		public string Title;
		public Sprite Picture;
		public int Boost;
		public int Price;
		public bool SellingStatus;

		public Accessory (string title, Sprite pic, int boost, int price, bool sold){

			title = Title;
			pic = Picture;
			boost = Boost;
			price = Price;
			sold = SellingStatus;

		}

	}

	public GameObject itemPanel1;
	public GameObject itemPanel2;
	public GameObject itemPanel3;


	public List<Accessory> accessoryList;


	void Start(){
	
			//TODO add accesories
	
	}



}
