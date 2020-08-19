using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    public int totalLife = 3;
    public float respawnInterval = 1f;

    public bool P1AtStart;
    public bool P2AtStart;

    public int P1Left { get; private set; }
    public int P2Left { get; private set; }

    private float P1ResTiming;
    private float P2ResTiming;
    private UIContinue cont;

    // Start is called before the first frame update
    void Start()
    {
        P1Left = P1AtStart ? totalLife : 0;
        P2Left = P2AtStart ? totalLife : 0;

        P1ResTiming = respawnInterval;
        P2ResTiming = respawnInterval;

        cont = GetComponent<UIContinue>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPressStart();
        CheckPlayerIsDead();
        IncreaseTiming();
        SetGameOver();
    }

    void GetPressStart()
    {
        if (GameInput.GetStart(0))
        {
            EnemyLockOnStatus.RefreshLockablePlayers();
            P1Left = totalLife - 1;
            P1ResTiming = 0f;
            P1.SetActive(true);
            cont.enabled = false;
        }

        if (GameInput.GetStart(1))
        {
            EnemyLockOnStatus.RefreshLockablePlayers();
            P2Left = totalLife - 1;
            P2ResTiming = 0f;
            P2.SetActive(true);
            cont.enabled = false;
        }
    }

    void CheckPlayerIsDead()
    {
        if (P1ResTiming >= respawnInterval)
        {
            if (P1.activeSelf == false)
            {
                if (P1Left >= 0) P1Left--;

                if (P1Left >= 0)
                {
                    P1ResTiming = 0f;
                    P1.SetActive(true);
                }
            }
        }

        if (P2ResTiming >= respawnInterval)
        {
            if (P2.activeSelf == false)
            {
                if (P2Left >= 0) P2Left--;

                if (P2Left >= 0)
                {
                    P2ResTiming = 0f;
                    P2.SetActive(true);
                }
            }
        }
    }

    void IncreaseTiming()
    {
        if (P1.activeSelf == false && P1ResTiming < respawnInterval)
        {
            P1ResTiming += Time.deltaTime;
        }

        if (P2.activeSelf == false && P2ResTiming < respawnInterval)
        {
            P2ResTiming += Time.deltaTime;
        }
    }

    void SetGameOver()
    {
        if (P1Left < 0 && P2Left < 0 && !P1.activeSelf && !P2.activeSelf)
        {
            cont.enabled = true;
        }
    }
}
