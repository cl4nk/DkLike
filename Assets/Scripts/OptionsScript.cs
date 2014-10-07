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

		hSliderValue = GUI.HorizontalSlider (new Rect (325, 200, 100, 10), hSliderValue, 0.0f, 10.0f);

		if(GUI.Button(buttonRect,"back"))
		{
			Application.LoadLevel("Menudujeux");
		}

	}
}