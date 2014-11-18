using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MenuPause : MonoBehaviour {

	private bool isPaused = false; 
	public Texture2D texture = null;

	// Attache ce script à l'objet
	void OnMouseDown()
	{
		isPaused = !isPaused;
	}
	void Update () 
	{

		if(isPaused)
			Time.timeScale = 0f; // Le temps s'arrete
		
		else
			Time.timeScale = 1.0f; // Le temps reprend


	}

	void OnGUI ()
	{
		Rect boxrect = new Rect (Screen.width / 2 - 125, Screen.height / 2 - 100, Screen.width /2 + 60, Screen.height/3);

		if(isPaused)
		{

			GUI.Box(boxrect,"Pause ");
			// Si le bouton est préssé alors isPaused devient faux donc le jeu reprend.
			if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continuer"))
			{
				isPaused = false;
			}

			// Si le bouton est préssé alors on ferme completement le jeu ou charge la scene "Menu Principal
			// Dans le cas du bouton quitter il faut augmenter sa postion Y pour qu'il soit plus bas
			if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "menu"))
			{
				Application.LoadLevel("menudujeu"); 

			}

		}
	}

}
