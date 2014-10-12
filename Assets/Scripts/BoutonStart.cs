using UnityEngine;
using System.Collections;

public class BoutonStart : MonoBehaviour {

	public Texture2D texture = null;
	
	void OnMouseDown() 
	{
		Application.LoadLevel("Level");
	}
}
