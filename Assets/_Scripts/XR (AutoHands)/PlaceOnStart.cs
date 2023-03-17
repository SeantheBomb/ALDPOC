using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

[RequireComponent(typeof(Grabbable))]
public class PlaceOnStart : MonoBehaviour
{

    public PlacePoint placePoint;

    Grabbable g;

    private IEnumerator Start()
    {
        g = GetComponent<Grabbable>();
        if(placePoint == null)
        {
            Debug.LogError($"{name} is missing a PlacePoint reference!", gameObject);
            yield break;
        }
        if (placePoint.transform.IsChildOf(transform))
        {
            //placePoint.matchTarget = g;
            placePoint.transform.parent = null;
            yield return new WaitForFixedUpdate();
        }
        placePoint.Place(g);
    }
}
