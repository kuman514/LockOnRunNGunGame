using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyGenerator : MonoBehaviour
{
    public float secondsPerEnemy = 1f;
    public GameObject testEnemyPrefab;
    public Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateSampleEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateSampleEnemy()
    {
        while(true)
        {
            GameObject flyingEnemy = Instantiate(testEnemyPrefab, startPoint);
            flyingEnemy.transform.SetParent(null);
            yield return new WaitForSeconds(secondsPerEnemy);
        }
    }
}
