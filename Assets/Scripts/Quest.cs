using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Quest : ScriptableObject 
{
    public string questHeadline;
    public int questDifficulty;
    [Header("Write quest text here")]
    [TextArea]
    public string questText;
 
    [Header("OPTION 1")]
    public EStatTypes StatTypeOne;
    [TextArea]
    public string option1Text;

    [TextArea]
    public string option1positiveResult;
    public EStatStats Option1StatSucces;
    public int option1SuccesValue;

    [TextArea]
    public string option1negativeResult;
	 
    public EStatStats Option1StatFail;
    public int option1FailValue;


    [Header("OPTION 2")]
    public EStatTypes StatTypeTwo;
    [TextArea]
    public string option2Text;

    [TextArea]
    public string option2positiveResult;
    public EStatStats Option2StatSucces;
    public int option2SuccesValue;

    [TextArea]
    public string option2negativeResult;

    public EStatStats Option2StatFail;
    public int option2FailValue;
}