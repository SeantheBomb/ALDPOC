using Autohand;
using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Tool : CorruptedBehaviour<Tool>
{

    [Header("Tool Requirements")]
    public Grabbable grabbable;
    [SerializeField] BoolVariable canUseParallel = true;

    [HideInInspector]
    public GameObject owner;

    public abstract void BeginPrimaryUse();

    public abstract void WhilePrimaryUse();

    public abstract void StopPrimaryUse();

    public abstract void BeginSecondaryUse();

    public abstract void WhileSecondaryUse();

    public abstract void StopSecondaryUse();

}
