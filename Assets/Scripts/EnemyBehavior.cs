using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBehavior
{
    public enum BehaviorCode { MoveAndRotate, Shoot, LookPlayer, Destroy, Loop }

    public BehaviorCode behaviorCode;
}
