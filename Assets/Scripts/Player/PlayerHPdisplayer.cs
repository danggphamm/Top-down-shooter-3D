using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPdisplayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player graphic");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "HP: " + player.GetComponent<Stats>().currentHp.ToString() + "/" + player.GetComponent<Stats>().maxHp.ToString();
    }
}
