using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using Autohand;
using System;

[RequireComponent(typeof(HandTriggerAreaEvents))]
public abstract class HandTriggerBehaviour : CorruptedBehaviour
{

    public HandTriggerAreaEvents trigger
    {
        get; protected set;
    }

    public override void Start()
    {
        base.Start();
        trigger = GetComponent<HandTriggerAreaEvents>();
        trigger.HandGrabEvent += OnGrab;
        trigger.HandReleaseEvent += OnRelease;
        trigger.HandEnterEvent += OnTouchEnter;
        trigger.HandExitEvent += OnTouchEnter;
        trigger.HandGrabEvent += (Hand h) => enabled = true;
        trigger.HandReleaseEvent += (Hand h) => enabled = false;
        enabled = false;
    }


    public abstract void OnGrab(Hand hand);

    public abstract void OnRelease(Hand hand);

    public virtual void OnTouchEnter(Hand hand) { }

    public virtual void OnTouchExit(Hand hand) { }

    public void FixedUpdate()
    {
        WhileGrab();
    }

    public virtual void WhileGrab()
    {
    }
}
