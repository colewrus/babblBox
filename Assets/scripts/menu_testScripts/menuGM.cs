using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class menuGM : MonoBehaviour {

	public static menuGM instance = null;

	//[HideInInspector]
	public GameObject currentObj; //placeholder for the active object being zoomed in on
	public List<string> wordBank;
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
	}


	public void chat_Start(){
		ObjectGone (); //reset camera, remove initial panels
		wordLearn(); //add word to wordbank
		//add glow behavior for the ui item

		mainBubble.SetActive (true);
		mainBubble.transform.position = new Vector3 (currentObj.transform.position.x, currentObj.transform.position.y + 1.5f, -1);
		Camera.main.transform.position = new Vector3 (mainBubble.transform.position.x, mainBubble.transform.position.y, -10);
		chatCheck.SetActive (true);
		chatCheck.transform.position = new Vector3 (mainBubble.transform.position.x, currentObj.transform.position.y - 1, -1);
		questAdvance.SetActive (true);
		questAdvance.transform.position = new Vector3 (mainBubble.transform.position.x, currentObj.transform.position.y + 3.5f, -1);
		dasPanel_img.gameObject.SetActive (false);
	}

	public void wordLearn(){ //adds a word to the bank
		if(!currentObj.GetComponent<objMenu>().learned) 
			wordBank.Add (currentObj.GetComponent<objMenu> ().topString);
			currentObj.GetComponent<objMenu> ().learned = true;
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
