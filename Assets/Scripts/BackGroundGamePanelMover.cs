using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGamePanelMover : MonoBehaviour
{
    public Vector3[] points;
    public float speed;
    public float reachMagnitude = 0.2f;

    private int dest;

    // Start is called before the first frame update
    void Start()
    {
        dest = 0;

        GetPattern();
    }

    // Update is called once per frame
    void Update()
    {
        Propagation();
    }

    void GetPattern()
    {
        GetSamplePattern();
    }

    void GetSamplePattern()
    {

    }

    void Propagation()
    {
        if((points[dest] - transform.position).magnitude > reachMagnitude)
        {
            MoveToPoint(points[dest]);
        }
        else
        {
            dest++;
            dest %= points.Length;
        }
    }

    void MoveToPoint(Vector3 destination)
    {
        transform.Translate((destination - transform.position).normalized * speed * Time.deltaTime);
    }
}
