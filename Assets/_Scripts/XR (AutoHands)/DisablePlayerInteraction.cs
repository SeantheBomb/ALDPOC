using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using System;
using NaughtyAttributes;

public class DisablePlayerInteraction : CorruptedBehaviour
{

    static System.Action<bool> OnSetState;
    public static bool IsEnabled
    {
        get; protected set;
    } = true;

    public bool isDisabledHand = false;

    public override void Start()
    {
        base.Start();

        OnSetState += SetLocalState;
        if (isDisabledHand)
            SetLocalState(true);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        OnSetState -= SetLocalState;
    }

    private void SetLocalState(bool obj)
    {
        if (isDisabledHand)
            obj = !obj;
        gameObject.SetActive(obj);
    }

    [Button]
    public void EnableHands()
    {
        SetState(true);
    }

    [Button]
    public void DisableHands()
    {
        SetState(false);
    }

    public static void SetState(bool state)
    {
        if (state == IsEnabled)
            return;
        OnSetState?.Invoke(state);
        IsEnabled = state;
    }


}
