using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float speed = 50f;
    public float lifespan = 15f;
    public float damage = 50f;

    private float timer;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        GoForward();
        Timer();
    }

    void Turn()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }
    }

    void GoForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= lifespan)
        {
            Destroy(this.transform.gameObject);
        }
    }

    public void SetTarget(GameObject t)
    {
        target = t;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollideWithEnemy(collision);
        Destroy(gameObject);
    }

    private void CollideWithEnemy(Collision collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            EnemyHealth eh = collision.transform.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.Damage(damage);

                if (eh.curHP <= 0)
                {
                    ProjectileWhoShoot who = transform.GetComponent<ProjectileWhoShoot>();
                    PlayerScore ps = who.who.GetComponent<PlayerScore>();
                    ps.AddScore(100);
                }
            }
        }
    }
}
