using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockOnAttack : MonoBehaviour
{
    [Header("Missile Specification")]
    [Tooltip("Maximum missiles that player can have")]
    public int maxMissiles = 8;
    public float range = 3f;

    public int curMissiles { get; private set; }

    GameObject lockOnAimPoint;
    PlayerDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        lockOnAimPoint = transform.Find("LockOnAimPoint").gameObject;
        direction = GetComponent<PlayerDirection>();
        curMissiles = 4;
    }

    // Update is called once per frame
    void Update()
    {
        SetPointDirection();
        LockOnDetection();
    }

    void SetPointDirection()
    {
        lockOnAimPoint.transform.localPosition = new Vector3(direction.directionX, direction.directionY, 0).normalized * range;
    }

    void LockOnDetection()
    {
    }
}
