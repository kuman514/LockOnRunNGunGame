using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPressStart();
    }

    void GetPressStart()
    {
        if (GameInput.GetStart(0))
        {
            EnemyLockOnStatus.RefreshLockablePlayers();
            P1.SetActive(true);
        }

        if (GameInput.GetStart(1))
        {
            EnemyLockOnStatus.RefreshLockablePlayers();
            P2.SetActive(true);
        }
    }
}
