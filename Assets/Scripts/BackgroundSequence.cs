using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSequence : MonoBehaviour
{
    public BackgroundBehavior[] backgroundBehaviors;
    public float reachMagnitude;
    public bool loop;

    public GameObject NextBG;

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
                case BackgroundBehavior.BehaviorCode.LerpMoveAndRotate:
                    LerpMoveAndRotate();
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
                case BackgroundBehavior.BehaviorCode.PlaySFX:
                    PlaySFX();
                    break;
            }
        }
        else if (loop)
        {
            bgbIndex = 0;
        }
        else
        {
            NextLoad();
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

    void LerpMove()
    {
        transform.Translate(backgroundBehaviors[bgbIndex].MoveDifference * (1 / backgroundBehaviors[bgbIndex].SequenceSpan) * Time.deltaTime);
    }

    void LerpRotate()
    {
        transform.Rotate(backgroundBehaviors[bgbIndex].RotationDegree * (1 / backgroundBehaviors[bgbIndex].SequenceSpan) * Time.deltaTime);
    }

    void LerpMoveAndRotate()
    {
        if (movrotTimer >= backgroundBehaviors[bgbIndex].SequenceSpan)
        {
            ProceedToNext();
        }
        else
        {
            if (movrotTimer < backgroundBehaviors[bgbIndex].SequenceSpan)
            {
                LerpMove();
                LerpRotate();
                movrotTimer += Time.deltaTime;
            }
        }
    }

    void Spawn()
    {
        if (backgroundBehaviors[bgbIndex].ObjectToSpawn != null)
        {
            GameObject enemy = Instantiate(backgroundBehaviors[bgbIndex].ObjectToSpawn,
                        backgroundBehaviors[bgbIndex].SpawnPosition,
                        backgroundBehaviors[bgbIndex].SpawnRotation);
            enemy.transform.SetParent(null);

            EnemyBoss eb = enemy.GetComponent<EnemyBoss>();
            if (eb != null)
            {
                eb.SetBG(gameObject);
            }

            if (bgbIndex + 1 < backgroundBehaviors.Length)
            {
                if (backgroundBehaviors[bgbIndex + 1].LoopsWhileObjectAlive != null)
                {
                    GameObject loopbg = Instantiate(backgroundBehaviors[bgbIndex + 1].LoopsWhileObjectAlive,
                                                    new Vector3(0, 0, 10f), new Quaternion(0, 0, 0, 0));
                    loopbg.transform.SetParent(null);
                    backgroundBehaviors[bgbIndex + 1].LoopsWhileObjectAlive = loopbg;
                }
            }
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
            Destroy(backgroundBehaviors[bgbIndex].LoopsWhileObjectAlive);
            ProceedToNext();
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

    void PlaySFX()
    {
        if (backgroundBehaviors[bgbIndex].SFXToPlay != null)
        {
            // Play SFX
        }

        ProceedToNext();
    }

    void NextLoad()
    {
        if (NextBG != null)
        {
            GameObject n = Instantiate(NextBG, new Vector3(0, 0, 10f), new Quaternion(0, 0, 0, 0));
            n.transform.SetParent(null);
        }

        Destroy(gameObject);
    }

    public void BossDestroyed()
    {
        backgroundBehaviors[bgbIndex].IsDestroyed = true;
    }
}
