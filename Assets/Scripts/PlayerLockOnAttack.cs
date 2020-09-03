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
    private List<GameObject> lockOnMarks;

    private GameObject lockOnAimPoint;
    private PlayerDirection direction;
    private Camera cam;
    private AudioSource sfx;

    [Header("Prefabs")]
    [Tooltip("A mark on enemies locked on")]
    public GameObject lockOnMark;
    [Tooltip("Missile that goes to an enemy locked on")]
    public GameObject missilePrefab;

    [Header("Sound Effects")]
    [Tooltip("A sound clip when firing missiles")]
    public AudioClip missileFireSFX;
    [Tooltip("A sound clip when locking on enemies")]
    public AudioClip lockOnSFX;

    private int pCode;

    // Start is called before the first frame update
    void Start()
    {
        lockOnAimPoint = transform.Find("LockOnAimPoint").gameObject;
        cam = Camera.main;
        direction = GetComponent<PlayerDirection>();
        curMissiles = 4;
        lockedEnemies = new List<GameObject>();
        lockOnMarks = new List<GameObject>();
        sfx = cam.transform.GetComponent<AudioSource>();
        pCode = GetComponent<PlayerState>().playerCode;
    }

    // Update is called once per frame
    void Update()
    {
        CountAvailableLockOnsForExtern();
        MarkManagement();
        SetPointDirection();
        SetLockOnCursorPos();
        LockOnDetection();
        Fire();
    }

    void CountAvailableLockOnsForExtern()
    {
        curLockOn = lockedEnemies.Count;
    }

    void MarkManagement()
    {
        while (lockOnMarks.Count > curLockOn)
        {
            RemoveLockOnMark();
        }
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
                EnemyLockOnStatus els = rch.transform.gameObject.GetComponent<EnemyLockOnStatus>();

                if (els == null)
                {
                    Debug.LogError("EnemyLockOnStatus Not Found");
                    continue;
                }

                if (lockedEnemies.Count < curMissiles && els.CheckLockable())
                {
                    if (lockOnSFX != null && sfx != null)
                    {
                        // LockOn Sound Effect
                        sfx.PlayOneShot(lockOnSFX);
                    }

                    // Add the enemy locked on to array
                    lockedEnemies.Add(rch.transform.gameObject);

                    // Make a lockon mark
                    MakeLockOnMark(rch.transform.gameObject);

                    els.ResetLockOnInterval();
                }
            }
        }
    }

    void Fire()
    {
        if (IsFireable() && GameInput.GetMissle(pCode))
        {
            if (missileFireSFX != null && sfx != null && lockedEnemies.Count > 0)
            {
                sfx.PlayOneShot(missileFireSFX);
            }

            foreach (GameObject target in lockedEnemies)
            {
                GameObject missile = Instantiate(missilePrefab, this.transform);
                PlayerMissile pm = missile.transform.GetComponent<PlayerMissile>();
                ProjectileWhoShoot who = missile.transform.GetComponent<ProjectileWhoShoot>();

                pm.SetTarget(target);
                who.who = transform.gameObject;
                missile.transform.SetParent(null);
            }

            lockedEnemies.Clear();
        }
    }

    bool IsFireable()
    {
        return true;
    }

    void MakeLockOnMark(GameObject target)
    {
        GameObject mark = Instantiate(lockOnMark, target.transform);
        mark.transform.SetParent(target.transform);
        mark.transform.localPosition = new Vector3(0, 0, target.GetComponent<EnemyUILockOnMark>().hoverDistance);
        lockOnMarks.Add(mark);
    }

    void RemoveLockOnMark()
    {
        Destroy(lockOnMarks[0]);
        lockOnMarks.RemoveAt(0);
    }

    // For Items Only
    public void ExtendLockOn()
    {
        if (curMissiles < maxMissiles)
        {
            curMissiles++;
        }
    }

    // For Enemy Modules Only
    public void RemoveLockedOnEnemyDestroyed(GameObject destroyed)
    {
        while (lockedEnemies.Contains(destroyed))
        {
            lockedEnemies.Remove(destroyed);
        }
    }
}
