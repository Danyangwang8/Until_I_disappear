using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
[CreateAssetMenu]
public class Accessory : ScriptableObject 
{
	[SerializeField]
    public string Title;
	[SerializeField]
    public Sprite Picture;
	[SerializeField]
    public int Boost;
	[SerializeField]
    public int Price;
	[SerializeField]
    public EStatTypes StatType;
}