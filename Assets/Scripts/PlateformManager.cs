using UnityEngine;
using System.Collections.Generic;

public class PlateformManager : MonoBehaviour
{

		private Vector3 startPosition ;
		public float gap = 1f;
		private Vector3 nextPosition ;
		public GameObject[] objects;
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

				int enemyIndex = Random.Range (0, objects.Length);
				//int reverted = Random.Range(0,2);

				if (objects [enemyIndex] != null) {

						GameObject newObstacle = objects [enemyIndex];

						//Unity bug de ce coté.. impossible d'inverser le prefab
						/*if  (reverted == 1) {
				 		Vector3 newScale = newObstacle.transform.localScale;
				 		newScale.x *= -1;
				 		newObstacle.transform.localScale = newScale;
						} */
						
						nextPosition.y -= getHeight (newObstacle) / 2f;
						
						newObstacle.transform.position = nextPosition;
						
						currentObjects.Add ((GameObject)Instantiate (newObstacle));

						nextPosition.y -= getHeight (newObstacle) / 2f ;


						Debug.Log ("Creation obj numéro "+ enemyIndex.ToString());
						return objectIsVisible (currentObjects [currentObjects.Count - 1]);
				}
				if (objects [enemyIndex] == null) 
						Debug.Log ("Mauvais index");

				Debug.Log ("Pas rentré dans le if");
				return false;
		}

		private float getHeight (GameObject parent)
		{
				return getBounds (parent).size.y;
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