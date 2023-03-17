using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ConstrainRigidbodyPosition : MonoBehaviour
{

    public Vector3 positiveLimits, negativeLimits;

    Rigidbody rb;
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        origin = rb.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position = ClampPosition(rb.position, origin + positiveLimits, origin - negativeLimits);
    }


    Vector3 ClampPosition(Vector3 pos, Vector3 pLimit, Vector3 nLimit)
    {
        pos.x = Mathf.Clamp(pos.x, nLimit.x, pLimit.x);

        pos.y = Mathf.Clamp(pos.y, nLimit.y, pLimit.y);

        pos.z = Mathf.Clamp(pos.z, nLimit.z, pLimit.z);

        return pos;
    }
}
