using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIShowScore : MonoBehaviour
{
    private GameObject player;
    private PlayerScore ps;
    private Text curScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerUIContainer puic = transform.GetComponent<PlayerUIContainer>();
        player = puic.player;
        ps = player.transform.GetComponent<PlayerScore>();

        GameObject scoreUI = transform.Find("Score").gameObject;
        curScoreTxt = scoreUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    void ShowScore()
    {
        curScoreTxt.text = ps.score.ToString();
    }
}
