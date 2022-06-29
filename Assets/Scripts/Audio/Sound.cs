using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
	string name{get; set;}
	
	[SerializeField] AudioClip _clip;
	
	private int volume = 50;
	
	private int pitch = 0;
}
