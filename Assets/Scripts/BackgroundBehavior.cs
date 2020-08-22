using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use [System.Serializable] right before defining a struct or class if you want it to be seen on the inspector
[System.Serializable]
public struct BackgroundBehavior
{
    public enum BehaviorCode { Move, Rotate, MoveAndRotate, Spawn, Destroy, Condition, ChangeBGM }

    public BehaviorCode behaviorCode;

    // For Move & Rotate
    [Header("Move / Rotate Option")]
    public float SequenceSpeed;
    public Vector3 MoveDestination;
    public Vector3 RotationDegree;

    // Only for Spawn
    [Header("Spawn Option")]
    public GameObject ObjectToSpawn;
    public Vector3 SpawnPosition;

    // Only for Destroy
    [Header("Destroy Option")]
    public GameObject ObjectsToDestroy;
    public GameObject DestructionEffect;

    // Only for Condition
    [Header("Condition Option")]
    public GameObject DestroyToProceed;
    public bool IsDestroyed;
    public GameObject LoopsWhileObjectAlive;
    public Vector3 LoopDirection;
    public float LoopSpeed;

    // Only for ChangeBGM
    [Header("Change BGM Option")]
    public AudioClip BGMToChange;
}
