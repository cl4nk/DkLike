using UnityEngine;
using System.Collections;

public class FacebookScript : MonoBehaviour {

	public Texture2D texture = null;
	
	void OnMouseDown() 
	{
		//	Application.OpenURL(string url);
		Application.LoadLevel("Facebook");
	}
}
