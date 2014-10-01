using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector2 startPosition;
	public Vector2 minSize, maxSize, minGap, maxGap;
	public float minY, maxY;
	
	private Vector2 nextPosition;
	private Queue<Transform> objectQueue;
	
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		for(int i = 0; i < numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = startPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
	}
	
	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < Player.distanceTraveled){
			Recycle();
		}
	}
	
	private void Recycle () {

		Vector2 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
		
		Transform o = objectQueue.Dequeue();
		o.localPosition = position;
		objectQueue.Enqueue(o);
		
		nextPosition += new Vector2(
			Random.Range(minGap.x, maxGap.x) + scale.x,
			Random.Range(minGap.y, maxGap.y));
		
		if(nextPosition.y < minY){
			nextPosition.y = minY + maxGap.y;
		}
		else if(nextPosition.y > maxY){
			nextPosition.y = maxY - maxGap.y;
		}
	}
}