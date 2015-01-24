using UnityEngine;
using System.Collections;

public class VisualNovelManager : MonoBehaviour {

	string text;
	char[] delimiterChars = { '*' };
	private bool _keyPressed = false;
	string[] phrases;
	int count, oldCount, currentCount;

	void Start(){
		//Load Dialog of the character
		text = "phrase1*phrase2*phrase3";
		Debug.Log("Original text: '{0}'" + text);
		//Parse the string
		phrases = text.Split(delimiterChars);
		Debug.Log("{0} words in text:" + phrases.Length);
		count = phrases.Length;
		currentCount = 0;
		oldCount = -1;
	}

	void Update(){
		//Print each phrase and then wait for a keypress to show the next one
		if(currentCount < count){
			if(currentCount > oldCount){
				Debug.Log(phrases[currentCount]);
				oldCount = currentCount;
			}
		}
		if(Input.GetButtonDown("Jump")){
			currentCount++;
		}
		//StartCoroutine(WaitForKeyPress("Jump"));
	}

}
