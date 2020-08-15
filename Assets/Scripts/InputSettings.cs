using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSettings : MonoBehaviour
{
    [Header("Player 1")]
    public KeyCode P1Up = KeyCode.W;
    public KeyCode P1Down = KeyCode.S;
    public KeyCode P1Left = KeyCode.A;
    public KeyCode P1Right = KeyCode.D;
    public KeyCode P1Shot = KeyCode.R;
    public KeyCode P1Jump = KeyCode.T;
    public KeyCode P1Missile = KeyCode.Y;
    public KeyCode P1Start = KeyCode.Alpha1;

    [Header("Player 2")]
    public KeyCode P2Up = KeyCode.UpArrow;
    public KeyCode P2Down = KeyCode.DownArrow;
    public KeyCode P2Left = KeyCode.LeftArrow;
    public KeyCode P2Right = KeyCode.RightArrow;
    public KeyCode P2Shot = KeyCode.Keypad1;
    public KeyCode P2Jump = KeyCode.Keypad2;
    public KeyCode P2Missile = KeyCode.Keypad3;
    public KeyCode P2Start = KeyCode.Alpha2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
