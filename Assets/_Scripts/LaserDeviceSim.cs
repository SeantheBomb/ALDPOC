using Corrupted;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDeviceSim : MonoBehaviour
{

    public System.Action<bool> SetState;
    public UnityEvent TurnOnEvent, TurnOffEvent;

    public FlagValue isOnFlag;
    public FlagValue isUnlockedFlag;

    bool hasUpdated = false;

    public bool isOn => isOnFlag.Value && isUnlockedFlag.Value;

    // Start is called before the first frame update
    void Start()
    {
        isOnFlag.OnUpdated += OnUpdate;
        isUnlockedFlag.OnUpdated += OnUpdate;
    }

    private void OnDestroy()
    {
        isOnFlag.OnUpdated -= OnUpdate;
        isUnlockedFlag.OnUpdated -= OnUpdate;
    }

    private void OnUpdate(bool value)
    {

        SetState?.Invoke(isOn);
        if (isOn)
            TurnOnEvent?.Invoke();
        else
            TurnOffEvent?.Invoke();
    }

    [Button]
    public void TurnOn()
    {
        isOnFlag.SetValue(true);
    }

    [Button]
    public void TurnOff()
    {
        isOnFlag.SetValue(false);
    }

    [Button]
    public void Unlock()
    {
        isUnlockedFlag.SetValue(true);
    }

    [Button]
    public void Lock()
    {
        isUnlockedFlag.SetValue(false);
    }
}
