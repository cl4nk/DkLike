using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableJoint : MonoBehaviour {

    public delegate void StateDelegate();
    public event StateDelegate OnBreak;

    void OnJointBreak(float breakForce)
    {
        RaiseBreakEvent();
    }

    protected void RaiseBreakEvent()
    {
        if (OnBreak != null)
            OnBreak();
    }
}
