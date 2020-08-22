using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSequence : MonoBehaviour
{
    public BackgroundBehavior[] backgroundBehaviors;
    public float reachMagnitude;
    public bool loop;

    private int bgbIndex;

    // Start is called before the first frame update
    void Start()
    {
        bgbIndex = 0;
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
            bgbIndex++;
        }
        else
        {
            transform.Translate((backgroundBehaviors[bgbIndex].MoveDestination - transform.position).normalized * backgroundBehaviors[bgbIndex].SequenceSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {

    }
    void MoveAndRotate()
    {

    }

    void Spawn()
    {

    }

    void Destroy()
    {

    }

    void Condition()
    {

    }

    void ChangeBGM()
    {

    }
}
