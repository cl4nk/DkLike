using UnityEngine;
using System.Collections;

public class BoutonOption : MonoBehaviour {

	public Texture2D texture = null;

	//il faut un Box (circle si c'est un cercle) collider 
	void OnMouseDown() 
	{
		Application.LoadLevel("Options");
	}
}
