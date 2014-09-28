using UnityEngine;
using System.Collections;

/// Title screen script

public class MenuScript : MonoBehaviour
{
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


		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start"))
		{
			Application.LoadLevel("Stage1");
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
	}
}