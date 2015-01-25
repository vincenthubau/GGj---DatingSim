using UnityEngine;
using System.Collections;

public class RedBall : MonoBehaviour {
	public AudioClip[] ballAudio;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnCollisionEnter(Collision hit) {
		audio.clip = ballAudio[Random.Range(0,ballAudio.Length)];
		audio.Play();
	}
}
