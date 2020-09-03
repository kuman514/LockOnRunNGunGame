using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUILife : MonoBehaviour
{
    [Range(0, 1)]
    public int playerCode;
    public GameObject panel;

    private int pCode;
    private PlayerLifeSystem pls;
    private Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        pCode = playerCode;

        pls = panel.GetComponent<PlayerLifeSystem>();

        GameObject lifeUI = transform.Find("Remaining").gameObject;
        lifeText = lifeUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pCode == 0)
        {
            if (pls.P1Left < 0)
            {
                lifeText.text = "PUSH P1 START";
            }
            else
            {
                lifeText.text = "LEFT " + pls.P1Left;
            }
        }

        if (pCode == 1)
        {
            if (pls.P2Left < 0)
            {
                lifeText.text = "PUSH P2 START";
            }
            else
            {
                lifeText.text = "LEFT " + pls.P2Left;
            }
        }
    }
}
