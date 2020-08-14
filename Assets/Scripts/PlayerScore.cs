using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public decimal score { get; private set; }
    private int continues;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        continues = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(decimal point)
    {
        score += point;
    }

    public void ContinueResetScore()
    {
        continues++;

        if (continues >= 9)
        {
            score = 9;
        }
        else
        {
            score = continues;
            //score++;
        }
    }
}
