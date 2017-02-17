using UnityEngine;
using System.Collections;

public class chatOptionHandler : MonoBehaviour {

	public bool translate;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown(){
		if (translate) {
			menuGM.instance.translate_chat ();
		} else if (!translate) {
			menuGM.instance.conversation_chat ();
		}
	}
}
