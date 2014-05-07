using UnityEngine;
using System.Collections;

public class AppleHit : MonoBehaviour {

	CsGlobals gl;

	// Use this for initialization
	void Start () {

		gl = GameObject.FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
	}

	void OnTriggerEnter2D(Collider2D myTrigger) 
	{
		if (myTrigger.gameObject.name == "Apple(Clone)")
		{
			if(gl.curHealth<=90)
			gl.curHealth+=5;
			Destroy(myTrigger.gameObject);
		}
		
	}




	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
