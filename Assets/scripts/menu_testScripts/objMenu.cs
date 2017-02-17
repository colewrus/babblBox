using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class objMenu : MonoBehaviour {

	public string topString;
	public string botString;
	public bool learned; //this is to make sure you only learn the word once
	public string germanText;
	public string translationText;
	Text topText;
	Text botText;
	Vector3 camPos;
	bool objectMenu;

	// Use this for initialization
	void Start () {
		objectMenu = false;

		learned = false;
	}

	void OnMouseDown(){
		if (!objectMenu && !menuGM.instance.chatActive) {
			menuGM.instance.currentObj = this.gameObject;
			menuGM.instance.ObjectFocus ();
		} else {
			menuGM.instance.currentObj = null;
			menuGM.instance.ObjectGone ();
		}
	}

}
