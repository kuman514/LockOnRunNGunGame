﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use [System.Serializable] right before defining a struct or class if you want it to be seen on the inspector
[System.Serializable]
public struct BackgroundBehavior
{
    public enum BehaviorCode { MoveAndRotate, LerpMoveAndRotate, Spawn, Destroy, Condition, ChangeBGM, PlaySFX }

    public BehaviorCode behaviorCode;

    // Only for Move & Rotate
    [Header("Move & Rotate Option")]
    public float SequenceSpan;
    public Vector3 MoveDifference;
    public Vector3 RotationDegree;

    // Only for Spawn
    [Header("Spawn Option")]
    public GameObject ObjectToSpawn;
    public Vector3 SpawnPosition;
    public Quaternion SpawnRotation;

    // Only for Destroy
    [Header("Destroy Option")]
    public GameObject ObjectToDestroy;
    public GameObject DestructionEffect;

    // Only for Condition
    [Header("Condition Option")]
    public GameObject DestroyToProceed;
    public bool IsDestroyed;
    public GameObject LoopsWhileObjectAlive;

    // Only for ChangeBGM
    [Header("Change BGM Option")]
    public AudioClip BGMToChange;

    // Only for Play SF
    [Header("Play SFX Option")]
    public AudioClip SFXToPlay;
}
