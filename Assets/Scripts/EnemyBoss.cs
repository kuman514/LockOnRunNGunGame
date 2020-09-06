using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public GameObject background { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBG(GameObject bg)
    {
        background = bg;
    }

    void SetDestroyed()
    {
        BackgroundSequence bgs = background.GetComponent<BackgroundSequence>();
        bgs.BossDestroyed();
    }

    private void OnDestroy()
    {
        SetDestroyed();
    }
}
