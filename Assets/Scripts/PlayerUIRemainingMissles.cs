using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIRemainingMissles : MonoBehaviour
{
    private GameObject player;
    private PlayerLockOnAttack ploa;
    private Text remainingMissiles;

    // Start is called before the first frame update
    void Start()
    {
        PlayerUIContainer puic = transform.GetComponent<PlayerUIContainer>();
        player = puic.player;
        ploa = player.transform.GetComponent<PlayerLockOnAttack>();

        GameObject remainUI = transform.Find("RemainingMissiles").gameObject;
        remainingMissiles = remainUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CountRemainingMissiles();
    }

    void CountRemainingMissiles()
    {
        remainingMissiles.text = ploa.curLockOn + " / " + ploa.curMissiles;
    }
}
