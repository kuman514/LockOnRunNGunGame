﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySequence : MonoBehaviour
{
    public EnemyBehavior[] enemyBehaviors;
    public float reachMagnitude;
    public bool loop;

    private int enbIndex;
    private float movrotTimer;

    // Start is called before the first frame update
    void Start()
    {
        enbIndex = 0;
        movrotTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enbIndex < enemyBehaviors.Length)
        {
            switch (enemyBehaviors[enbIndex].behaviorCode)
            {
                case EnemyBehavior.BehaviorCode.MoveAndRotate:
                    MoveAndRotate();
                    break;
                case EnemyBehavior.BehaviorCode.LerpMoveAndRotate:
                    LerpMoveAndRotate();
                    break;
                case EnemyBehavior.BehaviorCode.Shoot:
                    Shoot();
                    break;
                case EnemyBehavior.BehaviorCode.LookPlayer:
                    LookPlayer();
                    break;
                case EnemyBehavior.BehaviorCode.Loop:
                    Loop();
                    break;
                case EnemyBehavior.BehaviorCode.Destroy:
                    End();
                    break;
            }
        }
        else if (loop)
        {
            ProceedToNext();
        }
        else
        {
            End();
        }
    }

    void Move()
    {
        transform.Translate(enemyBehaviors[enbIndex].MoveDifference * (1 / enemyBehaviors[enbIndex].SequenceSpan) * Time.deltaTime);
    }

    void Rotate()
    {
        transform.Rotate(enemyBehaviors[enbIndex].RotationDegree * (1 / enemyBehaviors[enbIndex].SequenceSpan) * Time.deltaTime);
    }

    void MoveAndRotate()
    {
        if (movrotTimer >= enemyBehaviors[enbIndex].SequenceSpan)
        {
            ProceedToNext();
        }
        else
        {
            if (movrotTimer < enemyBehaviors[enbIndex].SequenceSpan)
            {
                Move();
                Rotate();
                movrotTimer += Time.deltaTime;
            }
        }
    }

    void LerpMove()
    {
        transform.Translate(enemyBehaviors[enbIndex].MoveDifference * (1 / enemyBehaviors[enbIndex].SequenceSpan) * Time.deltaTime);
    }

    void LerpRotate()
    {
        transform.Rotate(enemyBehaviors[enbIndex].RotationDegree * (1 / enemyBehaviors[enbIndex].SequenceSpan) * Time.deltaTime);
    }

    void LerpMoveAndRotate()
    {
        if (movrotTimer >= enemyBehaviors[enbIndex].SequenceSpan)
        {
            ProceedToNext();
        }
        else
        {
            if (movrotTimer < enemyBehaviors[enbIndex].SequenceSpan)
            {
                LerpMove();
                LerpRotate();
                movrotTimer += Time.deltaTime;
            }
        }
    }

    void Shoot()
    {

    }

    void LookPlayer()
    {

    }

    void Loop()
    {

    }

    void End()
    {
        Destroy(gameObject);
    }

    void ProceedToNext()
    {
        enbIndex++;
        movrotTimer = 0f;
    }

    private void OnDestroy()
    {
        
    }
}