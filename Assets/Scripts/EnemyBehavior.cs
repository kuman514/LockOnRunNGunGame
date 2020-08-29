using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBehavior
{
    public enum BehaviorCode { MoveAndRotate, LerpMoveAndRotate, Shoot, LookPlayer, Destroy, Loop }

    public BehaviorCode behaviorCode;

    // Only for Move & Rotate
    [Header("Move & Rotate Option")]
    public float SequenceSpan;
    public Vector3 MoveDifference;
    public Vector3 RotationDegree;

    // Only for Shoot
    [Header("Shoot Option")]
    public float ProjectileSpeed;
    public Vector3 ShotDirection;
    public GameObject ShootTo;

    // Only for Look Player
    [Header("Look Player Option")]
    public GameObject LookAt;

    // Only for Destroy
    [Header("Destroy Option")]
    public GameObject DestroyEffect;

    // Only for Loop
    [Header("Loop Option")]
    public int BackTo;
}
