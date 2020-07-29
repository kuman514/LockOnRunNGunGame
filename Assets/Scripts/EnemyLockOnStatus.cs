using System.Collections;
using System.Collections.Generic;
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
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseTiming();
    }

    bool CheckLockable()
    {
        return (lockOnTiming >= secondsAfterLockedOn);
    }

    void IncreaseTiming()
    {
        if (lockonTiming < secondsAfterLockedOn)
        {
            lockonTiming += Time.deltaTime;
        }
    }
}
