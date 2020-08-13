using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnMarkBehavior : MonoBehaviour
{
    public float startScale = 3f;
    public float secondsToEnd = 0.05f;

    private float scale;
    private float decSpeed;

    // Start is called before the first frame update
    void Start()
    {
        scale = startScale;
        decSpeed = 1 / secondsToEnd;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseScale();
        SetTransformScale();
    }

    void DecreaseScale()
    {
        if (scale > 1f)
        {
            scale -= Time.deltaTime * decSpeed;
        }
        else
        {
            scale = 1f;
        }
    }

    void SetTransformScale()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
