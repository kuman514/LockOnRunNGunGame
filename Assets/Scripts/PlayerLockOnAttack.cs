using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockOnAttack : MonoBehaviour
{
    float range;
    GameObject lockOnAimPoint;
    PlayerDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        range = 3f;
        lockOnAimPoint = transform.Find("LockOnAimPoint").gameObject;
        direction = GetComponent<PlayerDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        SetPointDirection();
    }

    void SetPointDirection()
    {
        lockOnAimPoint.transform.localPosition = new Vector3(range * direction.directionX, range * direction.directionY, 0);
    }
}
