using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GameObject player;
	private float distance;

	private float lockedX ;
	private float maxY;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("bouton_haut");
		if (player == null)
						Debug.Log ("pas de player");
		float yPlayer = player.transform.position.y;
		float yCamera = transform.position.y;
		distance =  yCamera - yPlayer;
		lockedX = transform.position.x;
		maxY = Mathf.Abs(transform.position.y);


	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mPosition = transform.position;
		mPosition.x = lockedX;
		//if (Mathf.Abs(transform.position.y) > maxY)
			mPosition.y = distance + player.gameObject.transform.position.y;
		transform.position = mPosition;

	}

}