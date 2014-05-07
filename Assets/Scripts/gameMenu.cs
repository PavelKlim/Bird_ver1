using UnityEngine;
using System.Collections;

public class gameMenu : MonoBehaviour {

	private CsGlobals gl;	
	private float length;
	private float height;
	// Use this for initialization
	void Start () {

		length = Screen.width / 3;
		height = Screen.height / 8;
		gl = GameObject.FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
	}

	void OnGUI()
	{


	}
	

}
