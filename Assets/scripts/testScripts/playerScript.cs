using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerScript : MonoBehaviour {

	public static playerScript instance = null;
    float horizontal;
    float vertical;
    Vector3 move;
    bool move_Enabled;
    public float speed;
    bool currently_Moving;
    public Sprite idle_Sprite;
    public Rigidbody2D rb;

	public List<GameObject> items_List;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}


	// Use this for initialization
	void Start () {
        move_Enabled = true;
        rb = GetComponent<Rigidbody2D>();
		horizontal = 0;
		vertical = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        AnimationSelector();
	}

    void Movement()
    {
        if (move_Enabled)
        {
            //move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            
            if (horizontal > 0)
            {
                move.x = 0.75f;
                move.y = 0;
            }
            else if (horizontal < 0)
            {
                move.x = -0.75f;
                move.y = 0;
            }
            else if (vertical > 0)
            {
                move.y = 0.75f;
                move.x = 0;
            }
            else if (vertical < 0)
            {
                move.y = -0.75f;
                move.x = 0;
            }
            else
            {
                move = Vector3.zero;
            }

            //transform.position += move * speed * Time.deltaTime;
            //rb.AddForce(new Vector2(move.x, move.y) * speed);
			rb.velocity = new Vector2(move.x*speed, move.y*speed);
            if (move != Vector3.zero)
            {
                currently_Moving = true;

            }
            else
            {
                currently_Moving = false;
                rb.velocity = new Vector2(0, 0);
            }
        }
    }

    void AnimationSelector()
    {
        if (move.x < 0)
        {
            gameObject.GetComponent<Animator>().Play("left_anim");
        }
        else if (move.x > 0)
        {
            gameObject.GetComponent<Animator>().Play("right_anim");
        }
        else if (move.y > 0)
        {
            gameObject.GetComponent<Animator>().Play("up_anim");
        }
        else if (move.y < 0)
        {
            gameObject.GetComponent<Animator>().Play("down_anim");
        }else
        {
            gameObject.GetComponent<Animator>().Play("idle_anim");
        }
    }

	void OnMouseDown(){
		print (gameObject.name);
	}



}
