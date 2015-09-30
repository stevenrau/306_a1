using UnityEngine;
using System.Collections;

public class Ground_Check : MonoBehaviour {

	//Keep a reference to the parent player
	private Player_Movement player;

	// Use this for initialization
	void Start ()
	{
		player  = GetComponentInParent<Player_Movement>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Floor")
		{
			player.grounded = true;
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Floor")
		{
			player.grounded = false;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Floor")
		{
			player.grounded = true;
		}
	}
}
