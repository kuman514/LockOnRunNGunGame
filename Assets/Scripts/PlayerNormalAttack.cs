﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttack : MonoBehaviour
{
    [Header("Shot Specification")]
    [Tooltip("Maximum level of normal shots")]
    public int maxLevel = 4;
    public float roundsPerSecond = 10f;
    public GameObject projectilePrefab;
    public float[] shotDirections;

    public int curLevel { get; private set; }

    private GameObject aimPoint;
    private GameObject collisionRange;
    private PlayerDirection direction;
    private CharacterController controller;

    private int shotSeq;
    private float secondsPerRound;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        aimPoint = transform.Find("NormalAimPoint").gameObject;
        collisionRange = transform.Find("CollisionRange").gameObject;
        direction = GetComponent<PlayerDirection>();
        controller = GetComponent<CharacterController>();

        curLevel = 1;
        shotSeq = 0;

        secondsPerRound = 1 / roundsPerSecond;
        fireTimer = secondsPerRound;
    }

    // Update is called once per frame
    void Update()
    {
        SetPointDirection();
        Fire();
        ProgressTimer();
    }

    void SetPointDirection()
    {
        float finalXDirection = direction.directionX;
        float finalYDirection = direction.directionY;

        if (controller.isGrounded)
        {
            if (finalYDirection < 0)
            {
                finalYDirection = -0.25f;
                finalXDirection = direction.idleX;
            }
            else if (finalYDirection > 0)
            {
                finalXDirection = 0f;
            }
        }
        else
        {
            if (finalYDirection != 0)
            {
                finalXDirection = 0f;
            }
        }

        aimPoint.transform.localPosition = new Vector3(finalXDirection, finalYDirection, 0);
    }

    void Fire()
    {
        if (isFireable() && Input.GetButton("Fire1"))
        {
            Vector3 shootDirection = aimPoint.transform.position - collisionRange.transform.position;
            GameObject projectile = Instantiate(projectilePrefab, aimPoint.transform);
            PlayerProjectile pp = projectile.transform.gameObject.GetComponent<PlayerProjectile>();
            ProjectileWhoShoot who = projectile.transform.GetComponent<ProjectileWhoShoot>();
            who.who = transform.gameObject;

            if (shootDirection.x == 0)
            {
                shootDirection.x += shotDirections[shotSeq];
            }
            else if (shootDirection.y == 0)
            {
                shootDirection.y += shotDirections[shotSeq];
            }

            shotSeq++;
            shotSeq = shotSeq % shotDirections.Length;

            pp.direction = shootDirection.normalized;

            projectile.transform.SetParent(null);
            fireTimer = 0f;
        }
    }

    void ProgressTimer()
    {
        if (fireTimer < secondsPerRound)
        {
            fireTimer += Time.deltaTime;
        }
    }

    bool isFireable()
    {
        return (fireTimer >= secondsPerRound);
    }
}
