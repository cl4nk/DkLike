using UnityEngine;
using System.Collections;

public class GooglePlusLien : MonoBehaviour {

	public Texture2D texture = null;
	
	void OnMouseDown() 
	{
	//	cause une erreur s'il n'y a pas d'url 
	//	Application.OpenURL(string url);
		Application.LoadLevel("GooglePlus");
	}
}
