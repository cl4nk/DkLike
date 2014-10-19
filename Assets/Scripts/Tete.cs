using UnityEngine;
using System.Collections;

public class Tete : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//ligne qui le fait exploser
		Explosion_tete.Instance.Explosion(transform.position);

		player.isDead = true;
	}
}
