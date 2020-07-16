using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttack : MonoBehaviour
{
    [Header("Shot Specification")]
    [Tooltip("Maximum level of normal shots")]
    public int maxLevel = 4;

    public int curLevel { get; private set; }

    private GameObject aimPoint;
    private PlayerDirection direction;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        aimPoint = transform.Find("NormalAimPoint").gameObject;
        direction = GetComponent<PlayerDirection>();
        controller = GetComponent<CharacterController>();
        curLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SetPointDirection();
    }

    void SetPointDirection()
    {
        float finalXDirection = direction.directionX;
        float finalYDirection = direction.directionY;

        if (controller.isGrounded)
        {
            if (finalYDirection < 0)
            {
                finalYDirection = 0f;
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

        aimPoint.transform.localPosition = new Vector3(finalXDirection, finalYDirection, 0).normalized;
    }
}
