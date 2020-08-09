using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public GameObject lootItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (CheckHP() && lootItem)
        {
            GameObject loot = Instantiate(lootItem, transform);
            GameObject panel = GameObject.Find("GamePanel");

            if (panel)
            {
                loot.transform.SetParent(panel.transform);
            }
            else
            {
                Destroy(loot);
            }
        }
    }

    bool CheckHP()
    {
        EnemyHealth eh = transform.GetComponent<EnemyHealth>();

        if (eh.curHP <= 0)
        {
            return true;
        }

        return false;
    }
}
