using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class basic_WASD : MonoBehaviour {

	Vector3 move;
	public List<string> animationNames = new List<string>();

	public float speed;
	float horizontal;
	float vertical;

	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>(); //!------ NEEDS A RIGIDBODY 2D -------!
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		AnimationSelector ();
	}

	void Movement(){
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

		rb.velocity = new Vector2(move.x*speed, move.y*speed);
	}


	void AnimationSelector()
	{
		if (move.x < 0) //Left animation
		{			
			gameObject.GetComponent<Animator>().Play(animationNames[0]);
		}
		else if (move.x > 0) //right animation
		{
			gameObject.GetComponent<Animator>().Play(animationNames[1]);
		}
		else if (move.y > 0) //up animation
		{
			gameObject.GetComponent<Animator>().Play(animationNames[2]);
		}
		else if (move.y < 0) //down animation
		{
			gameObject.GetComponent<Animator>().Play(animationNames[3]);
		}else  //idle animation
		{
			gameObject.GetComponent<Animator>().Play(animationNames[4]);
		}
	}
}
