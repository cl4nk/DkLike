using UnityEngine;
using System.Collections;

public class Roues : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.relativeVelocity.magnitude > 3) {

			//ligne qui le fait exploser
			SpecialEffectsHelper.Instance.Explosionplayer(this.gameObject.transform.position);
			player.isDead = true;
			Destroy (this);
		}
	}
}
