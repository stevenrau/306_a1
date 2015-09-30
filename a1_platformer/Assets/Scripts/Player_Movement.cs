using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float max_speed = 5.0f;
	public float jump_height = 1.0f;
	public bool grounded;

	private Vector3 spawn_point;
	private bool perform_jump = false;
	private bool facing_right = true;
	private Animator animation_controller;
	private Rigidbody2D rigid_body;

	// Use this for initialization
	void Start () 
	{
		animation_controller = GetComponent<Animator>();
		rigid_body = GetComponent<Rigidbody2D>();

		//Set the spawn point to be the player's original position
		spawn_point = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Checks whether the player wants to jump
		if (Input.GetButtonDown("Jump"))
		{
			perform_jump = true;
		}
	}

	void FixedUpdate()
	{
		//Update the animator with the grounded flag
		animation_controller.SetBool("grounded", grounded);

		//Get user input for left and right movement
		float move = Input.GetAxis("Horizontal");

		//Flip the player so that he is facing in driection of movement
		if (facing_right && move < 0) {
			flip_character();
		}
		else if (!facing_right && move > 0){
			flip_character();
		}
	
		//Apply the input movement to the player
		animation_controller.SetFloat ("speed", Mathf.Abs(move));
		rigid_body.velocity = new Vector2 (max_speed * move, rigid_body.velocity.y);

		//Perform a jump if requested and player is currently grounded
		if (perform_jump)
		{
			if (grounded)
			{
				jump ();
			}

			perform_jump = false;
		}
	}

	void flip_character()
	{

		facing_right = !facing_right;
		Vector3 cur_scale = transform.localScale;
		cur_scale.x = cur_scale.x * -1; //Flip the character by negating x scale
		transform.localScale = cur_scale;
	}
	
	void jump()
	{
		rigid_body.AddForce(new Vector2(0, jump_height), ForceMode2D.Impulse);
		animation_controller.SetTrigger ("jump");
	}

	public void respawn()
	{
		transform.position = spawn_point;
		animation_controller.SetBool("grounded", true);
	}
}
