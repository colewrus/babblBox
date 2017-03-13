using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class mng_Bubble : MonoBehaviour {

	bool startDialogue;
	public List<GameObject> bubblesList = new List<GameObject>();
	public List<string> bubble_String = new List<string> ();

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
		RunDialogue ();

	}


	void RunDialogue(){
		for (int i = 0; i < bubblesList.Count; i++) {
			bubblesList [i].GetComponentInChildren<Text> ().text = bubble_String [i];
			bubblesList [i].SetActive (true);
		}
	}
}
