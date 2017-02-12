using UnityEngine;
using System.Collections;

public class phoneScript : MonoBehaviour {

	public GameObject speechPanel;


	// Use this for initialization
	void Start () {
		speechPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		germanGM.instance.panelToggle (speechPanel);
		this.gameObject.GetComponent<Animator> ().Stop ();
	}
}
