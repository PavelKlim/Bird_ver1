using UnityEngine;
using System.Collections;

public class CarsLeftAmbulancy : MonoBehaviour {

	public Transform temp;
	public bool move;
	private PolygonCollider2D colCar;
	private Vector2 position;



	// Use this for initialization
	void Start () {

		colCar = GetComponent<PolygonCollider2D> ();
		position = colCar.transform.position;	
		move = true;

	}

	void OnTriggerEnter2D(Collider2D myTrigger) 
	{
		if (myTrigger.gameObject.name == "Bird")
		{
			move=false;
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if ((transform.position.x - temp.position.x < 35 && !(temp.position.x-transform.position.x >35))&& move) 
		{
			colCar.transform.position = position;
			position.x -= 0.2f;
		}


	
			
		
	}
}
