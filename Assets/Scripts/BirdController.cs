using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public float animSpeed;
	public float swingPower;
	public float maxSpeed;
	public float xAcceleration;
	public float stateBird;
	public float control;



	private Animator anim;
	private BoxCollider2D colPlayer;
	private Rigidbody2D rigPlayer;
	private Vector2 force;
	private float gravity;
	private bool sidePlayer;
	private GameObject playerGO; 
	private float bounce;
	private float timeButton;
	private float timeFlip;
	private int countHit;
	private CsGlobals gl;
	private bool stopB;



	// Use this for initialization
	void Start () {
	
		playerGO = (GameObject)this.gameObject;
		rigPlayer = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		colPlayer = GetComponent<BoxCollider2D> ();

		gl = GameObject.FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
		gl.controlPlayer = true;
		gl.sizeHealth = 100;
		gl.curHealth = gl.sizeHealth;
		gl.menu = false;
		gl.scorePlayer = 0;
		gl.timePlayer1 = Time.time;

		bounce = 0;
		force = Vector2.zero;
		swingPower = 13;
		gravity = 0.5f;
		maxSpeed = 20;
		sidePlayer=true;
		xAcceleration = 0.01f;
		timeButton = 0.5f;
		timeFlip = 1f;
		countHit = 0;
		stopB = false;


	}


	private void Fly ()
	{
		if (gl.controlPlayer) 
		{
			if (force.x < maxSpeed) {
				force.x += xAcceleration * Mathf.Abs (transform.position.y);
			} else
				force.x = maxSpeed;
		}
	}

	
	private void Flip()
	{

	
		if (((transform.position.y < -Mathf.Epsilon && !sidePlayer) || (transform.position.y > Mathf.Epsilon && sidePlayer)) && gl.controlPlayer) 
		{
			Vector2 theScale;



				sidePlayer = !sidePlayer;
				theScale = transform.localScale;
				theScale.y *= -1;
				transform.localScale = theScale;


				swingPower *= -1;

				theScale = force;
				theScale.y *= -1;
				force = theScale;

				force.y -= swingPower / 2;
			if(gl.controlPlayer)
				gravity *= -1;


		
		
		}
	


	}

	void OnTriggerEnter2D(Collider2D colPlayer) 
	{
		if (!(colPlayer.gameObject.name == "Apple(Clone)") && !(colPlayer.gameObject.name == "finishTrigger") && !(colPlayer.gameObject.name == "Finish")) {


						gl.controlPlayer = false;
						force.y=0;
						gl.menu=true;

			if(colPlayer.gameObject.name == "Crane") force.x=-force.x/4;
			if (colPlayer.gameObject.name == "Car") force.x=force.x/1.2f;
			
			//if (force.x < -Mathf.Epsilon) force.x=-force.x/2;

			if(colPlayer.gameObject.name == "Trigger1" || colPlayer.gameObject.name == "Car") countHit++;	

					if (!sidePlayer && transform.position.y > Mathf.Epsilon) 
						{
								gravity *= -1;
								swingPower *= -1;
								bounce *= -1;
						}



						if (force.x > Mathf.Epsilon && transform.position.y < -Mathf.Epsilon) {

								force.y = swingPower - bounce;
								bounce += swingPower / 3;
								force.x -= force.x - force.x / 2;
						}
						if (bounce > swingPower) {
								bounce = 0;
								force.y = 0;
						}

				} 


	}



	private void GravityFly ()
	{
		force.y -= gravity;
	}

	private void Gravity ()
	{
		if(force.y < -2)
		force.y -= 2*gravity;
	}

	private void Swing ()
	{
		force.y += swingPower;
	}

	private void Glide ()
	{
		force.y = 0;
	}





	void FixedUpdate () {


		Debug.Log(Time.time);

		if (gl.curHealth <= 0) 
		{
			gl.controlPlayer = false;
			gl.menu=true;
		}


		if (countHit >= 4) 
		{
			force.y=-0.5f;
			force.x=0;

		}

		if (!gl.controlPlayer )
			Gravity ();

		timeButton -= Time.deltaTime;
		timeFlip -= Time.deltaTime;
		if (timeFlip < -Mathf.Epsilon) 
			{
				Flip ();
				timeFlip=0.5f;
			}

		rigPlayer.velocity = force;

		Fly ();

		if ((Input.GetKey("z")||Input.GetKey(KeyCode.Mouse0)) && timeButton < -Mathf.Epsilon && gl.controlPlayer) 
			{	
				Glide ();
				Swing ();
				anim.SetBool ("Up", true); 
				timeButton=0.4f;
			} 
		else
		
			if (Input.GetKeyDown (KeyCode.Space)&& timeButton < -Mathf.Epsilon && gl.controlPlayer) 
			{		
				Glide ();
				Swing ();
				anim.SetBool ("Up", true);
				timeButton=0.4f;
						
			} 
		else 
				{
						GravityFly();
						anim.SetBool ("Up", false); 
				}
	
	}
}
