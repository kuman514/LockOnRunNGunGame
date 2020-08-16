using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyGenerator : MonoBehaviour
{
    public float secondsPerEnemy = 1f;
    public GameObject testEnemyPrefab;
    public Transform startPoint;

    private Vector3 originalPos;

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
            originalPos = startPoint.localPosition;
            startPoint.localPosition = new Vector3(startPoint.localPosition.x, startPoint.localPosition.y + Random.Range(2f, 10f), startPoint.localPosition.z + Random.Range(-2f, 1f));
            GameObject flyingEnemy = Instantiate(testEnemyPrefab, startPoint);
            startPoint.localPosition = originalPos;

            flyingEnemy.transform.SetParent(null);
            yield return new WaitForSeconds(secondsPerEnemy);
        }
    }
}
