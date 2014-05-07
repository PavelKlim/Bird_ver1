using UnityEngine;
using System.Collections;

public class ApplePos : MonoBehaviour {


	public GameObject applePrefab;

	private Vector2 posApple;
	private GameObject temp1;

	// Use this for initialization
	void Start () {
	//	applePrefab = (GameObject)Resources.Load ("Apple", typeof(GameObject));
		posApple = applePrefab.transform.position;
		posApple.y -= 17;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (posApple.x < 480) {
						posApple.x = posApple.x + 20;
						posApple.y = 7*Mathf.Sin (posApple.x);
						temp1 = (GameObject)Instantiate (applePrefab, posApple, transform.rotation); 
				}
	}
}
