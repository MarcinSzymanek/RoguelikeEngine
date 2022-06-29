using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : GridEngine.Singleton<AudioManager>
{
	private string _basePath;
    // Start is called before the first frame update
    void Start()
    {
	    _basePath = "Prefabs/SFX/SoundObjects/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void AddAudio(GameObject obj, string clipName){
		string name = _basePath + clipName;
		var sound = Resources.Load(name) as GameObject;
		GameObject go = Instantiate(sound, obj.transform.position, Quaternion.identity);
		go.transform.SetParent(obj.transform);
		go.name = clipName;
	}
	
	public void RemoveAudio(GameObject obj, string clipName){
		GameObject audio = obj.transform.Find(clipName).gameObject;
		Destroy(audio);
	}
}
