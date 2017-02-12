using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class germanGM : MonoBehaviour {

	public static germanGM instance = null;

	public GameObject wordBankPanel;


	public List<GameObject> questObj; //all the quest objects in the scene. Objects need a script on them that hold all their data -> will be transfered to the quest class
	public quest_Class[] qClass;
	public List<string> d1;
	public List<string> d2;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		wordBankPanel.SetActive (false);
		GenerateQuestList ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// create quest data. will need to pull information from the script attached to each instance of the quest objects. 
	void GenerateQuestList(){
		qClass = new quest_Class[questObj.Count]; //initialize our list of classes

		for (var i = 0; i < qClass.Length; i++) {
			var node = new quest_Class (); //create a new element 
			node.Name = "" + questObj [i].gameObject.name; //set the name to the gameObject name

			var pList = questObj [i].GetComponent<obj_Convo> ().playerDialogue; //placeholder for gameObject's player dialogue

			for (var t = 0; t < pList.Count; t++) { //now search for the length of the player dialogue list and add all instances to class list
				node.playerText.Add (pList [t]);
			}

			var cList = questObj [i].GetComponent<obj_Convo> ().compDialogue; //hold for GOs computer dialogue

			for (var y = 0; y < cList.Count; y++) {
				node.compText.Add (cList [y]);
				print (cList [y]);
			}

			qClass [i] = node; //add our "node" instance to the master list			

		}

	}


	/*
	 *On click -> 
	 *	set bool -> 
	 *	check the bool state -> 
	 *		if true then proceed to X
	 *			Zoom camera back out to show player
	 *			make speech bubble & conversation panels appear
	 *				grab the conversation STRINGS from the gameObject !---------- Give the gameObject 2 lists of text, player and NPC/Story text
	 *				!----- list of booleans on the gameObject and a button mirror boolean. UI buttons have a true/false value assigned and get reflected by the bool mirror. Increment through the publc boolean list
	 *				!----- and then print the next from the True/False lists of strings
	 *				
	 *			
	 *	
	 *
	 * 
	 * 
	 * 
	 * 
	 * 
	*/

	public void panelToggle(GameObject obj){
		
		if (obj.activeSelf)
			obj.SetActive (false);
		else if (!obj.activeSelf)
			obj.SetActive (true);		
	}


}
