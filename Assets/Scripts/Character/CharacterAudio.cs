using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterAudio : MonoBehaviour
{
	[HideInInspector] public AudioSource audioGrunt;
	[HideInInspector] public AudioSource audioWeapon;
	[HideInInspector] public AudioSource audioMovement;
	[HideInInspector] public AudioSource audioOther;
	
	AudioClip clipWeapon;
	AudioClip clipGrunt;
	Transform audioContainer;
	
	void Awake(){
		audioContainer = transform.Find("Audio");
		AudioSource[] allSources = audioContainer.GetComponents<AudioSource>();
		audioGrunt = allSources[0];
		audioWeapon = allSources[1];
		audioMovement = allSources[2];
		audioOther = allSources[3];
	}
	
	public void SetAudio(AudioSource source, AudioClip clip){
		source.clip = clip;
	}
	
	public void Play(AudioSource source){
		source.PlayOneShot(source.clip);
	}
}
