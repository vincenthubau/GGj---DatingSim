using UnityEngine;
using System.Collections;

public class RedBall : MonoBehaviour {
	public string RedBallKickEvent;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	void PlayRedBallKick ()
	{
		AkSoundEngine.SetSwitch("Rayman_SW_Footsteps","Wood",gameObject);
		AkSoundEngine.PostEvent(RedBallKickEvent, gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnCollisionEnter(Collision hit) {
		Invoke("PlayRedBallKick", 0);
	}
}
