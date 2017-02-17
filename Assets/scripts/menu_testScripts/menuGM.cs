using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class menuGM : MonoBehaviour {

	public static menuGM instance = null;

	//[HideInInspector]
	public GameObject currentObj; //placeholder for the active object being zoomed in on
	public List<string> wordList_string;
	public GameObject dasPanel; //the "was ist das" panel
	public Text dasPanel_text;
	public Image dasPanel_img;
	//---------- Main Object panel variables ------//
	public GameObject panelTop;
	public GameObject panelBot;
	Vector3 camPos;
	bool objectMenu;
	//---------- Chat bubble variables --------//
	public GameObject mainBubble;
	public GameObject chatCheck;  //if tapped pulls up panel that shows translation of chat bubble - triggers new words being learned
	public GameObject questAdvance; //workspace panel and 
	public bool chatActive; //helps manage when we move from the panel back to the object
	public Text dasPanel_GermanText;

	//---------- Conversation variables -------//
	public GameObject panel_wordBank;
	public List<GameObject> wordList_cards; //gonna need to instantiate all the cards for the words. Attach the string to the prefab
	public GameObject panel_Conversation;


	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		objectMenu = false;
		currentObj = null;
		camPos = Camera.main.transform.position;
		dasPanel.SetActive (false);
		mainBubble.SetActive (false);
		chatCheck.SetActive (false);
		questAdvance.SetActive (false);
		panelTop.SetActive (false);
		panelBot.SetActive (false);
		chatActive = false;
		panel_Conversation.SetActive (false);
		panel_wordBank.SetActive (false);

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			print (wordList_cards [2].transform.position);
		}
	}

	public void chat_Start(){ //open up the chat bubble 
		ObjectGone (); //reset camera, remove initial panels
		wordLearn(); //add word to wordbank
		//add glow behavior for the ui item
		chatActive = true;
		mainBubble.SetActive (true);
		mainBubble.transform.position = new Vector3 (currentObj.transform.position.x, currentObj.transform.position.y + 1.5f, -1);
		Camera.main.transform.position = new Vector3 (mainBubble.transform.position.x, mainBubble.transform.position.y, -10);
		chatCheck.SetActive (true);
		chatCheck.transform.position = new Vector3 (mainBubble.transform.position.x, currentObj.transform.position.y - 1, -1);
		questAdvance.SetActive (true);
		questAdvance.transform.position = new Vector3 (mainBubble.transform.position.x, currentObj.transform.position.y + 3.5f, -1);
		dasPanel_img.gameObject.SetActive (false);
	}

	public void translate_chat(){ //translate what was in the chat bubble
		dasPanel.SetActive (true);
		//set the german text
		dasPanel_GermanText.text = currentObj.GetComponent<objMenu>().germanText;
		dasPanel_text.text = currentObj.GetComponent<objMenu> ().translationText;
		dasPanel_GermanText.gameObject.SetActive (true);

	}

	public void conversation_chat(){ //begin the conversation
		panel_Conversation.SetActive(true);
		panel_wordBank.SetActive (true);
		mainBubble.SetActive (false);
		chatCheck.SetActive (false);
		questAdvance.SetActive (false); 
		panel_Conversation.GetComponentInChildren<Text> ().text = currentObj.GetComponent<objMenu> ().germanText;
		cardCreate (0);
	}


	public void wordLearn(){ //adds a word to the bank  -------------!!!!!!!!!!!!------------need an object pool
		if(!currentObj.GetComponent<objMenu>().learned) 
			wordList_string.Add(currentObj.GetComponent<objMenu> ().topString);
			currentObj.GetComponent<objMenu> ().learned = true;
	}

	public void cardCreate(int position){ //position is the scroll wheel for this, steps ahead enough spaces in the string list to properly update the card
		
		for (int i = 0; i < wordList_cards.Count; i++) {
			wordList_cards [i].GetComponentInChildren<Text> ().text = wordList_string [i + (position * 4)];

		}
	}


	public void dasPanel_Function(){ //opens up the was ist das panel
		dasPanel_img.gameObject.SetActive(true);
		dasPanel_img.sprite = currentObj.GetComponent<SpriteRenderer> ().sprite;
		var tempString = currentObj.name;
		dasPanel_text.text = "Das ist " + tempString;
		dasPanel.SetActive (true);
		ObjectGone ();
	}

	public void dasPanel_Close(){ 
		dasPanel.SetActive (false);
		if(!chatActive)
			ObjectFocus ();
	}


	public void ObjectFocus(){ //zoom in on the interactable object and create the menu
		camPos = Camera.main.transform.position;
		panelTop.SetActive (true);
		panelBot.SetActive (true);
		panelTop.GetComponentInChildren<Text> ().text = currentObj.GetComponent<objMenu> ().topString;
		panelBot.GetComponentInChildren<Text> ().text = currentObj.GetComponent<objMenu> ().botString;
		Camera.main.transform.position = new Vector3 (currentObj.transform.position.x, currentObj.transform.position.y, -10);
		Camera.main.orthographicSize = 1.3f;
		objectMenu = true;
	}

	public void ObjectGone(){
		Camera.main.transform.position = camPos;
		Camera.main.orthographicSize = 4;
		objectMenu = false;
		panelTop.SetActive (false);
		panelBot.SetActive (false);
	}


	//make a funciton that makes the word bank glow
}
