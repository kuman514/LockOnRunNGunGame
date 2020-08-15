using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUILockOnMark : MonoBehaviour
{
    public int curMarks { get; private set; }

    private PlayerLockOnAttack ploa;

    private List<GameObject> markedEnemies;
    private List<GameObject> marks;

    public GameObject LockOnMark;

    // Start is called before the first frame update
    void Start()
    {
        ploa = transform.GetComponent<PlayerLockOnAttack>();
        markedEnemies = new List<GameObject>();
        marks = new List<GameObject>();
        curMarks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TakeNullMarks();
        CountCurrentMarks();
        PaintMark();
    }

    void TakeNullMarks()
    {
        for (int i = 0; i < markedEnemies.Count; i++)
        {
            if (markedEnemies[i] == null)
            {
                DeleteMark(markedEnemies[i]);
            }
        }
    }

    void CountCurrentMarks()
    {
        curMarks = marks.Count;
    }

    public void PaintMark()
    {
        for (int i = 0; i < markedEnemies.Count; i++)
        {
            if (markedEnemies[i] == null)
            {
                continue;
            }

            Vector3 curpos = markedEnemies[i].transform.position;
            EnemyUILockOnMark elom = markedEnemies[i].GetComponent<EnemyUILockOnMark>();
            marks[i].transform.position = new Vector3(curpos.x, curpos.y, curpos.z - elom.hoverDistance);
        }
    }

    public void CreateMark(GameObject created)
    {
        markedEnemies.Add(created);

        GameObject lockonMark = Instantiate(LockOnMark);
        lockonMark.transform.SetParent(null);
        marks.Add(lockonMark);
    }

    public void DeleteMark(GameObject removed)
    {
        markedEnemies.Remove(removed);
        Destroy(marks[0]);
        marks.RemoveAt(0);
        ploa.RemoveNullLockOn(removed);
    }
}
