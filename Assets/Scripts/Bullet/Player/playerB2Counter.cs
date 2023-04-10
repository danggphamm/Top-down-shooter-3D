using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerB2Counter : MonoBehaviour
{
    // The game manager
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = gameManager.GetComponent<GameManager>().bulletType2Count.ToString();
    }
}
