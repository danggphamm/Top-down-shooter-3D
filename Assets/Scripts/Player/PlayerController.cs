using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject gameManager;
    GameObject bulletType1;
    GameObject bulletLocation;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        bulletType1 = gameManager.GetComponent<GameManager>().pBulletType1;
        bulletLocation = GameObject.Find("BulletLocation");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !gameManager.GetComponent<GameManager>().gameOver)
        {
            Instantiate(bulletType1, bulletLocation.transform.position, bulletLocation.transform.rotation);
        }
    }
}
