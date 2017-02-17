using UnityEngine;
using System.Collections;

public class card_UI_Script : MonoBehaviour {

	Vector3 startPos;
	bool selected;

	void Start(){
		startPos = gameObject.transform.position;	
		selected = false;
	}

	public void OnDrag(){
		print (startPos);
		Vector2 pos;
		transform.position = Input.mousePosition;
		selected = true;
	}

	void Update(){
		if (!selected) {
			print ("update");
			transform.position = Vector3.Lerp (transform.position, startPos, 2 * Time.deltaTime);
		}
	}

	public void BoolToggle(){
		selected = false;
	}
}
