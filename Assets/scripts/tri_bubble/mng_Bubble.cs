using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class bubbleThread{
	public List<string> threadStrings = new List<string>();

}


public class mng_Bubble : MonoBehaviour {

	public static mng_Bubble instance = null;

	public bool startDialogue;
	public List<GameObject> bubblesList = new List<GameObject>();
	//public List<string> bubble_String = new List<string> ();
	public List<bubbleThread> masterList = new List<bubbleThread> ();
	//future idea to make a list of a list of strings. so List[0] is the first thread of dialogue, List[1] the second element


	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}


	// Attach this to the object that you want to 
	void Start () {
		startDialogue = false;
		for (int i = 0; i < bubblesList.Count; i++) {
			bubblesList [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown(){ //make sure object has a box colider
		print(gameObject.name);

		if (startDialogue) {
			for (int i = 0; i < bubblesList.Count; i++) {
				bubblesList [i].SetActive (false);
			}
			startDialogue = false;
		} else {
			RunDialogue (0);
			startDialogue = true;
		}

	}


	public void RunDialogue(int pos){
		for (int i = 0; i < bubblesList.Count; i++) {
			bubblesList [i].GetComponentInChildren<Text> ().text = masterList [pos].threadStrings [i];
			//gonna need to set the position with worldtoscreenpoint

			bubblesList [i].SetActive (true);
		}
	}
}
