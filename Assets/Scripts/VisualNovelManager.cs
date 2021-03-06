﻿using UnityEngine;
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
	
	public HubSoundStarter Hub_MusicScript;
	public HubSoundStarter Hub_AmbiantScript;
	public AudioClip defaultAmbiant;
	private bool isDefaultAmbiant;
	public AudioClip defaultBackgroundMusic;

	//private
	string m_string_text;
	char[] m_charArray_delimiterChars = { '*' };
	string[] m_stringArray_phrases;
	int m_int_count, m_int_oldcount, m_int_currentcount;

	//Dialog management
	Dialog dial;
	List<Option> optionList;
	string npcId;
	int dialogId;

	//Trying to slow down the text printing (DOESN'T WORK)
	bool canPrint = false;

	void Start(){ 

	}

	void Init() {
		//A Dialog doesn't begin with options
		npcTextbox.SetActive(true);
		playerTextbox.SetActive(false);
		interactText.GetComponent<Text>().text = "";

		if(npcObject.affectionSlider != null){
			gameObject.GetComponentInChildren<Slider>().enabled = true;
			npcObject.affectionSlider = gameObject.GetComponentInChildren<Slider>();
		}
		else{
			gameObject.GetComponentInChildren<Slider>().enabled = false;
		}

		//Load Dialog of the NPC
		npcId = npcObject.name;
		dialogId = npcObject.dialogId;
		dial = DialogManager.getNextDialog( npcId, dialogId );
		optionList = dial.getOptions();

		//Should we change the backgroundImage? Let's check
		SetBackgroundImage(dial);
		Hub_MusicScript.hubSound = npcObject.MusicAudio;
		Hub_MusicScript.StartSound();
		isDefaultAmbiant = true;
		SetAmbiant(dial);

		//Load Character
		if(npcObject.characterExpressions.Length >0){
			npcImage.SetActive(true);
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[0];
		}
		else{
			npcImage.SetActive(false);
		}
		npcNameText.GetComponent<Text>().text = dial.CharacterName;

		//Parse the string
		m_string_text = dial.Text;
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
			//We set the buttons depending on the number of options available
			//We don't need the normal textbox display
			npcTextbox.SetActive(false);
			playerTextbox.SetActive(true);

			//We desactivate every button except the first (always at least an option)
			playerButton1.GetComponentInChildren<Text>().text = optionList[0].Text;
			playerButton2.SetActive(false);
			playerButton3.SetActive(false);
			//If there is two options
			if (optionList.Count == 2){
				playerButton2.SetActive(true);
				playerButton2.GetComponentInChildren<Text>().text = optionList[1].Text;
			}
			//If there is three options
			else if(optionList.Count == 3){
				playerButton2.SetActive(true);
				playerButton3.SetActive(true);
				playerButton2.GetComponentInChildren<Text>().text = optionList[1].Text;
				playerButton3.GetComponentInChildren<Text>().text = optionList[2].Text;
			}
		}
		//The wait for the keypress
		if(!playerTextbox.activeSelf){
			if(Input.GetButtonDown("Jump")){
				m_int_currentcount++;
			}
		}
	}

	//It's the kind of thing in the Start function without having the reboot the object
	public void NextDialog(Dialog d){
		npcTextbox.SetActive(true);
		playerTextbox.SetActive(false);

		//Change the background?
		SetBackgroundImage(d);
		SetAmbiant(d);

		//Set new texts
		m_string_text = d.Text;
		optionList = d.getOptions();

		//Parse the string
		m_stringArray_phrases = m_string_text.Split(m_charArray_delimiterChars);

		//Set the counter so it knows when the dialog as ended
		m_int_count = m_stringArray_phrases.Length;
		m_int_currentcount = 0;
		m_int_oldcount = -1;
	}

	//Change the value of npcObject
	public void SetNPC(NPC npc){
		npcObject = npc;
		Init();
	}

	//Prints phrase letter by letter
	//DOES NOT WORK
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
		else{
			backgroundImage.SetActive(false);
		}
	}
	//Depending on the place contained in the Dialog, we set the correct ambiant sound for the character
	void SetAmbiant(Dialog d){
		if(d.Place != "school"){
			switch(d.Place){
			case "date1": Hub_AmbiantScript.hubSound = npcObject.AmbiantAudio[0];
				break;
			case "date2": Hub_AmbiantScript.hubSound = npcObject.AmbiantAudio[1];
				break;
			case "date3": Hub_AmbiantScript.hubSound = npcObject.AmbiantAudio[2];
				break;
			default: break;
			}
			if (isDefaultAmbiant == true){
				Hub_AmbiantScript.StartSound();
				isDefaultAmbiant = false;
			}
		}
		else if (!isDefaultAmbiant) {
			Hub_AmbiantScript.hubSound = defaultAmbiant;
			Hub_AmbiantScript.StartSound();
			isDefaultAmbiant = true;
		}
	}

	//Wait for some time
	IEnumerator WaitSomeTime(float time){
		canPrint = true;
		yield return new WaitForSeconds(time);
	}

	//Each button has it's own call
	//Every position is set to have a kind of effect
	public void OnClickButton1(){
		/*
		if(optionList.ItemCheck!=0){
			CheckItemTrue(optionList.ItemCheck);
		}
		*/

		//We reset the expression so the NPC doesn't stay in a certain mood
		if(npcObject.characterExpressions.Length > 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[0];
		}
		//If we need to add affection, then we might change the characterExpression t

		if(optionList[0].AffectionValue != 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[1];
			//We add the afection only if it isn't a hundred
			if(npcObject.affection < 100f){
				npcObject.AddAffection(optionList[0].AffectionValue);
			}
		}
		//If this option lead to a return to the HUD
		if(optionList[0].IsEnd){
			//Change the music and ambiant sound to default
			Hub_MusicScript.hubSound = defaultBackgroundMusic;
			Hub_AmbiantScript.hubSound = defaultAmbiant;
			Hub_MusicScript.StartSound();
			Hub_AmbiantScript.StartSound();
			//We set the next Dialog in the NPC so next time we talk to hit, we return at the same place
			npcObject.dialogId = dial.getNextDialogId(0);
			//We give back the power to move to the player
			player.SetDisableMoveFalse();
			interactText.GetComponent<Text>().text = "Press 'Action' to interact";
			//And we hide the Canvas
			gameObject.SetActive(false);
		}
		//If it doesn't send you back to the HUD, get the next option
		else{
			dial = DialogManager.getNextDialog( npcId, dial.getNextDialogId(0) );
			//We call NextDialog to deal with the next Dialog
			NextDialog(dial);
		}
	}

	//See OnClickButton1()
	public void OnClickButton2(){
		if(npcObject.characterExpressions.Length > 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[0];
		}
		if(optionList[1].AffectionValue != 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[2];
			if(npcObject.affection < 100f){
				npcObject.AddAffection(optionList[1].AffectionValue);
			}
		}

		if(optionList[1].IsEnd){
			Hub_MusicScript.hubSound = defaultBackgroundMusic;
			Hub_AmbiantScript.hubSound = defaultAmbiant;
			Hub_MusicScript.StartSound();
			Hub_AmbiantScript.StartSound();
			npcObject.dialogId = dial.getNextDialogId(1);
			player.SetDisableMoveFalse();
			interactText.GetComponent<Text>().text = "Press 'Action' to interact";
			gameObject.SetActive(false);
		}
		else{
			dial = DialogManager.getNextDialog( npcId, dial.getNextDialogId(1) );
			NextDialog(dial);
		}
	}

	//See OnClickButton1()
	public void OnClickButton3(){
		if(npcObject.characterExpressions.Length > 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[0];
		}
		if(optionList[2].AffectionValue != 0){
			npcImage.GetComponent<Image>().sprite = npcObject.characterExpressions[3];
			if(npcObject.affection < 100f){
				npcObject.AddAffection(optionList[2].AffectionValue);
			}
		}

		if(optionList[2].IsEnd){
			Hub_MusicScript.hubSound = defaultBackgroundMusic;
			Hub_AmbiantScript.hubSound = defaultAmbiant;
			Hub_MusicScript.StartSound();
			Hub_AmbiantScript.StartSound();
			npcObject.dialogId = dial.getNextDialogId(2);
			player.SetDisableMoveFalse();
			interactText.GetComponent<Text>().text = "Press 'Action' to interact";
			gameObject.SetActive(false);
			if(optionList[2].ItemCheck > 0)
			{
				reactToDialogue(optionList[2], npcObject);
			}
		}
		else{
			dial = DialogManager.getNextDialog( npcId, dial.getNextDialogId(2) );
			NextDialog(dial);
		}
	}

	void reactToDialogue(Option op, NPC npc) {
		if(npc.name == "bench") {
			if(op.ItemCheck == 1) {
				//Receive water bottle
				player.objectives[0] = true;
			}
			else if(op.ItemCheck == 2) {
				//Fight

			}
		}
		//else if(npc.name == "") {
		//}
		//else if(npc.name == "") {
		//}
	}

	//Check if the player has the item set to true;
	/*
	void CheckItemTrue(int itemNumber){
		//GetItem(itemNumber);
		if(npcObject.name == "bench"){
			player.SetItem(itemNumber);
		}
		if( !player.GetItem(itemNumber) ){
			optionList[0].IsEnd = true;
		}
	}
	 */
}

