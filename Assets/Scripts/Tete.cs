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
		SpecialEffectsHelper.Instance.Explosionplayer(transform.position);

		player.isDead = true;
	}
}
