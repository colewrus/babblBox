using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public GameObject description_Panel;
	public Text item_Text;

	public GameObject item_Hold;
	public bool panel_Active;

	public List<string> item_Names;
	public Text instructions;


	Vector3 tmpPos; //using it to position instructional text;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {

		Screen.SetResolution (600, 800, false);
		description_Panel.SetActive (false);
		item_Hold = null;
		panel_Active = false;
		instructions.gameObject.SetActive (true);
		instructions.text = "Click me!";
		tmpPos = GameObject.Find ("jail").transform.position;
		tmpPos.y = tmpPos.y - 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		instructions.transform.position = Camera.main.WorldToScreenPoint (tmpPos);
	}

	public void ShowPanel(){
		if (!panel_Active) {
			description_Panel.SetActive (true);
			item_Text.text = item_Hold.GetComponent<objectScript> ().item_Description;
			panel_Active = true;
		} 
	}

	public void ClosePanel(){
		description_Panel.SetActive (false);
		item_Hold = null;
		panel_Active = false;
	}

	public void Restart_Game(){
		SceneManager.LoadScene (0);
	}
}
