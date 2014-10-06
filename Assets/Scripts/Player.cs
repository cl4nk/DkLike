using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool isDead = false;
	private GameManager manager;


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
		manager.showGameOver = true;

	}
}
