using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script use for get quest.
public class Trigger : MonoBehaviour
{

    public bool GetQuest;
    public GameObject WheelObject;
    public GameObject Arrow;
    //play music
    public AudioClip Wheel_loose;
    public AudioClip Wheel_win;
    public AudioSource Wheel_win_loose_Music;
    public AudioSource WheelMusic;
    public AudioClip Wheel_tick_music;
    private bool musicPlayed = false;
    private float lengthOfSound;
    public float Wheel_Sound_Volume;

    public event EventHandler OnWheelStopped;
    Collider2D Arrow_Collider;
    private WheelController WheelScriptToAccess;
    private float FloatScriptrotSpeed;
    private bool spinning;

    public static int playTime;

    void Start()
    {
        WheelScriptToAccess = WheelObject.GetComponent<WheelController>();
        FloatScriptrotSpeed = WheelScriptToAccess.rotSpeed;
        spinning = false;
        Wheel_win_loose_Music = GetComponent<AudioSource>();
        WheelMusic = GetComponent<AudioSource>();
        WheelMusic.clip = Wheel_tick_music;
        Arrow_Collider = GetComponent<Collider2D>();
        Arrow_Collider.enabled = false;
        playTime = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playTime++;

            Arrow_Collider.enabled = true;
        }
        if (spinning == true)
        {
            if (WheelScriptToAccess.rotSpeed <= 0)
            {
                spinning = false;
                if (OnWheelStopped != null)
                {
                    OnWheelStopped(GetQuest, null);
                }
                //Debug.Log("wheel stopped spinning");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        // Debug.Log("Trigger");

        if (WheelScriptToAccess.rotSpeed <= 0)
        {
            playTime++;
            //Debug.Log (playTime);

            switch (other.gameObject.tag)
            {
                case "WheelTriggerTrue":
                    GetQuest = true;
                   // Debug.Log("Get Quest");
                    Wheel_win_loose_Music.PlayOneShot(Wheel_win, Wheel_Sound_Volume);
                    //Debug.Log("Get Win music");
                    spinning = true;
                    Arrow_Collider.enabled = false;

                    break;
                case "WheelTriggerFalse":
                    GetQuest = false;
                   // Debug.Log("Not get Quest");
                    Wheel_win_loose_Music.PlayOneShot(Wheel_loose, Wheel_Sound_Volume);
                    //Debug.Log("Get loose music");
                    spinning = true;
                    Arrow_Collider.enabled = false;

                    break;
            }
        }
        else
        {
            if (WheelMusic == true)
            {
                WheelMusic.volume = 0.3f;
                WheelMusic.Play();
                musicPlayed = false;
                //Debug.Log("Wheel_tick_music");
            }
            if (WheelMusic.isPlaying == true)
            {

                StartCoroutine(Wait());
                //Debug.Log("MUSIC wait");
            }
        }


    }

IEnumerator Wait()
{
    lengthOfSound = Wheel_tick_music.length;
        Debug.Log(Wheel_tick_music.length);
    yield return new WaitForSeconds(lengthOfSound);
    musicPlayed = true;

}


    private void Awake()
    {

    }
}

