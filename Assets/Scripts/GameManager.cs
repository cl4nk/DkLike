using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public int curScore; 
	// The highest score the player has reached (saved)
	private int highscore;
	
	[HideInInspector]
	public bool showGameOver = false;
	private bool isPaused = false;
	
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
		GUI.skin = skin;
		//GUI.Label (new Rect (Screen.width / 2 - 100, 10f, 200, 200), curScore.ToString (),skin.GetStyle("Score"));
		
		if (showGameOver) {
			//define the screen space for the game over window
			Rect currentGameOver = new Rect (Screen.width / 2 - (losePromptWH.x/2), Screen.height / 2 - (losePromptWH.y/2), losePromptWH.x, losePromptWH.y);
			// Generate a box based on the game over window rectangle
//			GUI.Box (currentGameOver, "Game Over", skin.GetStyle ("Game Over"));

			//Draw our current score within the game over window
			GUI.Label (new Rect (currentGameOver.x + 15f, currentGameOver.y + 50f, currentGameOver.width * 0.5f, currentGameOver.height * 0.25f),"Score : " + curScore.ToString());
		
			//Draw our highscore within the game over window
			GUI.Label (new Rect (currentGameOver.x + 15f, currentGameOver.y + 70f, currentGameOver.width * 0.5f, currentGameOver.height * 0.25f),"Highscore : " + highscore.ToString());
		
			//Draw a replay button and check if it was clicked
			if (GUI.Button (new Rect(currentGameOver.x +(currentGameOver.width - 150), currentGameOver.y +(currentGameOver.height -150),currentGameOver.x - 100,currentGameOver.y - 100),"Rejouer"))
			{
				Application.LoadLevel ("Level");
				//	Load the highscore from our save file
				highscore = PlayerPrefs.GetInt ("Highscore");
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
