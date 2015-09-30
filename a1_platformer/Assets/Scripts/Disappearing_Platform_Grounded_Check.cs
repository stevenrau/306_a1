using UnityEngine;
using System.Collections;

public class Disappearing_Platform_Grounded_Check : MonoBehaviour {

	//If the player falls through the platform (when it disappears), set their grounded flag to false
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player_Movement>().grounded = false;
		}
	}
}
