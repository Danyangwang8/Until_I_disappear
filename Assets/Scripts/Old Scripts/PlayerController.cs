using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector] public bool jump = false;
	public float upForce = 200f;                   //Upward force of the "flap".
	private bool isDead = false;            //Has the player collided with a wall?

//	private Animator anim;                  //Reference to the Animator component.
	private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the player.

//	public AudioClip jumpSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	public Transform groundCheck;
	private bool grounded = false;

	//Jump different 3D
	//private Vector2 up;

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
//		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

		//Jump different
		//up = transform.TransformDirection (Vector2.up);
//		source = GetComponent<AudioSource>();

	}

	void Update()
	{
		//Don't allow control if the bird has died.
		if (isDead == false) 
		{
			//Look for input to trigger a "flap".
			if (Input.GetMouseButtonDown(0)) 
			{
				//...tell the animator about it and then...
//				anim.SetTrigger("Jump");
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//  new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));

				//rb2d.AddForce (up * 5, ForceMode.Impulse); 3D jump
//				float vol = Random. Range (volLowRange, volHighRange);
//				source.PlayOneShot(jumpSound,vol);
			}
		}

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetMouseButtonDown(0) && grounded)
		{
			jump = true;
		}
	}

	/*
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Lava")) {
			// Zero out the bird's velocity
			rb2d.velocity = Vector2.zero;
			// If the bird collides with something set it to dead...
			isDead = true;
			//...tell the Animator about it...
			anim.SetTrigger ("Die");
			//...and tell the game control about it.

			GameController.instance.PlayerDied ();
		}

	}

	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag ("Score")) {
			GameController.instance.PlayerScored ();

		}

	}
	*/
}

