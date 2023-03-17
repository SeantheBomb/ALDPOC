using Autohand;
using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseableBehaviour : GrabbableBehaviour
{

    XRHandControllerLink link;
    public CommonButton button;

    bool pressed;

    public override void OnGrab(Hand hand, Grabbable g)
    {
        link = hand.GetComponent<XRHandControllerLink>();
    }

    public override void OnRelease(Hand hand, Grabbable g)
    {
        //throw new System.NotImplementedException();
    }

    public override void WhileGrab()
    {
        if (link.ButtonPressed(button))
        {
            if (pressed == false)
                OnUseStart();
            else
                OnUseStay();
            pressed = true;
        }
        else if (link.ButtonPressed(button) == false && pressed)
        {
            OnUseEnd();
            pressed = false;
        }
    }

    public abstract void OnUseStart();

    public abstract void OnUseStay();

    public abstract void OnUseEnd();

}
