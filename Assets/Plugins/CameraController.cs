using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GameObject player;
	private float distance;

	private int i = 0;

	private float lockedX ;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("roue_droite");
		if (player == null)
						Debug.Log ("pas de player");
		float yPlayer = player.transform.position.y;
		float yCamera = transform.position.y;
		distance =  yCamera - yPlayer;
		lockedX = transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mPosition = transform.position;
		mPosition.x = lockedX;
		mPosition.y = distance + player.gameObject.transform.position.y;
		transform.position = mPosition;

		Debug.Log ("Player pos y :  " + player.gameObject.transform.position.y.ToString () +"    " + i.ToString());
		i++;
	}

}