using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : BreakableJoint {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
            RaiseBreakEvent();

    }
}
