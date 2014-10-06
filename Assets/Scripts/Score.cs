using UnityEngine;
//using System.Collections;

public class Score : MonoBehaviour 
{
	public GUIText scoreGUIText;
	private int score;

	void Start () 
	{
		Initialise ();
	}

	void Update () 
	{
		scoreGUIText.text = score.ToString ();
		AddScore ("gameobjectofplayer.position.y");
	}
	private void Initialise ()
	{
		score = 0;
	}
	public void AddScore (int y)
	{
		score = y;
	}

}
