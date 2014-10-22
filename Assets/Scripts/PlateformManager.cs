using UnityEngine;
using System.Collections.Generic;

public class PlateformManager : MonoBehaviour
{

		private Vector3 startPosition ;
		public float gap = 1f;
		private Vector3 nextPosition ;

		public GameObject[] bigObjects;
			public float bigMargin = 25f;

		public GameObject[] smallObjects;
			public float smallMargin = 6.2f;

	    public GameObject[] verySmallObjects;
			public float verySmallMargin = 2.2f;

		public GameObject[] mediumsObjects;
			public float mediumMargin = 12f;

		public GameObject loopingObject;
			public float loopingMargin = 15f;	

		private List<GameObject> currentObjects = new List<GameObject> ();

		void Start ()
		{

				/*Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, Camera.main.nearClipPlane));
		startPosition.x = p.x / 2;*/

				GameObject firstPlateforme = GameObject.Find ("first_plateforme_game");
				if (firstPlateforme != null) {
						startPosition.y = firstPlateforme.transform.position.y - (getHeight (firstPlateforme) / 2f);
						startPosition.x = firstPlateforme.transform.position.x;
				}
		
				nextPosition = startPosition;
				bool lastObjectIsVisble = true;
				while (lastObjectIsVisble) {
						lastObjectIsVisble = CreateObstacle ();
				}

				Debug.Log ("Sorti de la boucle");
		}
	
		void Update ()
		{
				if (currentObjects.Count > 0) {
						if (objectIsVisible (currentObjects [currentObjects.Count - 1]))
								CreateObstacle ();
				
						if (!objectIsVisible (currentObjects [0])) 
								DestroyHighestObstacle ();
				}
		}

		private void DestroyHighestObstacle ()
		{
				if (currentObjects.Count > 0) {
						GameObject last = currentObjects [0];
						Destroy (last);
						currentObjects.RemoveAt (0);
				}
		}

		private bool CreateObstacle ()
		{
				int sizeChoice = Random.Range (0, 10);
				int looping_choice = Random.Range (0, 2);


				if (sizeChoice == 6 && looping_choice == 1)
					return CreateLoopingObstacle ();
				
				if (sizeChoice > 5)
						return CreateVerySmallObstacle ();
				else if (sizeChoice > 3)
						return CreateSmallObstacle ();
				else if (sizeChoice == 0)
						return CreateBigObstacle ();
				else 
						return CreateMediumObstacle ();
				
				
		}

	private bool CreateBigObstacle ()
	{
		int enemyIndex = Random.Range (0, bigObjects.Length);
		
		if (bigObjects [enemyIndex] != null) {
			
			GameObject newObstacle = bigObjects [enemyIndex];

			nextPosition.y -= bigMargin / 2;

			Vector3 currentPos = newObstacle.transform.position;
			currentPos.y = nextPosition.y;
			newObstacle.transform.position = currentPos;
			
			currentObjects.Add ((GameObject)Instantiate (newObstacle));
			
			nextPosition.y -= gap + (bigMargin / 2f);
			

			return objectIsVisible (currentObjects [currentObjects.Count - 1]);
		}
		if (bigObjects [enemyIndex] == null) 
			Debug.Log ("Mauvais index");
		
		Debug.Log ("Pas rentré dans le if");
		return false;
	}

	private bool CreateSmallObstacle ()
	{
		int enemyIndex = Random.Range (0, smallObjects.Length);
		
		if (smallObjects [enemyIndex] != null) {
			
			GameObject newObstacle = smallObjects [enemyIndex];
			
			nextPosition.y -= smallMargin / 2;
			
			Vector3 currentPos = newObstacle.transform.position;
			currentPos.y = nextPosition.y;
			newObstacle.transform.position = currentPos;
			
			currentObjects.Add ((GameObject)Instantiate (newObstacle));
			
			nextPosition.y -= gap + (smallMargin / 2f);

			return objectIsVisible (currentObjects [currentObjects.Count - 1]);
		}
		if (smallObjects [enemyIndex] == null) 
			Debug.Log ("Mauvais index");
		
		Debug.Log ("Pas rentré dans le if");
		return false;
	}

