using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BType2Buff : MonoBehaviour
{
    public int numBullet;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower() == "player")
        {
            gameManager.GetComponent<GameManager>().playerBType = 2;
            gameManager.GetComponent<GameManager>().bulletType2Count = numBullet;
            Destroy(transform.parent.gameObject);
        }
    }
}