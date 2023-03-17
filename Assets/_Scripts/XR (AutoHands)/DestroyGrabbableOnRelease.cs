using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using Autohand;
using System;

[RequireComponent(typeof(Grabbable))]
public class DestroyGrabbableOnRelease : MonoBehaviour
{

    public BoolVariable readyToDestroy;
    Grabbable grabbable;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<Grabbable>();
        grabbable.OnReleaseEvent += OnRelease;
    }

    private void OnRelease(Hand hand, Grabbable grabbable)
    {
        if (readyToDestroy)
        {
            Destroy(gameObject);
        }
    }

    public void SetReadyToDestroy(bool value)
    {
        readyToDestroy = value;
    }

}
