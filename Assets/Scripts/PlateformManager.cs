using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public Vector2 startPosition;

	private Vector2 nextPosition;
	private GameObject[] objects;
	private GameObject[] currentObjects;
	private int lowestCurrentObject = 0, highestCurrentObject = 0, nbrCurrentObjects = 0;

	void Start () {
		bool lastObjectIsVisble = true;
		while (lastObjectIsVisble) {
			lastObjectIsVisble = CreateObstacle();
				}
	}
	
	void Update () {
		if(currentObjects[lowestCurrentObject].renderer.isVisible){
			CreateObstacle();
		}
		if(!currentObjects[highestCurrentObject].renderer.isVisible){
			DestroyHighestObstacle();

		}
	}

	private void DestroyHighestObstacle () {
				if (currentObjects [highestCurrentObject] != null) {
					Destroy(currentObjects [highestCurrentObject]);
					nbrCurrentObjects --;
					highestCurrentObject = (highestCurrentObject + 1) % currentObjects.Length;

				}
		}
	private bool CreateObstacle () {

		int enemyIndex = Random.Range(0, objects.Length);
		int newIndex = (lowestCurrentObject + 1) % currentObjects.Length;

		if (objects [enemyIndex] != null && currentObjects[newIndex] == null) {

			GameObject newObstacle = objects [enemyIndex];
			currentObjects[newIndex] = (GameObject) Instantiate(newObstacle, nextPosition, transform.rotation);

			nextPosition.y += newObstacle.renderer.bounds.size.y;
			nbrCurrentObjects ++;
			lowestCurrentObject = newIndex;

			return currentObjects[newIndex].renderer.isVisible;
		}

		return false;
	}
}