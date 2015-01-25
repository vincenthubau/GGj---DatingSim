using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour 
{
	public string FootstepsEvent;
	public float FootstepsFrequency = 0.5f;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	void PlayFootsteps ()
	{
		AkSoundEngine.SetSwitch("Rayman_SW_Footsteps","Wood",gameObject);
		AkSoundEngine.PostEvent(FootstepsEvent, gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			InvokeRepeating("PlayFootsteps", 0, FootstepsFrequency);
		}
		
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow))
		{
			CancelInvoke("PlayFootsteps");
		}
		
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			InvokeRepeating("PlayFootsteps", 0, FootstepsFrequency);
		}
		
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			CancelInvoke("PlayFootsteps");
		}
	}
}
