using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Ground Specification")]
    [Tooltip("Ground speed")]
    public float speed = 6f;
    [Tooltip("Ground speed divisor if crouch")]
    [Range(1f, 10f)]
    public float crouchSpeedDivisor = 3f;
    [Tooltip("Jump force")]
    public float jumpSpeedF = 10f;
    [Tooltip("Gravity on this character")]
    public float gravity = 10f;

    private CharacterController controller;
    private Vector3 MoveDir;
    private PlayerState playerState;
    private GameObject collisionRange;

    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
        collisionRange = transform.Find("CollisionRange").gameObject;
    }

    void Update()
    {
        switch(playerState.playerState)
        {
            case PlayerState.State.Ground:
                GroundMovement();
                break;
            case PlayerState.State.Airborne:
                AirborneMovement();
                break;
            case PlayerState.State.Parachute:
                ParachuteMovement();
                break;
        }
    }

    void GroundMovement()
    {
        MoveDir.x = Input.GetAxisRaw("Horizontal");
        MoveDir.x *= speed;

        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
                MoveDir.y = jumpSpeedF;

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                collisionRange.transform.localPosition = new Vector3(0, -0.25f, collisionRange.transform.localPosition.z);
                MoveDir.x /= crouchSpeedDivisor;
            }
            else
            {
                collisionRange.transform.localPosition = new Vector3(0, 0, collisionRange.transform.localPosition.z);
            }
        }
        else
        {
            collisionRange.transform.localPosition = new Vector3(0, 0, collisionRange.transform.localPosition.z);
        }

        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);
    }

    void AirborneMovement()
    {
        MoveDir.x = Input.GetAxisRaw("Horizontal");
        MoveDir.x *= speed;

        MoveDir.y = Input.GetAxisRaw("Vertical");
        MoveDir.y *= speed;

        controller.Move(MoveDir * Time.deltaTime);
    }

    void ParachuteMovement()
    {
        MoveDir.x = Input.GetAxisRaw("Horizontal");
        MoveDir.x *= speed;

        MoveDir.y = Input.GetAxisRaw("Vertical");
        MoveDir.y *= speed;

        controller.Move(MoveDir * Time.deltaTime);
    }
}
