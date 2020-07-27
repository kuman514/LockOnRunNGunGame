using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerLockOnUICursor : MonoBehaviour
{
    public GameObject player;

    private PlayerLockOnAttack pla;
    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        pla = player.transform.GetComponent<PlayerLockOnAttack>();
        rt = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetUIPosition();
    }

    void SetUIPosition()
    {
        rt.position = pla.lockonCursorPos;
    }
}
