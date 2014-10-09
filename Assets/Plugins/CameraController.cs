using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private float distance;

	private float minDistance;
	private float maxDistance;
	public float rangeDistance = 1f;
	public float tempDistance = 0.1f;
	// Use this for initialization
	void Start () {
		distance =  Mathf.Abs(player.transform.position.y - transform.position.y);


	}
	
	// Update is called once per frame
	void Update () {
			transform.position = new Vector3 (transform.position.x, player.transform.position.y - distance,  transform.position.z);
	}

	bool isBetween (float a, float min, float max) {
		return (Mathf.Abs(a) > min && Mathf.Abs(a) < max);
		}
}