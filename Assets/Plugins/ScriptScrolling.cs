using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 
/// <summary>
/// Parallax scrolling script that should be assigned to a layer
///
/// This is related to the tutorial http://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/
///
/// See the result: http://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/-img/multidir_scrolling.gif
/// </summary>
public class ScriptScrolling : MonoBehaviour
{
		private List<GameObject> backgroundList = new List<GameObject> ();
		private GameObject background;
		private float lockedX;
		private float sizeY;
		private Vector3 nextPosition;
 
		void Start ()
		{
				background = GameObject.FindGameObjectWithTag ("Background");
				// Only visible children
				if (background.renderer != null) {

						backgroundList.Add (background);
						sizeY = background.renderer.bounds.size.y;
						nextPosition = background.transform.position;
						lockedX = nextPosition.x;
						AddBackground ();

				}
		}

		void Update ()
		{

				if (backgroundList.Count > 0) {
						if (!backgroundIsVisible (backgroundList [0])) {
								AddBackground ();
								DestroyBackground ();
						}
				}
		}
 
		private bool backgroundIsVisible (GameObject obj)
		{
				Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
				if (obj.transform.position.y - (sizeY / 2) < p.y)
						return true;
				return false;
		}

		void DestroyBackground ()
		{

				if (backgroundList.Count > 0) {
						GameObject last = backgroundList [0];
						Destroy (last);
						backgroundList.RemoveAt (0);
			Debug.Log ("destruction de background");
				}
		}

		bool AddBackground ()
		{
		Debug.Log ("ajout de background");
				
				backgroundList.Add ((GameObject)Instantiate (background));
				GameObject tmpBackground = backgroundList[backgroundList.Count - 1];
				nextPosition.y -= sizeY ;
				tmpBackground.transform.position = nextPosition;
				return backgroundIsVisible (tmpBackground);
		}

}