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
		if (showGameOver) {
			transform.parent.gameObject.AddComponent<GameOverScript>();
						if (curScore > highscore) {
								// Set the highscore to our current score
								highscore = curScore;
								// Now save the score as our new highscore
								PlayerPrefs.SetInt ("Highscore", highscore);
						}
				}
	}


	void OnGUI ()
	{	
		//Faire le skin avant de décommenter cette ligne
		//GUI.skin = skin;

		//GUI.Label (new Rect (Screen.width / 2 - 100, 10f, 200, 200), curScore.ToString ());
		//Rect currentGameOver = 
		/*
		 *GUI.Box(currentGameOver, "Game Over", skin.GetStyle("Game Over"));
		 *
		 *Draw our current score within the game over window
		 *GUI.Label(new Rect(currentGameOver.x + 15f, currentGameOver.y + 50f,
		 *
		 *Draw our highscore within the game over window
		 *GUI.Label(new Rect(currentGameOver.x + 15f, currentGameOver.y + 70f,
		 *
		 *Draw a replay button and check if it was clicked
		 *if(GUI.Button(new Rect(currentGameOver.x + (currentGameOver.width - 150)
		 *{
		 *	Application.LoadLevel("Level");
		 *	Load the highscore from our save file
		 *	highscore = PlayerPrefs.GetInt("Highscore");
		 *}
		*/
	}

	public void AddScore (int y)
	{
		y  = y > 0 ? y : -y;
		if ( y > curScore)
			curScore = y;
	}

}
