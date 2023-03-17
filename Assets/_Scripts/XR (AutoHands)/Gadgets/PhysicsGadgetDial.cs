using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsGadgetDial : PhysicsGadgetHingeAngleReader
{

    [Min(0.01f), Tooltip("The percentage (0-1) from the required value needed to call the event, if threshold is 0.1 OnMax will be called at 0.9, OnMin at -0.9, and OnMiddle at -0.1 or 0.1")]
    public float threshold = 0.05f;

    public UnityEvent OnMin, OnMid, OnMax;

    public float value;

    bool min = false;
    bool max = false;
    bool mid = true;

    void FixedUpdate()
    {
        this.value = GetValue();
        //var value = GetValue();
        if (!max && mid && value + threshold >= 1)
        {
            Max();
        }

        if (!min && mid && value - threshold <= -1)
        {
            Min();
        }

        if (value <= threshold && max && !mid)
        {
            Mid();
        }

        if (value >= -threshold && min && !mid)
        {
            Mid();
        }

    }

    void Max()
    {
        mid = false;
        max = true;
        OnMax?.Invoke();
    }

    void Mid()
    {
        min = false;
        max = false;
        mid = true;
        OnMid?.Invoke();
    }

    void Min()
    {
        min = true;
        mid = false;
        OnMin?.Invoke();
    }

}
