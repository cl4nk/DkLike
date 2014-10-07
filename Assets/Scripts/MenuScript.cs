using UnityEngine;
using System.Collections;

/// Title screen script

public class MenuScript : MonoBehaviour
{
	private bool toggleBool =  true;
	private bool toggleBool2 = true;

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
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

		Rect button4Rect = new Rect (
			 Screen.width / 2 - (4 * buttonWidth / 2),
			(2 * Screen.height / 2) - (6 * buttonHeight / 3),
			buttonWidth,
			buttonHeight
			);

		Rect button5Rect = new Rect (
			Screen.width / 2 - (7 * buttonWidth / 2),
			(2 * Screen.height / 2) - (6 * buttonHeight / 3),
			buttonWidth,
			buttonHeight
			);

		Rect button6Rect = new Rect (
			Screen.width / 2 - (10 * buttonWidth / 2),
			(2 * Screen.height / 2) - (6 * buttonHeight / 3),
			buttonWidth,
			buttonHeight
			);

		//Toogle du bouton son
		toggleBool = GUI.Toggle (new Rect (700, 25, 100, 30), toggleBool, "Son");
		toggleBool2 = GUI.Toggle (new Rect (760, 25, 100, 30), toggleBool2, "Musique");

		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start"))
		{
			Application.LoadLevel("Level");
		}
		if(GUI.Button(button2Rect,"Options"))
		{
			Application.LoadLevel("Options");
		}
		if (GUI.Button (button3Rect, "Extras")) 
		{
			Application.LoadLevel ("Extras");
		}

		if (GUI.Button (button4Rect, "Facebook")) 
		{
			/* cause une erreur s'il n'y a pas d'url 
			 * 
			 * Application.OpenURL(string url);
			 * 
			 * facebook est un niveau tant qu'il n'y a pas de lvl pour voir sa place sur l'écran
			 */
			Application.LoadLevel("Facebook");
		}
		if (GUI.Button(button5Rect, "Google Plus"))
		{
			// voir explication facebook Application.OpenURL(string url);
			Application.LoadLevel("Google +");
		}
		if(GUI.Button(button6Rect,"Twitter"))
		{
			Application.LoadLevel("Twitter");
		}
	}
}