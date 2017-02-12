using UnityEngine;
using System.Collections;

public class missionObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print ("hit");
	}

	void OnTriggerEnter2D(Collider2D other){
		print (other.gameObject.name);
	}
}
