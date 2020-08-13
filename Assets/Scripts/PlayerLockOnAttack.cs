using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerLockOnAttack : MonoBehaviour
{
    [Header("Missile Specification")]
    [Tooltip("Maximum missiles that player can have")]
    public int maxMissiles = 8;
    public float range = 4f;
    public float lockOnRadius = 1.5f;

    public int curMissiles { get; private set; }
    public int curLockOn { get; private set; }
    public Vector3 lockonCursorPos { get; private set; }
    
    private List<GameObject> lockedEnemies;
    private GameObject lockOnAimPoint;
    private PlayerDirection direction;
    private PlayerUILockOnMark marker;
    private Camera cam;
    private AudioSource sfx;

    public GameObject missilePrefab;
    public AudioClip missileFireSFX;
    public AudioClip lockOnSFX;

    // Start is called before the first frame update
    void Start()
    {
        lockOnAimPoint = transform.Find("LockOnAimPoint").gameObject;
        cam = Camera.main;
        direction = GetComponent<PlayerDirection>();
        curMissiles = 4;
        lockedEnemies = new List<GameObject>();
        marker = GetComponent<PlayerUILockOnMark>();
        sfx = cam.transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CountAvailableLockOnsForExtern();
        SetPointDirection();
        SetLockOnCursorPos();
        LockOnDetection();
        Fire();
    }

    void CountAvailableLockOnsForExtern()
    {
        curLockOn = lockedEnemies.Count;
    }

    void SetPointDirection()
    {
        lockOnAimPoint.transform.localPosition = new Vector3(direction.directionX, direction.directionY, 0).normalized * range;
    }

    void SetLockOnCursorPos()
    {
        lockonCursorPos = cam.WorldToScreenPoint(lockOnAimPoint.transform.position);
    }

    void LockOnDetection()
    {
        Vector3 dir = lockOnAimPoint.transform.position - cam.transform.position;

        RaycastHit[] target = Physics.SphereCastAll(lockOnAimPoint.transform.position, lockOnRadius, dir);
        foreach (RaycastHit rch in target)
        {
            if (rch.transform.CompareTag("Target"))
            {
                EnemyLockOnStatus els = rch.transform.GetComponent<EnemyLockOnStatus>();

                if (lockedEnemies.Count < curMissiles && els.CheckLockable())
                {
                    if (lockOnSFX != null && sfx != null)
                    {
                        // LockOn Sound Effect
                        sfx.PlayOneShot(lockOnSFX);
                    }

                    lockedEnemies.Add(rch.transform.gameObject);
                    CreateLockOnMark(rch.transform.gameObject);
                    els.ResetLockOnInterval();
                }
            }
        }
    }

    void Fire()
    {
        if (IsFireable() && Input.GetButtonDown("Fire2"))
        {
            if (missileFireSFX != null && sfx != null && lockedEnemies.Count > 0)
            {
                sfx.PlayOneShot(missileFireSFX);
            }

            foreach (GameObject target in lockedEnemies)
            {
                GameObject missile = Instantiate(missilePrefab, this.transform);
                PlayerMissile pm = missile.transform.GetComponent<PlayerMissile>();
                pm.SetTarget(target);
                missile.transform.SetParent(null);
            }
        }
    }

    bool IsFireable()
    {
        return true;
    }

    public void RemoveLockedOnArray(GameObject disappear)
    {
        while (lockedEnemies.Contains(disappear))
        {
            lockedEnemies.Remove(disappear);
            RemoveLockOnMark(disappear);
        }
    }

    public void RemoveLockOn(GameObject damaged)
    {
        if (lockedEnemies.Contains(damaged))
        {
            lockedEnemies.Remove(damaged);
            RemoveLockOnMark(damaged);
        }
    }

    public void ExtendLockOn()
    {
        if (curMissiles < maxMissiles)
        {
            curMissiles++;
        }
    }

    void CreateLockOnMark(GameObject create)
    {
        marker.CreateMark(create);
    }

    void RemoveLockOnMark(GameObject disappear)
    {
        marker.DeleteMark(disappear);
    }
}
