using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyLockOnStatus : MonoBehaviour
{
    public float secondsAfterLockedOn = 0.4f;

    private bool isLockedOn;
    private float lockonTiming;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        isLockedOn = false;
        lockonTiming = 0f;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PaintLockOn();
        IncreaseTiming();
    }

    public void SetLockedOn()
    {
        isLockedOn = true;
    }

    void PaintLockOn()
    {
        if (isLockedOn)
        {
            Vector3 uiPos = cam.WorldToScreenPoint(transform.position);
        }
    }

    bool CheckLockable()
    {
        return (lockonTiming >= secondsAfterLockedOn);
    }

    void IncreaseTiming()
    {
        if (lockonTiming < secondsAfterLockedOn)
        {
            lockonTiming += Time.deltaTime;
        }
    }
}
