using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContinue : MonoBehaviour
{
    public int continueCount = 20;

    public int count { get; private set; }
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Beep();
        Countdown();
    }

    void Timer()
    {
        timer += Time.deltaTime;
    }

    void Beep()
    {
        if (timer >= 1f)
        {

        }
    }

    void Countdown()
    {
        if (timer >= 1f)
        {
            timer = 0f;
            count--;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
        count = continueCount;
        timer = 1f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        timer = 0f;
    }
}
