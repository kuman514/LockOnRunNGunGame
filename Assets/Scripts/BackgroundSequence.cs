using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSequence : MonoBehaviour
{
    public BackgroundBehavior[] backgroundBehaviors;
    public float reachMagnitude;
    public bool loop;

    private int bgbIndex;
    private float movrotTimer;

    // Start is called before the first frame update
    void Start()
    {
        bgbIndex = 0;
        movrotTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bgbIndex < backgroundBehaviors.Length)
        {
            switch (backgroundBehaviors[bgbIndex].behaviorCode)
            {
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
        transform.Translate(backgroundBehaviors[bgbIndex].MoveDifference * (1 / backgroundBehaviors[bgbIndex].SequenceSpan) * Time.deltaTime);
    }

    void Rotate()
    {
        transform.Rotate(backgroundBehaviors[bgbIndex].RotationDegree * (1 / backgroundBehaviors[bgbIndex].SequenceSpan) * Time.deltaTime);
    }

    void MoveAndRotate()
    {
        if (movrotTimer >= backgroundBehaviors[bgbIndex].SequenceSpan)
        {
            ProceedToNext();
        }
        else
        {
            if (movrotTimer < backgroundBehaviors[bgbIndex].SequenceSpan)
            {
                Move();
                Rotate();
                movrotTimer += Time.deltaTime;
            }
        }
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
        if (backgroundBehaviors[bgbIndex].IsDestroyed)
        {
            ProceedToNext();
        }
        else
        {
            // move looping background

            // check enemy condition
        }
    }

    void ChangeBGM()
    {
        if (backgroundBehaviors[bgbIndex].BGMToChange != null)
        {
            // Change BGM
        }

        ProceedToNext();
    }

    void ProceedToNext()
    {
        bgbIndex++;
        movrotTimer = 0f;
    }
}
