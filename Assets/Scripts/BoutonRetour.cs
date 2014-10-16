using UnityEngine;
using System.Collections;

public class BoutonRetour : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 2) - (19 * buttonHeight / 3),
			buttonWidth - 5,
			buttonHeight -5
			);

		if(GUI.Button(buttonRect,"Retour"))
		{
			Application.LoadLevel("menudujeu");
		}
	}
}
