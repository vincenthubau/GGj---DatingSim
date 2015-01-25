using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VisualNovelManager : MonoBehaviour {
	//public
	public GameObject backgroundImage;
	public GameObject npcImage;
	public GameObject interactText;
	public GameObject npcTextbox;
	public GameObject npcNameText;
	public GameObject npcPhraseText;
	public GameObject playerTextbox;
	public GameObject playerButton1;
	public GameObject playerButton2;
	public GameObject playerButton3;
	public NPC npcObject;
	public Player player;

	//private
	string m_string_text;
	char[] m_charArray_delimiterChars = { '*' };
	string[] m_stringArray_phrases;
	int m_int_count, m_int_oldcount, m_int_currentcount;

	Dialog dial;
	List<Option> optionList;

	bool canPrint = false;

	//Temp
	string npcId = "trial";
	int dialogId = 0;

	void Start(){
		npcTextbox.SetActive(true);
		playerTextbox.SetActive(false);

		npcObject.affectionSlider = gameObject.GetComponentInChildren<Slider>();

		//Load Dialog of the character
		npcId = npcObject.name;
		dialogId = npcObject.dialogId;
		dial = DialogManager.getNextDialog( npcId, dialogId );
		//Should we change the backgroundImage? Let's check
		SetBackgroundImage(dial);

		optionList = dial.getOptions();
		//Load Background
		interactText.SetActive(false);
		//backgroundImage.SetActive(true);
		//Load Character
		npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[0];
		//if(dial.CharacterName != "Me")
		//dial.CharacterName
		npcNameText.GetComponent<Text>().text = dial.CharacterName;

		m_string_text = dial.Text;

		//Parse the string
		m_stringArray_phrases = m_string_text.Split(m_charArray_delimiterChars);

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
			playerButton1.GetComponentInChildren<Text>().text = optionList[0].Text;
			playerButton2.SetActive(false);
			playerButton3.SetActive(false);
			if (optionList.Count == 2){
				playerButton2.SetActive(true);
				playerButton2.GetComponentInChildren<Text>().text = optionList[1].Text;
				playerButton3.SetActive(false);
			}
			else if(optionList.Count == 3){
				playerButton2.SetActive(true);
				playerButton2.GetComponentInChildren<Text>().text = optionList[1].Text;
				playerButton3.SetActive(true);
				playerButton3.GetComponentInChildren<Text>().text = optionList[2].Text;
			}
		}
		//The wait for the keypress
		if(Input.GetButtonDown("Jump")){
			m_int_currentcount++;
		}
	}

	public void NextDialog(Dialog d){
		npcTextbox.SetActive(true);
		playerTextbox.SetActive(false);
		//Change the background?
		SetBackgroundImage(d);
		m_string_text = d.Text;
		optionList = d.getOptions();
		//Parse the string
		m_stringArray_phrases = m_string_text.Split(m_charArray_delimiterChars);
		//Debug.Log("{0} words in text:" + m_stringArray_phrases.Length);
		//Set the counter so it knows when the dialog as ended
		m_int_count = m_stringArray_phrases.Length;
		m_int_currentcount = 0;
		m_int_oldcount = -1;
	}

	//Change the value of npcObject
	public void SetNPC(NPC npc){
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

	//Depending on the place contained in the Dialog, we set the correct background for the character
	void SetBackgroundImage(Dialog d){
		if(d.Place != "school"){
			backgroundImage.SetActive(true);
			switch(d.Place){
			case "date1": backgroundImage.GetComponent<Image>().sprite = npcObject.backgroundImages[0];
				break;
			case "date2": backgroundImage.GetComponent<Image>().sprite = npcObject.backgroundImages[1];
				break;
			case "date3": backgroundImage.GetComponent<Image>().sprite = npcObject.backgroundImages[2];
				break;
			default: break;
			}
		}

	}

	//Wait for some time
	IEnumerator WaitSomeTime(float time){
		canPrint = true;
		yield return new WaitForSeconds(time);
	}

	//
	public void OnClickButton1(){
		//The way to add affection
		if(optionList[0].AffectionValue != 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[1];
			if(npcObject.affection < 100f){
				npcObject.AddAffection(optionList[1].AffectionValue);
			}
		}
		if(optionList[0].IsEnd){
			npcObject.dialogId = dial.getNextDialogId(0);
			player.SetDisableMoveFalse();
			gameObject.SetActive(false);
		}
		else{
			dial = DialogManager.getNextDialog( npcId, dial.getNextDialogId(0) );
			NextDialog(dial);
		}
	}

	public void OnClickButton2(){
		if(optionList[1].AffectionValue != 0){
			//npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[2];
			if(npcObject.affection < 100f){
				npcObject.AddAffection(optionList[1].AffectionValue);
			}
		}
		if(optionList[1].IsEnd){
			npcObject.dialogId = dial.getNextDialogId(1);
			player.SetDisableMoveFalse();
			gameObject.SetActive(false);
		}
		else{
			dial = DialogManager.getNextDialog( npcId, dial.getNextDialogId(1) );
			NextDialog(dial);
		}
	}

	public void OnClickButton3(){
		if(optionList[2].AffectionValue != 0){
			//npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[3];
			if(npcObject.affection < 100f){
				npcObject.AddAffection(optionList[1].AffectionValue);
			}
		}
		if(optionList[2].IsEnd){
			npcObject.dialogId = dial.getNextDialogId(2);
			player.SetDisableMoveFalse();
			gameObject.SetActive(false);
		}
		else{
			dial = DialogManager.getNextDialog( npcId, dial.getNextDialogId(2) );
			NextDialog(dial);
		}
	}
}

