using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using Autohand;


[RequireComponent(typeof(Grabbable))]
public abstract class GrabbableBehaviour : CorruptedBehaviour
{

    public Grabbable grabbable
    {
        get; protected set;
    }

    public override void Start()
    {
        base.Start();
        grabbable = GetComponent<Grabbable>();
        grabbable.OnGrabEvent += OnGrab;
        grabbable.OnReleaseEvent += OnRelease;
        grabbable.OnGrabEvent += (Hand h, Grabbable g) => enabled = true;
        grabbable.OnReleaseEvent += (Hand h, Grabbable g) => enabled = false;
        enabled = false;
    }

    public abstract void OnGrab(Hand hand, Grabbable g);

    public abstract void OnRelease(Hand hand, Grabbable g);
    
    public void FixedUpdate()
    {
        WhileGrab();
    }

    public virtual void WhileGrab()
    {
    }
}
