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
    public Vector3 lockonCursorPos { get; private set; }
    
    private ArrayList lockedEnemies;
    private GameObject lockOnAimPoint;
    private PlayerDirection direction;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        lockOnAimPoint = transform.Find("LockOnAimPoint").gameObject;
        cam = Camera.main;
        direction = GetComponent<PlayerDirection>();
        curMissiles = 4;
        lockedEnemies = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        SetPointDirection();
        SetLockOnCursorPos();
        LockOnDetection();
        Fire();
        LockedEnemyManagement();
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
        Vector3 dir = new Vector3(lockonCursorPos.x, lockonCursorPos.y, cam.nearClipPlane);
        dir = lockOnAimPoint.transform.position - cam.ScreenToWorldPoint(dir);

        RaycastHit[] target = Physics.SphereCastAll(lockOnAimPoint.transform.position, lockOnRadius, dir);
        foreach (RaycastHit rch in target)
        {
            if (rch.transform.CompareTag("Target"))
            {
                // Lock On Method Here
                if (lockedEnemies.Count < curMissiles)
                {
                    Debug.Log("Enemy Locked On");
                    lockedEnemies.Add(rch.transform.gameObject);
                }

                //Destroy(rch.transform.gameObject);
            }
        }
    }

    void Fire()
    {

    }

    void LockedEnemyManagement()
    {
        // Problem: Disappeared enemy locked on is still remaining.

        for (int i = 0; i < lockedEnemies.Count; i++)
        {
            if (lockedEnemies[i] == null)
            {
                lockedEnemies.RemoveAt(i);
                i--;
            }
        }
    }
}
