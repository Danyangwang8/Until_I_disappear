using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour {
    
    public float rotSpeed;
    public float DragSpeed;
    private float mDelta = 2.5f;
    public float MaxSpeed;
    public float MinSpeed;

    public bool IsDrag = false;
    public bool IsPause = true;
    //tick sound

    public GameObject WheelTitles;
    public GameObject Arrow;
    private Trigger ArrowScriptAccess;


    private float color = 0;
    public int InitWheelColor ;
    private int InitWheelColorN;
    public static int ItemNumber ;
    private GameObject [] WheelPieces;
	public int BlackColorN;

    public GameObject WheelPart0;
    public GameObject WheelPart1;
    public GameObject WheelPart2;
    public GameObject WheelPart3;
    public GameObject WheelPart4;
    public GameObject WheelPart5;
    public GameObject WheelPart6;
    public GameObject WheelPart7;
    public GameObject WheelPart8;
    public GameObject WheelPart9;
    public GameObject WheelPart10;
    public GameObject WheelPart11;
    public GameObject WheelPart12;
    public GameObject WheelPart13;
    public GameObject WheelPart14;
    public GameObject WheelPart15;
    public GameObject WheelPart16;
    public GameObject WheelPart17;
    public GameObject WheelPart18;
    public GameObject WheelPart19;


    // Use this for initialization
    void Start () {
        //tick Sound

        ArrowScriptAccess = Arrow.GetComponent<Trigger>();

		//InitWheelColorN = 7;
		InitWheelColor = BlackColorN;
    
    }

    void Update()
    {
         Dragging();
        ChangeColor();
       // WheelSoundController();
    }

    //Drag the wheel
    public void StartDrag()
    {
        IsDrag = true;
        IsPause = false;
    }
    void Dragging()
    {

        if (Input.GetMouseButtonDown(0) && !IsDrag)
        {
            //140f almost 1 round.
            DragSpeed = Mathf.Abs(Input.GetAxis("Mouse Y"))+Random.Range(130f,150f)+ Mathf.Abs(Input.GetAxis("Mouse X"));
           // Debug.Log("MOUSE!");
            rotSpeed = DragSpeed *1.35f;
            if(rotSpeed > MaxSpeed){
                rotSpeed = MaxSpeed+Random.Range(20f, 70f);
            }
            if(DragSpeed < MinSpeed)
            {
                rotSpeed = MinSpeed + Random.Range(50f, 100f);
            }
            transform.Rotate(0, 0, -1 * rotSpeed * Time.deltaTime );
            if(rotSpeed<=DragSpeed*1.35f)
            {
                rotSpeed += mDelta*1.35f;
            }
            IsDrag = true;
            IsPause = false;
        }
        else if (IsDrag && !IsPause)
        {
            //set max rotspeed
            if (rotSpeed > MaxSpeed)
            {
                rotSpeed = MaxSpeed+ Random.Range(20f, 70f);
            }

            transform.Rotate(0, 0, -1 * rotSpeed * Time.deltaTime);
            rotSpeed -= mDelta;
            if (rotSpeed <= 0)
            {
                IsPause = true;
                IsDrag = false;
            }
          
           
        }
        if (Input.GetMouseButtonDown(0) && !IsPause)
        {
           // Debug.Log("Cheat");
        }
        if(rotSpeed<=0)
        {
            rotSpeed = 0;
        }
        

    }



    public void StopDrag()
    {
        IsDrag = false;
        IsPause = true;
    }

    void ChangeColor() {
        //if player get items.
        GameObject [] WheelPieces = { WheelPart0, WheelPart1, WheelPart2, WheelPart3, WheelPart4, WheelPart5, WheelPart6, WheelPart7, WheelPart8, WheelPart9, WheelPart10, WheelPart11, WheelPart12, WheelPart13, WheelPart14, WheelPart15, WheelPart16, WheelPart17, WheelPart18, WheelPart19 };
        //int[] ItN = new int[16];
        //int[] InitCN = new int[5];

        if (GameObject.FindGameObjectWithTag("HARMONYWHEEL"))
        {
            for(int i =0; i<20; i++) {
                WheelPieces[i].gameObject.tag = "WheelTriggerFalse";
                WheelPieces[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("white");
            }
            WheelTitles.GetComponent<Image>().sprite = Resources.Load<Sprite>("wheel_of_harmony");

            switch (InitWheelColorN)
            {
                case 0 :
				for (int i = 0; i < InitWheelColor; i++)
                    {
                        WheelPieces[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("black");
                        WheelPieces[i].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
            }
            switch (ItemNumber)
            {


                case 1:
                    for (int i = 0; i < 1; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 5:
                    for (int i = 0; i < 5; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 6:
                    for (int i = 0; i < 6; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 7:
                    for (int i = 0; i < 7; i++)
                    {
                        WheelPieces[i + 3].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 8:
                    for (int i = 0; i < 8; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 9:
                    for (int i = 0; i < 9; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 10:
                    for (int i = 0; i < 10; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 11:
                    for (int i = 0; i < 11; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 12:
                    for (int i = 0; i < 12; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 13:
                    for (int i = 0; i < 13; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 14:
                    for (int i = 0; i < 14; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 15:
                    for (int i = 0; i < 15; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 16:
                    for (int i = 0; i < 16; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 17:
                    for (int i = 0; i < 17; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("blue");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
            }
        }
        else if(GameObject.FindGameObjectWithTag("BEAUTYWHEEL"))
        {
            for (int i = 0; i < 20; i++)
            {
                WheelPieces[i].gameObject.tag = "WheelTriggerFalse";
                WheelPieces[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("white");
            }
            WheelTitles.GetComponent<Image>().sprite = Resources.Load<Sprite>("wheel_of_beauty");
            switch (InitWheelColorN)
            {
                case 0:
				for (int i = 0; i < InitWheelColor; i++)
                    {
                        WheelPieces[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("black");
                        WheelPieces[i].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
            }
            switch (ItemNumber)
            {


                case 1:
                    for (int i = 0; i < 1; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 5:
                    for (int i = 0; i < 5; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 6:
                    for (int i = 0; i < 6; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 7:
                    for (int i = 0; i < 7; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 8:
                    for (int i = 0; i < 8; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 9:
                    for (int i = 0; i < 9; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 10:
                    for (int i = 0; i < 10; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 11:
                    for (int i = 0; i < 11; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 12:
                    for (int i = 0; i < 12; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 13:
                    for (int i = 0; i < 13; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 14:
                    for (int i = 0; i < 14; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 15:
                    for (int i = 0; i < 15; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 16:
                    for (int i = 0; i < 16; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 17:
                    for (int i = 0; i < 17; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("yellow");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
            }
        }
        else if(GameObject.FindGameObjectWithTag("ANGERWHEEL"))
        {
            for (int i = 0; i < 20; i++)
            {
                WheelPieces[i].gameObject.tag = "WheelTriggerFalse";
                WheelPieces[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("white");
            }
            WheelTitles.GetComponent<Image>().sprite = Resources.Load<Sprite>("wheel_of_anger");
            switch (InitWheelColorN)
            {
                case 0:
				for(int i=0; i<InitWheelColor; i++)
                    {
                        WheelPieces[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("black");
                        WheelPieces[i].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
            }
            switch (ItemNumber)
            {
                
            
                case 1:
                    for (int i = 0; i < 1; i++)
                    {
                        WheelPieces[i+InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i+InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 4:
                    for (int i = 0; i < 4; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 5:
                    for (int i = 0; i < 5; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 6:
                    for (int i = 0; i < 6; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 7:
                    for (int i = 0; i < 7; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 8:
                    for (int i = 0; i < 8; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 9:
                    for (int i = 0; i < 9; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 10:
                    for (int i = 0; i < 10; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 11:
                    for (int i = 0; i < 11; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 12:
                    for (int i = 0; i < 12; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 13:
                    for (int i = 0; i < 13; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 14:
                    for (int i = 0; i < 14; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 15:
                    for (int i = 0; i < 15; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 16:
                    for (int i = 0; i < 16; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
                case 17:
                    for (int i = 0; i < 17; i++)
                    {
                        WheelPieces[i + InitWheelColor].GetComponent<Image>().sprite = Resources.Load<Sprite>("red");
                        WheelPieces[i + InitWheelColor].gameObject.tag = "WheelTriggerTrue";
                    }
                    break;
            }
        }
    }
    private void Awake()
    {

    }
  
}
