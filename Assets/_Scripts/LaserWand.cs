using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserWand : Tool
{

    public LaserDeviceSim laserDevice;

    public bool isPowered => laserDevice.isOn;

    public float range;

    public Transform laserTip;

    public ParticleSystem vfx;

    public AudioSource sfx;

    public UnityEvent OnLaserHit;

    public override void Start()
    {
        base.Start();
        vfx.Stop();
        sfx.Stop();
    }

    public void FireLaser()
    {
        Ray ray = new Ray(laserTip.position, laserTip.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, range, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            vfx.transform.position = hit.point;
            vfx.transform.rotation = Quaternion.LookRotation(hit.normal);
            if (vfx.isPlaying == false)
            {
                vfx.Play();
                sfx.Play();
                OnLaserHit?.Invoke();
            }
            Debug.Log($"Laser: Hit {hit.transform.name}");
        }
        else
        {
            vfx.Stop();
            sfx.Stop();
            Debug.Log($"Laser: Hit nothing");
        }
    }

    public override void BeginPrimaryUse()
    {
    }

    public override void BeginSecondaryUse()
    {

    }

    public override void StopPrimaryUse()
    {
        vfx.Stop();
        sfx.Stop();
    }

    public override void StopSecondaryUse()
    {
    }

    public override void WhilePrimaryUse()
    {
        if (isPowered == false)
            return;
        FireLaser();
    }

    public override void WhileSecondaryUse()
    {
    }


}
