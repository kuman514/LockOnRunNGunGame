using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public enum ItemType { NormalShotPowerUp, IncreaseCapacityOfMissiles };

    public ItemType type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            switch (type)
            {
                case ItemCollision.ItemType.NormalShotPowerUp:
                    NormalShotPowerUp(collision);
                    break;
                case ItemCollision.ItemType.IncreaseCapacityOfMissiles:
                    IncreaseCapacityOfMissiles(collision);
                    break;
            }

            Destroy(gameObject);
        }
    }

    void NormalShotPowerUp(Collider collision)
    {
        //PlayerNormalAttack pna = collision.gameObject.transform.GetComponent<PlayerNormalAttack>();
        //pna.
    }

    void IncreaseCapacityOfMissiles(Collider collision)
    {
        PlayerLockOnAttack ploa = collision.gameObject.transform.GetComponent<PlayerLockOnAttack>();
        ploa.ExtendLockOn();
    }
}
