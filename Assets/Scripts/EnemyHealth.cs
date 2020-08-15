using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP;
    public int prizeScore = 100;

    public float curHP { get; private set; }

    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        curHP = HP;

        // get Players' Lockon system
        players = GameObject.FindGameObjectsWithTag("Player");
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
            transform.Find("Body").gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }

    public void Damage(float dmg)
    {
        curHP -= dmg;

        for(int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerLockOnAttack>().RemoveLockedOnArray(this.transform.gameObject);
        }
    }
}
