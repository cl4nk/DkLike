using UnityEngine;
using System.Collections;

public class TwitterScript : MonoBehaviour {

	public Texture2D texture = null;
	
	void OnMouseDown() 
	{
		//	cause une erreur s'il n'y a pas d'url 
		//	Application.OpenURL(string url);
		Application.LoadLevel("Twitter");
	}
}
