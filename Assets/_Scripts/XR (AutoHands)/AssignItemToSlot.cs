using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using Corrupted;

[RequireComponent(typeof(Hand))]
public class AssignItemToSlot : MonoBehaviour
{

    public PlacePoint slot;
    public KeyVariable slotKey;

    Hand hand;

    //Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<Hand>();
        hand.OnReleased += Hand_OnReleased;
        FindSlot();
    }

    private void Hand_OnReleased(Hand hand, Grabbable grabbable)
    {
        FindSlot();
        if(enabled)
            StartCoroutine(AssignToSlot(grabbable));
    }

    IEnumerator AssignToSlot(Grabbable g)
    { 
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        if (g == null)
            yield break;
        if (g.IsHeld() || g.placePoint != null)
            yield break;
        if (slot.CanPlace(g))
        {
            slot.Place(g);
        }
    }

    bool Contains(string[] list, string name)
    {
        foreach (string s in list)
        {
            if (name.Contains(s))
                return true;
        }
        return false;
    }

    void FindSlot()
    {
        if (slot == null && string.IsNullOrWhiteSpace(slotKey) == false)
        {
            slot = PlacePoint.GetInstance(slotKey);
        }
    }


}
