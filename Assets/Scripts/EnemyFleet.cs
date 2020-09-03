using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        while (transform.childCount > 0)
        {
            transform.GetChild(0).SetParent(null);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
