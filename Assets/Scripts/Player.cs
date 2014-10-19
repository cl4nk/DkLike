using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[HideInInspector]
	public bool isDead = false;
	public GameManager manager;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			Die ();
		} else {
		
		}
	
	}
	
	void Die()
	{
		isDead = true;
		//Stop the movement of the map
		manager.showGameOver = true;

	}
}
