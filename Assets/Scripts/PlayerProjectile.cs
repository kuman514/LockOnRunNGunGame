using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [Range(1, 2)]
    public int shooter = 1;
    public float speed = 20f;
    public Vector3 direction;
    public float lifetime = 2f;

    private float timeSpan;

    // Start is called before the first frame update
    void Start()
    {
        timeSpan = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        GoForward();
        Timer();
    }

    void GoForward()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Collision method here

        Destroy(gameObject);
    }

    private void Timer()
    {
        timeSpan += Time.deltaTime;
        if (timeSpan >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
