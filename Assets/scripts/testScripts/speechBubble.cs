using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class speechBubble : MonoBehaviour {

    public GameObject bubble;
	public GameObject symbol;
    public GameObject phoenetic;
    public GameObject native;
    public bool active;

	public Sprite second_Phoenetic;
	public Sprite second_Native;
	public Sprite second_symbol;

	public string item_string_check;

    int viewCount;
    float nativeWordAlpha;
    Color pAlpha;
    Color tAlpha;

	public Sprite alternative_img;


    // Use this for initialization
    void Start () {
        active = true;
        viewCount = 0;
        pAlpha = phoenetic.GetComponent<SpriteRenderer>().color;
        tAlpha = native.GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            bubble.SetActive(true);
        }else
        {
            bubble.SetActive(false);
        }
        
	}

    void OnMouseDown()
    {
		if (active)
        {
            active = false;
			ItemCheck ();
        }else if (!active)
        {
            ViewCounter();
			ItemCheck ();
            active = true;
        }

        
    }

    public void ViewCounter()
    {
        viewCount++;        
        pAlpha.a -= 0.1f;
        tAlpha.a -= 0.1f;
        phoenetic.GetComponent<SpriteRenderer>().color = pAlpha;
        native.GetComponent<SpriteRenderer>().color = tAlpha;

    }

	public void ItemCheck(){
		int tmp = playerScript.instance.items_List.Count;
		for (int i = 0; i < tmp; i++) {
			if(playerScript.instance.items_List[i].name == GM.instance.item_Names[i]){
				symbol.GetComponent<SpriteRenderer> ().sprite = second_symbol;
				phoenetic.GetComponent<SpriteRenderer> ().sprite = second_Phoenetic;
				native.GetComponent<SpriteRenderer> ().sprite = second_Native;
				gameObject.GetComponent<SpriteRenderer> ().sprite = alternative_img;
				pAlpha.a = 1;
				tAlpha.a = 1;
				phoenetic.GetComponent<SpriteRenderer>().color = pAlpha;
				native.GetComponent<SpriteRenderer>().color = tAlpha;
			}
		}
		if (viewCount < 10) {
			GM.instance.instructions.text = "Click me. x10";
		} else {
			GM.instance.instructions.gameObject.SetActive (false);
		}
	}
    
}
