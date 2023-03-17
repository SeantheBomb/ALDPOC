using Autohand;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Grabbable))]
[RequireComponent(typeof(Rigidbody))]
public class GrabbaleKinematicWhenNotGrabbed : MonoBehaviour
{

    Grabbable g;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        g = GetComponent<Grabbable>();
        rb = GetComponent<Rigidbody>();


        g.OnBeforeGrabEvent += OnGrab;
        g.OnReleaseEvent += OnRelease;
        SetKinematic(true);
    }

    private void OnRelease(Hand hand, Grabbable grabbable)
    {
        if (grabbable == g)
            SetKinematic(true);
    }

    private void OnGrab(Hand hand, Grabbable grabbable)
    {
        if (grabbable == g)
            SetKinematic(false);
    }

    public void SetKinematic(bool value)
    {
        rb.isKinematic = true;
    }
}
