using UnityEngine;
using System.Collections;

public class PlateformManager : MonoBehaviour {

	public int numberOfObjects;
	public float recycleOffset;
	public Vector2 startPosition;
	public float minY, maxY;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;

	// Use this for initialization
	void Start () {
		nextPosition = startPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
