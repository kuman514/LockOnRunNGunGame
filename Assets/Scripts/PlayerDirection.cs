using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public int directionX { get; private set; }
    public int directionY { get; private set; }
    public int idleX { get; private set; }

    private int pCode;

    // Start is called before the first frame update
    void Start()
    {
        directionX = 1;
        idleX = 1;
        directionY = 0;
        pCode = transform.GetComponent<PlayerState>().playerCode;
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionFromInput();
    }

    void GetDirectionFromInput()
    {
        float inputValX = GameInput.GetHorizontal(pCode);
        float inputValY = GameInput.GetVertical(pCode);

        if (inputValX < 0)
        {
            idleX = -1;
            directionX = -1;
        }
        else if(inputValX > 0)
        {
            idleX = 1;
            directionX = 1;
        }

        if (inputValY < 0)
        {
            directionY = -1;
            if(inputValX == 0)
            {
                directionX = 0;
            }
        }
        else if (inputValY > 0)
        {
            directionY = 1;
            if (inputValX == 0)
            {
                directionX = 0;
            }
        }
        else
        {
            directionY = 0;
            directionX = idleX;
        }
    }
}
