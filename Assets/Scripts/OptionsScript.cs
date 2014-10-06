using UnityEngine;
using System.Collections;

/// Title screen script

public class OptionsScript : MonoBehaviour{
	private float hSliderValue = 0.0f;
	void OnGUI(){
		const int buttonWidth = 70;
		const int buttonHeight = 40;




		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 2) - (14 * buttonHeight / 3),
			buttonWidth,
			buttonHeight
			);
		
		Rect button2Rect = new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 2) - (10 * buttonHeight / 3),
			buttonWidth,
			buttonHeight
			);
		
		Rect button3Rect = new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 2) - (6 * buttonHeight / 3),
			buttonWidth,
			buttonHeight
			);

		hSliderValue = GUI.HorizontalSlider (new Rect (25, 25, 100, 30), hSliderValue, 0.0f, 10.0f);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"back"))
		{
			Application.LoadLevel("Menudujeux");
		}

		if (GUI.Button (button2Rect, "Facebook")) 
		{
			/* cause une erreur s'il n'y a pas d'url 
			 * 
			 * Application.OpenURL(string url);
			 * 
			 * facebook est un niveau tant qu'il n'y a pas de lvl pour voir sa place sur l'écran
			 */
			//Application.LoadLevel("Facebook");
		}
		if (GUI.Button(button3Rect, "Google Plus"))
		{
			//Application.LoadLevel("Google +");
		}
	}
}