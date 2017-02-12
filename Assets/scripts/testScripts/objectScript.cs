using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class objectScript : MonoBehaviour {


	public string item_Description;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GM.instance.item_Hold = this.gameObject;
		GM.instance.ShowPanel ();	
		playerScript.instance.items_List.Add (this.gameObject);
		gameObject.SetActive (false);
	}
}
