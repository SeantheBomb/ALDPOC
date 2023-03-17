using Autohand;
using Corrupted;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Hand))]
public class UseEquippedTool : CorruptedBehaviour
{

    public Tool equipped;

    public InputActionProperty OnUseStartAction, OnUseEndAction;

    Hand hand;
    bool inUse;


    // Start is called before the first frame update
    void OnEnable()
    {
        hand = GetComponent<Hand>();
        hand.OnGrabbed += OnGrabbed;
        hand.OnReleased += OnReleased;
        OnUseStartAction.action.performed += OnUseStart;
        OnUseEndAction.action.performed += OnUseEnd;
    }

    private void Update()
    {
        if (inUse == false || equipped == null)
            return;
        equipped.WhilePrimaryUse();
    }


    private void OnUseStart(InputAction.CallbackContext obj)
    {
        Debug.Log($"{name} start");
        if (equipped == null)
            return;
        equipped.BeginPrimaryUse();
        inUse = true;
    }

    private void OnUseEnd(InputAction.CallbackContext obj)
    {
        Debug.Log($"{name} end");
        if (equipped == null)
            return;
        equipped.StopPrimaryUse();
        inUse = false;
    }


    private void OnGrabbed(Hand hand, Grabbable grabbable)
    {
        Tool tool = grabbable.GetComponentInParent<Tool>();
        
        if (tool != null && tool.grabbable == grabbable)
        {
            equipped = tool;
            Debug.Log($"Hand: Grabbed {tool.name}");
        }
    }

    private void OnReleased(Hand hand, Grabbable grabbable)
    {
        if (inUse)
            equipped.StopPrimaryUse();
        inUse = false;
        equipped = null;
        Debug.Log($"Hand: Released");
    }


}
