using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using NaughtyAttributes;

[RequireComponent(typeof(PlacePoint))]
public class ForceReleasePlacePoint : MonoBehaviour
{

    PlacePoint pp;

    // Start is called before the first frame update
    void Start()
    {
        pp = GetComponent<PlacePoint>();
    }

    [Button]
    public void Release()
    {
        pp.Remove();
    }
}
