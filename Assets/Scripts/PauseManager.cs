using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
	public GameObject pauseObject;
	bool paused;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			PauseGame();
		}
	}

	void PauseGame(){
		if(paused){
			pauseCanvas.SetActive(false);
			Time.timeScale = 1;
			paused = false;
		}
		else{
			Time.timeScale = 0;
			paused = true;
			pauseCanvas.SetActive(true);
		}
	}

	public void QuitGame(){
		Application.Quit();
	}
}
