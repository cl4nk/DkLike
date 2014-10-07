using UnityEngine;
using System.Collections.Generic;

public class PlateformManager : MonoBehaviour {

	public Vector3 startPosition;

	private Vector3 nextPosition;
	public GameObject[] objects;
	private GameObject[] currentObjects;
	private int lowestCurrentObject = 0, highestCurrentObject = 0; 
	private int nbrCurrentObjects = 0;

	void Start () {

		currentObjects = new GameObject[10];

		//Time.timeScale = 0f;
		bool lastObjectIsVisble = true;
		
		//TODO recuperer position premier obstacle
		GameObject firstPlateforme = GameObject.Find ("first_plateforme");
		if (firstPlateforme != null)
			startPosition.y = firstPlateforme.transform.position.y - (int) getHeight(firstPlateforme); 
		
		nextPosition = startPosition;
		while (lastObjectIsVisble && nbrCurrentObjects < 10) {
			//lastObjectIsVisble = 
				CreateObstacle();
				}
		Time.timeScale = 1.0f;

		Debug.Log("Sorti de la boucle");
	}
	
	void Update () {
		if (nbrCurrentObjects > 0) {
			if (objectIsVisible(currentObjects [lowestCurrentObject])) {
								CreateObstacle ();
						}
			if (!objectIsVisible(currentObjects [highestCurrentObject])) {
								DestroyHighestObstacle ();

						}
				}
	}

	private void DestroyHighestObstacle () {
		if (currentObjects [highestCurrentObject] != null && nbrCurrentObjects > 0 ) {
					Destroy(currentObjects [highestCurrentObject]);
					nbrCurrentObjects --;
					highestCurrentObject = (highestCurrentObject + 1) % nbrCurrentObjects;

				}
	}

	private bool CreateObstacle () {

		int enemyIndex = Random.Range(0, objects.Length);
		int reverted = Random.Range(0,2);
		int newIndex = (nbrCurrentObjects !=0) ? (lowestCurrentObject + 1) % nbrCurrentObjects : (lowestCurrentObject + 1) ;

		if (objects [enemyIndex] != null && currentObjects[newIndex] == null) {

			GameObject newObstacle = objects [enemyIndex];
			if  (reverted == 1) {
				 Vector3 newScale = newObstacle.transform.localScale;
				 newScale.x *= -1;
				 newObstacle.transform.localScale = newScale;
			} 
			currentObjects[newIndex] = (GameObject) Instantiate(newObstacle, nextPosition, transform.rotation);

			nextPosition.y -= (int) getHeight(newObstacle);
			nbrCurrentObjects ++;
			lowestCurrentObject = newIndex;

			Debug.Log("Creation obj");
			return objectIsVisible(currentObjects[newIndex]);
		}

		return false;
	}

	private float getHeight (GameObject parent) {
		Bounds bounds = getBounds (parent);
		return bounds.size.y;
}

	private Bounds getBounds (GameObject parent) {
		// First find a center for your bounds.
		Vector3 center = Vector3.zero;
		
		foreach (Transform child in parent.transform)
		{
			center += child.gameObject.renderer.bounds.center;   
		}
		center /= parent.transform.childCount; //center is average center of children
		
		//Now you have a center, calculate the bounds by creating a zero sized 'Bounds', 
		Bounds bounds = new Bounds(center,Vector3.zero); 
		
		foreach (Transform child in parent.transform)
		{
			bounds.Encapsulate(child.gameObject.renderer.bounds);   
		}
		return bounds;

	}
	private bool objectIsVisible (GameObject obj) {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if (GeometryUtility.TestPlanesAABB (planes, getBounds (obj)))
						return true;
				else
						return false;
		}

}