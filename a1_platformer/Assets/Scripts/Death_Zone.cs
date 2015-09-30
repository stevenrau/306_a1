using UnityEngine;
using System.Collections;

public class Death_Zone : MonoBehaviour {

	// If the payer enters this zone, kill and respawn
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player_Movement>().respawn();
		} 
	}
}
