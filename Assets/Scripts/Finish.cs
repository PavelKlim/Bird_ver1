using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	private CsGlobals gl;
	private float score;
	private bool gui;
	private float length;
	private float height;
	private string add;

	// Use this for initialization
	void Start () {
		length = Screen.width / 3;
		height = Screen.height / 8;
		gl = GameObject.FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
		score=PlayerPrefs.GetInt ("Player Score");
		gui = false;
	}

	void OnTriggerEnter2D(Collider2D myTrigger) 
	{
		if (myTrigger.gameObject.name == "Bird")
		{

			gl.timePlayer2=Time.time;
			gl.scorePlayer=(60-(gl.timePlayer2-gl.timePlayer1))*10+gl.curHealth*20;

			if (gl.scorePlayer>score)
			{

				PlayerPrefs.SetInt("Player Score",(int)gl.scorePlayer);
				add=" - New best!";
			}
			else
				add="";

			gui=true;
			gl.controlPlayer=false;

		}
		
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width - 25, Screen.height - 25, 25, 25), "||")) 
		{
			gl.menu = true;
			Time.timeScale = 0;
		}
		
		if (gl.menu) 
		{	if (gl.controlPlayer)

				if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.4f, length, height), "Resume"))
				{
					gl.menu=false;
					Time.timeScale = 1;
				}
				else 
				Debug.Log ("Bullshit");
			else
					if(gui)
				{
					GUI.Label (new Rect ((Screen.width - length) / 2, Screen.height * 0.3f, length, height), "Your score");
					GUI.Label (new Rect ((Screen.width - length) / 2, Screen.height * 0.4f, length, height),gl.scorePlayer + add);
				}
					else
					GUI.Label (new Rect ((Screen.width - length) / 2, Screen.height * 0.4f, length, height), "Game over");
			
			if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.6f, length, height), "Try again"))
			{
				Application.LoadLevel ("Level1");
				Time.timeScale = 1;
			}
			
			if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.8f, length, height), "Main menu"))
				Application.LoadLevel ("Menu");
		}

	}

	

}
