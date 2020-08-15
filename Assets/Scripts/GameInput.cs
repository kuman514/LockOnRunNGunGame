using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputSettings iset;

    public static KeyCode[] Up;
    public static KeyCode[] Down;
    public static KeyCode[] Left;
    public static KeyCode[] Right;
    public static KeyCode[] Shot;
    public static KeyCode[] Jump;
    public static KeyCode[] Missile;
    public static KeyCode[] StartButton;

    // Start is called before the first frame update
    void Start()
    {
        iset = GetComponent<InputSettings>();
        RefreshInputSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshInputSettings()
    {
        Up = new KeyCode[] { iset.P1Up, iset.P2Up };
        Down = new KeyCode[] { iset.P1Down, iset.P2Down };
        Left = new KeyCode[] { iset.P1Left, iset.P2Left };
        Right = new KeyCode[] { iset.P1Right, iset.P2Right };
        Shot = new KeyCode[] { iset.P1Shot, iset.P2Shot };
        Jump = new KeyCode[] { iset.P1Jump, iset.P2Jump };
        Missile = new KeyCode[] { iset.P1Missile, iset.P2Missile };
        StartButton = new KeyCode[] { iset.P1Start, iset.P2Start };
    }

    public static float GetHorizontal(int pCode)
    {
        float total = 0f;

        if (Input.GetKey(Left[pCode]))
        {
            total -= 1f;
        }

        if (Input.GetKey(Right[pCode]))
        {
            total += 1f;
        }

        return total;
    }

    public static float GetVertical(int pCode)
    {
        float total = 0f;

        if (Input.GetKey(Down[pCode]))
        {
            total -= 1f;
        }

        if (Input.GetKey(Up[pCode]))
        {
            total += 1f;
        }

        return total;
    }

    public static bool GetFire(int pCode)
    {
        return Input.GetKey(Shot[pCode]);
    }

    public static bool GetJump(int pCode)
    {
        return Input.GetKeyDown(Jump[pCode]);
    }

    public static bool GetMissle(int pCode)
    {
        return Input.GetKeyDown(Missile[pCode]);
    }

    public static bool GetStart(int pCode)
    {
        return Input.GetKeyDown(StartButton[pCode]);
    }
}
