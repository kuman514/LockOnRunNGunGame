using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockOnAttack : MonoBehaviour
{
    [Header("Missile Specification")]
    [Tooltip("Maximum missiles that player can have")]
    public int maxMissiles = 8;

    public int curMissiles { get; private set; }

    float range;
    GameObject lockOnAimPoint;
    PlayerDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        range = 3f;
        lockOnAimPoint = transform.Find("LockOnAimPoint").gameObject;
        direction = GetComponent<PlayerDirection>();
        curMissiles = 4;
    }

    // Update is called once per frame
    void Update()
    {
        SetPointDirection();
    }

    void SetPointDirection()
    {
        lockOnAimPoint.transform.localPosition = new Vector3(direction.directionX, direction.directionY, 0).normalized * range;
    }
}
