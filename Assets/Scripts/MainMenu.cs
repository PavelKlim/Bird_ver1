using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	
	public Texture2D headBird;

	private float length;
	private float height;
	private bool mainMenu;
	private string score;

	// Use this for initialization
	void Start () {
		length = Screen.width / 3;
		height = Screen.height / 8;
		mainMenu = true;
		score =PlayerPrefs.GetInt ("Player Score").ToString();
		if (score == "0")
				score = "Finish the level, firstly!";
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect((Screen.width - length*0.5f) / 2, Screen.height*0.1f, length*0.5f, length*0.5f ), headBird);
		if (mainMenu)
		{
		if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.4f, length, height), "Start"))
			Application.LoadLevel ("Level1");
		else
			if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.6f, length, height), "Highscrore"))
			{
				mainMenu=false;
			}
			else
				if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.8f, length, height), "Exit"))
					Application.Quit ();
		}

		if (!mainMenu) 
		{
			GUI.Label (new Rect ((Screen.width - length/1.5f) / 2, Screen.height * 0.4f, length, height), "Highscrore :");
			GUI.Label (new Rect ((Screen.width - length/1.5f) / 2, Screen.height * 0.6f, length, height), score);

			if (GUI.Button (new Rect ((Screen.width - length) / 2, Screen.height * 0.8f, length, height), "Back"))
				mainMenu=true;
		}
	}
	

}
