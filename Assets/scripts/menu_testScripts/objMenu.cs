using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class objMenu : MonoBehaviour {

	public GameObject panelTop;
	public GameObject panelBot;
	public string topString;
	public string botString;
	Text topText;
	Text botText;
	Vector3 camPos;
	bool objectMenu;
	// Use this for initialization
	void Start () {
		objectMenu = false;
		panelTop.SetActive (false);
		panelBot.SetActive (false);
		topText = panelTop.GetComponentInChildren<Text> ();camPos = Camera.main.transform.position;
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (!objectMenu)
			ObjectFocus ();
		else {
			ObjectGone ();
		}
	}

	void ObjectFocus(){ //zoom in on the interactable object and create the menu
		camPos = Camera.main.transform.position;
		panelTop.SetActive (true);
		panelBot.SetActive (true);
		panelTop.GetComponentInChildren<Text> ().text = topString;
		panelBot.GetComponentInChildren<Text> ().text = botString;
		Camera.main.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -10);
		Camera.main.orthographicSize = 1.3f;
		objectMenu = true;
	}

	void ObjectGone(){
		Camera.main.transform.position = camPos;
		Camera.main.orthographicSize = 4;
		objectMenu = false;
		panelTop.SetActive (false);
		panelBot.SetActive (false);
	}
}
