using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public int curScore; 
	// The highest score the player has reached (saved)
	private int highscore;
	
	[HideInInspector]
	public bool showGameOver;
	private static float lockedX = 0.0f;
	private bool isPaused = false;

	public GUIText scoreGUIText;
	public Player player;

	// Use this for initialization
	void Start () {
		curScore = 0;
		highscore = PlayerPrefs.GetInt("Highscore");
	}
	
	// Update is called once per frame
	void Update () {

		if(isPaused)
			Time.timeScale = 0f; // Le temps s'arrete
		
		else
			Time.timeScale = 1.0f; // Le temps reprend
		AddScore ((int) player.transform.position.y);
		scoreGUIText.text = curScore.ToString();

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

	void LateUpdate() {
		Vector3 mPosition = Camera.main.transform.position;
		mPosition.x = lockedX;
		Camera.main.transform.position = mPosition;
	}

	void OnGUI ()
	{
		if(isPaused)
		{
			
			// Si le bouton est présser alors isPaused devient faux donc le jeu reprend.
			if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continuer"))
			{
				isPaused = false;
			}
			
			// Si le bouton est présser alors on ferme completement le jeu ou charge la scene "Menu Principal
			// Dans le cas du bouton quitter il faut augmenter sa postion Y pour qu'il soit plus bas
			if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Quitter"))
			{
				// Application.Quit(); 
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
