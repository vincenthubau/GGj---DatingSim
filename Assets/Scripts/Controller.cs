using UnityEngine;
using System.Collections;

/// <summary>
/// DEVELOPER: CIHAN
/// Controller class is used for controlling the menu events in the game
/// The script is attached to GameController object which will not destroy on load.
/// </summary>
public class Controller : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //Debug.Log("MENU");

        //Load scenarios
        DialogManager.loadScenarios();
		//Call the game Scene
		Application.LoadLevel(1);
        
	}
	
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
