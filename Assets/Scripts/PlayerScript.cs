using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public delegate void StateDelegate();
    public event StateDelegate OnDeath;

	// Use this for initialization
	void Start () {
		foreach (BreakableJoint scriptBreakableJoint in GetComponentsInChildren<BreakableJoint>())
		    if (scriptBreakableJoint)
		        scriptBreakableJoint.OnBreak += () =>
		        {
		            if (OnDeath != null)
		                OnDeath();
		        };
	}

}
