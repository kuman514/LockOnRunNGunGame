using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Ground Specification")]
    [Tooltip("Ground speed")]
    public float speed = 6f;
    [Tooltip("Jump force")]
    public float jumpSpeedF = 10f;
    [Tooltip("Gravity on this character")]
    public float gravity = 10f;

    private CharacterController controller;
    private Vector3 MoveDir;
    private PlayerState playerState;

    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
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
