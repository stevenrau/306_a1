using UnityEngine;
using System.Collections;

public class Disappearing_Object : MonoBehaviour {

	private bool is_active = true;

	// Use this for initialization
	void Start () {
		InvokeRepeating("toggle_active", 1.5f, 1.5f);
	}
	
	void toggle_active()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = !is_active;
		gameObject.GetComponent<BoxCollider2D>().enabled = !is_active;

		is_active = !is_active;
	}
}
