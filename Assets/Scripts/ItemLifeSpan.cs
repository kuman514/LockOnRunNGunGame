using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLifeSpan : MonoBehaviour
{
    public float span = 15f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < span)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
