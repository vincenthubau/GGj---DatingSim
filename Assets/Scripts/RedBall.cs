using UnityEngine;
using System.Collections;

public class RedBall : MonoBehaviour {
	public string RedBallKickEvent;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnCollisionEnter(Collision hit) {
		Invoke("PlayRedBallKick", 0);
	}
}
