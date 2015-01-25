using UnityEngine;
using System.Collections;

public class HubSoundStarter : MonoBehaviour {
	public AudioClip hubSound;
	// Use this for initialization
	void Start () {
		audio.clip = hubSound;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartSound(){
		audio.clip = hubSound;
		audio.Play();
	}
	public void StopSound(){
		audio.Stop();
	}
}
