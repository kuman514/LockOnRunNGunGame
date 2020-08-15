using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyLockOnStatus : MonoBehaviour
{
    public float secondsAfterLockedOn = 0.4f;

    public Vector3 uiPos { get; private set; }

    //private bool isLockedOn;
    private float lockonTiming;

    private Camera cam;

    GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        //isLockedOn = false;
        lockonTiming = secondsAfterLockedOn;
        cam = Camera.main;

        // get Players' Lockon system
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SetLockOnUIPos();
        IncreaseTiming();
    }

    void SetLockOnUIPos()
    {
        uiPos = cam.WorldToScreenPoint(transform.position);
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
        for(int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                PlayerLockOnAttack PLOA = players[i].transform.GetComponent<PlayerLockOnAttack>();
                if (PLOA != null)
                {
                    PLOA.RemoveLockedOnArray(this.transform.gameObject);
                }
            }
        }
    }
}
