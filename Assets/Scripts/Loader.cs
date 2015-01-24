//TODO  LOAD AND PLAYS ANIMATIONS


using UnityEngine;
using System.Collections;

/// <summary>
/// DEVELOPER: CIHAN
///  Loader class is used for loading and playing intro animations.
///  It plays animationsthen calls Menu scene (MenuScene).
///  The script is attached to the main camera
/// </summary>
public class Loader : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //Loading Menu scene (MenuScene)
        Application.LoadLevel("MenuScene");
	}
	
}
