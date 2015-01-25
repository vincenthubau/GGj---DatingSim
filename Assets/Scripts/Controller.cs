using UnityEngine;
using System.Collections;

/// <summary>
/// DEVELOPER: CIHAN
/// Controller class is used for controlling the menu events in the game
/// The script is attached to GameController object which will not destroy on load.
/// </summary>
public class Controller : MonoBehaviour
{
	public GameObject creditsImage;
	// Use this for initialization
	void Start ()
    {
		creditsImage.SetActive(false);
        //Debug.Log("MENU");

        //Load scenarios
        DialogManager.loadScenarios();
        
	}
	
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	public void LoadGame(){
		Application.LoadLevel(1);
	}

	public void ToggleCredits(){
		if(creditsImage.activeSelf){
			creditsImage.SetActive(false);
		}
		else{
			creditsImage.SetActive(true);
		}
	}

}
