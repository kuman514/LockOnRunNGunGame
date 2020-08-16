using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyLockOnStatus : MonoBehaviour
{
    public float secondsAfterLockedOn = 0.4f;

    public Vector3 uiPos { get; private set; }

    private float lockonTiming;
    private Camera cam;

    private static GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        lockonTiming = secondsAfterLockedOn;
        cam = Camera.main;
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

    public static void RefreshLockablePlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void OnDestroy()
    {
        // effects

        // request removal of players' lockon
        RefreshLockablePlayers();
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                PlayerLockOnAttack ploa = players[i].GetComponent<PlayerLockOnAttack>();
                if (ploa != null)
                {
                    ploa.RemoveLockedOnEnemyDestroyed(gameObject);
                }
            }
        }
    }
}
