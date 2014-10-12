using UnityEngine;
using System.Collections;

public class BoutonExtras : MonoBehaviour {

	public Texture2D texture = null;
	
	void OnMouseDown() 
	{
		Application.LoadLevel("Extras");
	}
}
