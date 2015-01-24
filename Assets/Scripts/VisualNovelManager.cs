using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisualNovelManager : MonoBehaviour {
	//public
	public GameObject backgroundImage;
	public GameObject npcImage;
	public GameObject npcTextbox;
	public GameObject npcNameText;
	public GameObject npcPhraseText;
	public GameObject playerTextbox;
	public GameObject playerButton1;
	public GameObject playerButton2;
	public GameObject playerButton3;
	public GameObject npcObject;

	//private
	string m_string_text;
	char[] m_charArray_delimiterChars = { '*' };
	string[] m_stringArray_phrases;
	int m_int_count, m_int_oldcount, m_int_currentcount;

	bool canPrint = false;

	void Start(){
		npcTextbox.SetActive(true);
		playerTextbox.SetActive(false);

		//Load Dialog of the character
		m_string_text = "phrase1*phrase2*phrase3";


		//Debug.Log("Original text: '{0}'" + m_string_text);
		//Parse the string
		m_stringArray_phrases = m_string_text.Split(m_charArray_delimiterChars);
		//Debug.Log("{0} words in text:" + m_stringArray_phrases.Length);
		//Set the counter so it knows when the dialog as ended
		m_int_count = m_stringArray_phrases.Length;
		m_int_currentcount = 0;
		m_int_oldcount = -1;
	}

	void Update(){
		//Print each phrase and then wait for a keypress to show the next one
		if(m_int_currentcount < m_int_count){
			if(m_int_currentcount > m_int_oldcount){
				npcPhraseText.GetComponent<Text>().text = "";

				//Print text letter by letter
				//DOES NOT WORK
				//TextPrint(m_stringArray_phrases[m_int_currentcount]); 

				npcPhraseText.GetComponent<Text>().text = m_stringArray_phrases[m_int_currentcount];
				//Debug.Log(m_stringArray_phrases[m_int_currentcount]);
				m_int_oldcount = m_int_currentcount;
			}
		}
		//If it is the end of a dialog and the player has to choose an answer
		else if(m_int_currentcount == m_int_count){
			//Options
			npcTextbox.SetActive(false);
			playerTextbox.SetActive(true);
		}
		//The wait for the keypress
		if(Input.GetButtonDown("Jump")){
			m_int_currentcount++;
		}
	}

	//Change the value of npcObject
	void SetNPC(GameObject npc){
		npcObject = npc;
	}

	//Prints phrase letter by letter
	void TextPrint(string s){
		canPrint = true;
		foreach (char letter in s.ToCharArray()) {
			if(canPrint){
				canPrint = false;
				npcPhraseText.GetComponent<Text>().text += letter;
				StartCoroutine(WaitSomeTime(1.0f));
			}
		} 
	}

	//Wait for some time
	IEnumerator WaitSomeTime(float time){
		canPrint = true;
		yield return new WaitForSeconds(time);
	}

	//
	void OnClickButton1(){

	}

	void OnClickButton2(){
		
	}

	void OnClickButton3(){
		
	}
}

