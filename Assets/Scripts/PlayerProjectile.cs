using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [Header("Player projectile info")]
    [Tooltip("Speed of this projectile")]
    public float speed = 20f;
    [Tooltip("Projectile forwarding direction")]
    public Vector3 direction;
    [Tooltip("Duration of this projectile")]
    public float lifetime = 2f;
    [Tooltip("Strength of this projectile")]
    public float damage = 10f;

    // inner active
    private float timeSpan;
    public float dmg { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        timeSpan = 0f;
        dmg = damage;
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
        CollideWithEnemy(collision);

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

    private void CollideWithEnemy(Collision col)
    {
        if (col.transform.CompareTag("Target"))
        {
            EnemyHealth eh = col.transform.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.Damage(dmg);

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
