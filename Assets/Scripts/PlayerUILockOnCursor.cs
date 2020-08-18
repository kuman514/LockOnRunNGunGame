using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerUILockOnCursor : MonoBehaviour
{
    private GameObject player;
    private PlayerLockOnAttack ploa;
    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerUIContainer puic = transform.GetComponent<PlayerUIContainer>();
        player = puic.player;
        ploa = player.transform.GetComponent<PlayerLockOnAttack>();

        GameObject cursor = transform.Find("LockOnUICursor").gameObject;
        rt = cursor.transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetUIPosition();
    }

    void SetUIPosition()
    {
        if (player.activeSelf == false)
        {
            rt.transform.gameObject.SetActive(false);
        }
        else
        {
            rt.transform.gameObject.SetActive(true);
            rt.position = ploa.lockonCursorPos;
        }
    }
}
