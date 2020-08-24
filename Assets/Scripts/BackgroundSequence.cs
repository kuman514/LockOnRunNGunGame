using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSequence : MonoBehaviour
{
    public BackgroundBehavior[] backgroundBehaviors;
    public float reachMagnitude;
    public bool loop;

    private int bgbIndex;
    private float rotationTimer;

    // Start is called before the first frame update
    void Start()
    {
        bgbIndex = 0;
        rotationTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bgbIndex < backgroundBehaviors.Length)
        {
            switch (backgroundBehaviors[bgbIndex].behaviorCode)
            {
                case BackgroundBehavior.BehaviorCode.Move:
                    Move();
                    break;
                case BackgroundBehavior.BehaviorCode.Rotate:
                    Rotate();
                    break;
                case BackgroundBehavior.BehaviorCode.MoveAndRotate:
                    MoveAndRotate();
                    break;
                case BackgroundBehavior.BehaviorCode.Spawn:
                    Spawn();
                    break;
                case BackgroundBehavior.BehaviorCode.Destroy:
                    Destroy();
                    break;
                case BackgroundBehavior.BehaviorCode.Condition:
                    Condition();
                    break;
                case BackgroundBehavior.BehaviorCode.ChangeBGM:
                    ChangeBGM();
                    break;
            }
        }
        else if (loop)
        {
            bgbIndex = 0;
        }
    }

    void Move()
    {
        if ((backgroundBehaviors[bgbIndex].MoveDestination - transform.position).magnitude <= reachMagnitude)
        {
            ProceedToNext();
        }
        else
        {
            transform.Translate((backgroundBehaviors[bgbIndex].MoveDestination - transform.position).normalized * backgroundBehaviors[bgbIndex].SequenceSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (rotationTimer >= backgroundBehaviors[bgbIndex].SequenceSpan)
        {
            ProceedToNext();
        }
        else
        {
            transform.Rotate(backgroundBehaviors[bgbIndex].RotationDegree * (1 / backgroundBehaviors[bgbIndex].SequenceSpan) * Time.deltaTime);
            rotationTimer += Time.deltaTime;
        }
    }

    void MoveAndRotate()
    {
        ProceedToNext();
    }

    void Spawn()
    {
        if (backgroundBehaviors[bgbIndex].ObjectToSpawn != null)
        {
            Instantiate(backgroundBehaviors[bgbIndex].ObjectToSpawn,
                        backgroundBehaviors[bgbIndex].SpawnPosition,
                        backgroundBehaviors[bgbIndex].SpawnRotation);
        }

        ProceedToNext();
    }

    void Destroy()
    {
        if (backgroundBehaviors[bgbIndex].ObjectToDestroy != null)
        {
            // effect

            Destroy(backgroundBehaviors[bgbIndex].ObjectToDestroy);
        }

        ProceedToNext();
    }

    void Condition()
    {
        ProceedToNext();
    }

    void ChangeBGM()
    {
        ProceedToNext();
    }

    void ProceedToNext()
    {
        bgbIndex++;
        rotationTimer = 0f;
    }
}
