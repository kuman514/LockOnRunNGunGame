using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool hasReachedToPanel;
    private Vector3 reachPoint;
    private Vector3 reachPoint2;

    // Start is called before the first frame update
    void Start()
    {
        hasReachedToPanel = false;
        reachPoint = new Vector3(0f, 2f, -0.3f);
        reachPoint = new Vector3(0f, 2f, 0f);
        CheckReachedToPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasReachedToPanel)
        {
        }
        else
        {
            MoveToGamePanel();
            CheckReachedToPanel();
        }
    }

    void MoveToGamePanel()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, reachPoint, Time.deltaTime);
    }

    void CheckReachedToPanel()
    {
        if (-0.1f < transform.localPosition.z && transform.localPosition.z < 0.1f)
        {
            hasReachedToPanel = true;
        }
    }
}
