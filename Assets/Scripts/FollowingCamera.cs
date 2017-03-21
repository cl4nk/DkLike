using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {

    private GameObject target;
    [Range(0.0f, 1.0f)]
    public float distanceRatio = 0.3f;
    public float distanceY = -2.0f;
    private float fixedX;

	// Use this for initialization
	void Start () {
        target = GameManager.Instance.PlayerObj.gameObject;
        
        fixedX = PlateformManager.Instance.fixedX;

        /*float top = Camera.main.ViewportToWorldPoint(new Vector3(0.0F, 1.0F, -transform.position.z)).y;
        float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0.0F, 1.0F, -transform.position.z)).y;

        distanceY = (bottom - top) * distanceRatio;*/
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mPosition = transform.position;
        mPosition.x = fixedX;
        mPosition.y = distanceY + target.transform.position.y;

        transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime);
    }
}
