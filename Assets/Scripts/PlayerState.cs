using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State { Ground, Airborne, Parachute }

    public State playerState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerState = State.Ground;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
