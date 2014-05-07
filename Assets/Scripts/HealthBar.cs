using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Texture2D barBird;
	public Texture2D headBird;
	public Transform bird;

	private CsGlobals gl;
	private bool isHealthBar; //видимость healthbara
	private float maxLengthHealthBar;
	private float curLengthHealthBar;
	// Use this for initialization
	void Start () {
		maxLengthHealthBar = Screen.width * 0.35f;
		curLengthHealthBar = maxLengthHealthBar;
		gl = GameObject.FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
		isHealthBar = true;

	}


	public void CheckHealthBar(bool a)
	{
		isHealthBar = a;
	}
	public void DownHealthBarSize ()
	{
		if (gl.curHealth > Mathf.Epsilon) 
		{
			gl.curHealth -= gl.curHealth / 1000;
			curLengthHealthBar = gl.curHealth / gl.sizeHealth * maxLengthHealthBar;
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width*0.01f, Screen.width*0.01f, Screen.height*0.08f, Screen.height*0.08f), headBird);	
		GUI.DrawTexture(new Rect(Screen.height*0.08f+Screen.width*0.01f + 5, Screen.width*0.02f, curLengthHealthBar, Screen.height*0.05f), barBird);	

	}
	// Update is called once per frame
	void FixedUpdate () {

		DownHealthBarSize ();
	
	}
}
