using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySampleFlying : MonoBehaviour
{
    public float speed = 8f;
    public Vector3 direction;

    private CharacterController ecc;

    // Start is called before the first frame update
    void Start()
    {
        ecc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Forward();
        CheckDisappear();
    }

    void Forward()
    {
        ecc.Move(direction * speed * Time.deltaTime);
    }

    void CheckDisappear()
    {
        if (transform.position.x > 30f)
        {
            Destroy(gameObject);
        }
    }
}
