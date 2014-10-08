using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {
	
	public GameObject cameraTarget; // object to look at or follow

	
	public float smoothTime = 0.1f;    // time for dampen
	public bool cameraFollowY = true; // camera follows on vertical
	public bool cameraFollowHeight = true; // camera follow CameraTarget object height
	public float cameraHeight = 2.5f; // height of camera adjustable
	Vector2 velocity; // speed of camera movement
	
	private Transform thisTransform; // camera Transform
	
	// Charleh - added these tweakable values - change as neccessary
	private float threshold ; // Threshold distance before camera follows
	private float fraction = 0.7f;  // Fractional distance to move camera by each frame (smooths out the movement)
	
	// Use this for initialization
	void Start()
	{
		thisTransform = transform;
		threshold = Math.Abs (cameraTarget.transform.position.y - thisTransform.position.y);
	}
	
	// Update is called once per frame
	void Update()
	{
		// Repeat for Y
		if (cameraFollowY)
		{
			if(Math.Abs(cameraTarget.transform.position.y - thisTransform.position.y) > threshold)
			{
				// target vector = (target.position - this.position)
				// now multiply that by the fractional factor and your camera will
				// move 70% of the distance (0.7f) towards the target. It will never
				// actually reach the target hence the threshold value (but you probably don't
				// want this as it can result in a noticeable SNAP if you try to put the camera
				// on the target when it's beneath the threshold)
				// Edit: oops, missing brackets which are quite important!

				thisTransform.position = new Vector3(thisTransform.position.x, (cameraTarget.transform.position.y - thisTransform.position.y) * fraction, thisTransform.position.z);
			}
		}
	}
}