	private bool CreateVerySmallObstacle ()
	{
		int enemyIndex = Random.Range (0, verySmallObjects.Length);
		
		if (verySmallObjects [enemyIndex] != null) {
			
			GameObject newObstacle = verySmallObjects [enemyIndex];
			
			nextPosition.y -= verySmallMargin / 2;
			
			Vector3 currentPos = newObstacle.transform.position;
			currentPos.y = nextPosition.y;
			newObstacle.transform.position = currentPos;
			
			currentObjects.Add ((GameObject)Instantiate (newObstacle));
			
			nextPosition.y -= gap + (verySmallMargin / 2f);
			
			return objectIsVisible (currentObjects [currentObjects.Count - 1]);
		}
		if (verySmallObjects [enemyIndex] == null) 
			Debug.Log ("Mauvais index");
		
		Debug.Log ("Pas rentré dans le if");
		return false;
	}

	private bool CreateMediumObstacle ()
	{
		int enemyIndex = Random.Range (0, mediumsObjects.Length);
		
		if (mediumsObjects [enemyIndex] != null) {
			
			GameObject newObstacle = mediumsObjects [enemyIndex];
			
			nextPosition.y -= mediumMargin / 2;
			
			Vector3 currentPos = newObstacle.transform.position;
			currentPos.y = nextPosition.y;
			newObstacle.transform.position = currentPos;
			
			currentObjects.Add ((GameObject)Instantiate (newObstacle));
			
			nextPosition.y -= gap + (mediumMargin / 2f);

			return objectIsVisible (currentObjects [currentObjects.Count - 1]);
		}
		if (mediumsObjects [enemyIndex] == null) 
			Debug.Log ("Mauvais index");
		
		Debug.Log ("Pas rentré dans le if");
		return false;
	}

	private bool CreateLoopingObstacle ()
	{
		//int enemyIndex = loopingObject;
		
		if (loopingObject != null) {
			
			GameObject newObstacle = loopingObject;
			
			nextPosition.y -= loopingMargin / 2;
			
			Vector3 currentPos = newObstacle.transform.position;
			currentPos.y = nextPosition.y;
			newObstacle.transform.position = currentPos;
			
			currentObjects.Add ((GameObject)Instantiate (newObstacle));
			
			nextPosition.y -= gap + (loopingMargin / 2f);
			
			return objectIsVisible (loopingObject);
		}
		if (loopingObject == null) 
			Debug.Log ("Mauvais index");
		
		Debug.Log ("Pas rentré dans le if");
		return false;
	}
	
		private float getHeight (GameObject parent)
		{
				float top = -9999f, bottom = 9999f, height;
				Transform transTop = null, transBottom = null;
		
				foreach (Transform child in parent.transform) {
						if (child.position.y > top) {
								top = child.position.y;
								transTop = child;
						}
						if (child.position.y < bottom) {
								bottom = child.position.y;
								transBottom = child;
						}
				}

				top = top + (transTop.gameObject.renderer.bounds.size.y / 2f);
				bottom = bottom - (transBottom.gameObject.renderer.bounds.size.y / 2f); 

				return Mathf.Abs(top - bottom);

		}

		private Bounds getBounds (GameObject parent)
		{
				// First find a center for your bounds.
				Vector3 center = Vector3.zero;
		
				foreach (Transform child in parent.transform) {
						center += child.gameObject.renderer.bounds.center;   
				}
				center /= parent.transform.childCount; //center is average center of children
		
				//Now you have a center, calculate the bounds by creating a zero sized 'Bounds', 
				Bounds bounds = new Bounds (center, Vector3.zero); 
		
				foreach (Transform child in parent.transform) {
						bounds.Encapsulate (child.gameObject.renderer.bounds);   
				}
				return bounds;
		
		}

		private bool objectIsVisible (GameObject obj)
		{
				Plane[] planes = GeometryUtility.CalculateFrustumPlanes (Camera.main);
				if (GeometryUtility.TestPlanesAABB (planes, getBounds (obj)))
						return true;
				else
						return false;
		}

}