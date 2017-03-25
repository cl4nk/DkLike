using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Transform pivot;

    public Transform Pivot
    {
        get { return pivot; }
    }

    public Vector3 RealPosition
    {
        get { return pivot.position; }
    }

    public delegate void StateDelegate();
    public event StateDelegate OnDeath;

	// Use this for initialization
	void Start ()
	{
        Transform[] children = GetComponentsInChildren<Transform>();
	    foreach (Transform child in children)
	    {
	        if (child.gameObject.name == "Body")
	        {
	            pivot = child;
	            break;
	        }
	    }

        foreach (BreakableJoint scriptBreakableJoint in GetComponentsInChildren<BreakableJoint>())
		if (scriptBreakableJoint)
		    scriptBreakableJoint.OnBreak += () =>
		    {
		        if (OnDeath != null)
		            OnDeath();
		    };
	}

}
