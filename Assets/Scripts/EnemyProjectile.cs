using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 direction = new Vector3(1f, 0f, 0f);
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GoForward();
    }

    void GoForward()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // effect when a Player killed

            collision.gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // effect when a Player killed

            collision.gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }
}
