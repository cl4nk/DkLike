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

	// Use this for initialization
	void Start () {
		highscore = PlayerPrefs.GetInt("Highscore");
	}
	
	// Update is called once per frame
	void Update () {
		// If the bird died and our current score is greater than our saved highscore
		if (showGameOver && curScore > highscore)
		{
			// Set the highscore to our current score
			highscore = curScore;
			// Now save the score as our new highscore
			PlayerPrefs.SetInt("Highscore", highscore);
		}
	}

	void LateUpdate() {
		Vector3 mPosition = Camera.main.transform.position;
		mPosition.x = lockedX;
		Camera.main.transform.position = mPosition;
	}
}
