using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP;

    public float curHP { get; private set; }

    private PlayerLockOnAttack p1Lock;
    //private PlayerLockOnAttack p2Lock;

    // Start is called before the first frame update
    void Start()
    {
        curHP = HP;

        // get Players' Lockon system
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        p1Lock = players[0].transform.GetComponent<PlayerLockOnAttack>();
        //p2Lock = players[1].transform.GetComponent<PlayerLockOnAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        if (curHP <= 0)
        {
            // destroy method

            Destroy(gameObject);
        }
    }

    public void Damage(float dmg)
    {
        curHP -= dmg;

        p1Lock.RemoveLockOn(this.transform.gameObject);
        //p2Lock.RemoveLockOn(this.transform.gameObject);
    }
}
