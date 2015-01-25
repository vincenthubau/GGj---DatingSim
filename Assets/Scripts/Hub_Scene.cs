using UnityEngine;
using System.Collections;

public class Hub_Scene : MonoBehaviour {

	public string AmbiantMusicEvent;
	public float AmbiantMusicFrequency = 0F;
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("PlayAmbiantMusic", 0, AmbiantMusicFrequency);
	}
	
	void PlayAmbiantMusic ()
	{
		AkSoundEngine.PostEvent(AmbiantMusicEvent, gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
