using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public int curScore; 
	// The highest score the player has reached (saved)
	private int highscore;
	
	[HideInInspector]
	public bool showGameOver = false;
	
	public GUIText scoreGUIText;
	public GUISkin skin;
	public Texture image;
	public Vector2 losePromptWH;

	private Gyroscope gyo1;
	private bool gyoBool;

	// Use this for initialization
	void Start () {
		curScore = 0;
		highscore = PlayerPrefs.GetInt("Highscore");
	//	skin = Resources.Load("GUISkin") as GUISkin;
		/*gyoBool = SystemInfo.supportsGyroscope;
		
		if( gyoBool ) {
			gyo1=Input.gyro;
			gyo1.enabled = true;
		}
		Physics.gravity = gyo1.gravity;
		Screen.orientation = ScreenOrientation.Portrait;*/
	}
	
	// Update is called once per frame
	void Update () 
	{


		//Physics.gravity = gyo1.gravity;


		/*
		if(isPaused)
			Time.timeScale = 0f; // Le temps s'arrete	
		
		else
			Time.timeScale = 1.0f; // Le temps reprend*/

		//AddScore ((int) player.transform.position.y);
		//scoreGUIText.text = curScore.ToString();

		// If the bird died and our current score is greater than our saved highscore
		if (showGameOver && curScore > highscore)
		{
		//	transform.parent.gameObject.AddComponent<GameOverScript>();
		 // Set the highscore to our current score
			highscore = curScore;
	     // Now save the score as our new highscore
			PlayerPrefs.SetInt ("Highscore", highscore);

		}
	}


	void OnGUI ()
	{	
		//Faire le skin avant de décommenter cette ligne
	//	GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 100, 60),curScore.ToString(),skin.GetStyle("Score"));
		
		if (showGameOver) {
			//define the screen space for the game over window
			Rect currentGameOver = new Rect (Screen.width / 2 - (losePromptWH.x/2), Screen.height / 2 - (losePromptWH.y/2), losePromptWH.x, losePromptWH.y);
			// Generate a box based on the game over window rectangle
			//GUI.Box (currentGameOver, "Game Over", skin.GetStyle ("Game Over"));
			GUI.Box(new Rect(70 ,200,300,200), "Game Over");


			//Draw our current score within the game over window
			GUI.Label (new Rect (Screen.width / 2 - 90, Screen.height / 2 - 50, currentGameOver.x, currentGameOver.y),"Score : " + curScore.ToString());
		
			//Draw our highscore within the game over window
			GUI.Label (new Rect (Screen.width / 2 + 60, Screen.height / 2 - 50, currentGameOver.x, currentGameOver.y),"Highscore : " + highscore.ToString());
		
			//Draw a replay button and check if it was clicked
			if (GUI.Button (new Rect(currentGameOver.x +(currentGameOver.width - 25), currentGameOver.y +(currentGameOver.height - 100),currentGameOver.x -105, currentGameOver.y - 300),"Rejouer"))
			{
				Application.LoadLevel ("Level");
				//	Load the highscore from our save file
				highscore = PlayerPrefs.GetInt ("Highscore");
			}
			if(GUI.Button (new Rect(currentGameOver.x +(currentGameOver.width - 25), currentGameOver.y +(currentGameOver.height - 25),currentGameOver.x - 105, currentGameOver.y - 300),"Menu"))
			{
				Application.LoadLevel("menudujeu");
			}

		}
	}

	public void AddScore (int y)
	{
		y  = y > 0 ? y : -y;
		if ( y > curScore)
			curScore = y;
	}

}
