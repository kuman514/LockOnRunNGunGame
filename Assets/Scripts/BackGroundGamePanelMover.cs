using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGamePanelMover : MonoBehaviour
{
    public Vector3[] points;
    public float speed;
    public float reachMagnitude = 0.2f;

    private int dest;
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        dest = 0;
        panel = GameObject.Find("GamePanel");

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
        if((points[dest] - panel.transform.position).magnitude > reachMagnitude)
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
        panel.transform.Translate((destination - panel.transform.position).normalized * speed * Time.deltaTime);
    }
}
