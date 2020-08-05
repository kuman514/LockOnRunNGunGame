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
    private PlayerLockOnAttack p1Lock;
    //private PlayerLockOnAttack p2Lock;

    // Start is called before the first frame update
    void Start()
    {
        isLockedOn = false;
        lockonTiming = 0f;
        cam = Camera.main;

        // get Players' Lockon system
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        p1Lock = players[0].transform.GetComponent<PlayerLockOnAttack>();
        //p2Lock = players[1].transform.GetComponent<PlayerLockOnAttack>();
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

    public bool CheckLockable()
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

    public void ResetLockOnInterval()
    {
        lockonTiming = 0f;
    }

    private void OnDestroy()
    {
        p1Lock.RemoveLockedOnArray(this.transform.gameObject);
        //p2Lock.RemoveLockedOnArray(this.transform.gameObject);
    }
}
