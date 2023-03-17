using Autohand;
using Corrupted;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Grabbable))]
public class GrabbableReturnToStart : CorruptedBehaviour
{

    public FloatVariable timeDelay;

    PlacePoint resetPoint;

    Grabbable grabbable;
    Coroutine coroutine;

    Vector3 position, rotation;
    Rigidbody rb = null;

    public override void Start()
    {
        base.Start();
        grabbable = GetComponent<Grabbable>();
        grabbable.OnReleaseEvent += OnObjectReleased;
        grabbable.OnGrabEvent += OnObjectGrabbed;
        position = transform.position;
        rotation = transform.eulerAngles;
        rb = this.GetComponent<Rigidbody>();

        PlaceOnStart pos = GetComponent<PlaceOnStart>();
        if(pos != null)
        {
            resetPoint = pos.placePoint;
        }
    }

    private void OnObjectGrabbed(Hand hand, Grabbable grabbable)
    {
        if(coroutine != null)
        StopCoroutine(coroutine);
    }

    private void OnObjectReleased(Hand hand, Grabbable grabbable)
    {
        coroutine = StartCoroutine(AwaitReset());
    }

    IEnumerator AwaitReset()
    {
        yield return new WaitForSeconds(timeDelay);
        if (grabbable.IsHeld() || grabbable.placePoint != null)//Don't reset if we're being held by a hand or place point
            yield break;
        ResetTransform();
    }


    void ResetTransform()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
        if (resetPoint != null)
        {
            resetPoint.Place(grabbable);
            return;
        }
        transform.position = position;
        transform.eulerAngles = rotation;
        
    }

    
}
