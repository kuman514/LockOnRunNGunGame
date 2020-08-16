using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP;

    public float curHP { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        curHP = HP;
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
            // destroy effect

            Destroy(gameObject);
        }
    }

    public void Damage(float dmg)
    {
        // normal hit effect
        curHP -= dmg;
    }

    public void MissileDamage(float dmg)
    {
        // missile hit effect
        curHP -= dmg;
    }
}
