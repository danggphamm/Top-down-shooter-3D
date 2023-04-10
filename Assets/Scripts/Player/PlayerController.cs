using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int bulletType;
    GameObject gameManager;
    GameObject bulletType1;
    GameObject bulletType2;
    Transform bulletLocation;
    Transform bulletLocation2;
    Transform bulletLocation3;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        bulletType = gameManager.GetComponent<GameManager>().playerBType;

        bulletType1 = gameManager.GetComponent<GameManager>().pBulletType1;
        bulletType2 = gameManager.GetComponent<GameManager>().pBulletType2;
        
        bulletLocation = transform.Find("BulletLocation");
        bulletLocation2 = transform.Find("BulletLocation2");
        bulletLocation3 = transform.Find("BulletLocation3");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // Shoot
            if (Input.GetKeyDown("space"))
            {
                bulletType = gameManager.GetComponent<GameManager>().playerBType;

                if (bulletType == 2 && gameManager.GetComponent<GameManager>().bulletType2Count > 0)
                {
                    gameManager.GetComponent<GameManager>().bulletType2Count--;

                    if(gameManager.GetComponent<GameManager>().bulletType2Count <= 0)
                    {
                        gameManager.GetComponent<GameManager>().playerBType = 2;
                    }

                    if(gameManager.GetComponent<GameManager>().numShooter == 1)
                    {
                        Instantiate(bulletType2, bulletLocation.position, bulletLocation.rotation);
                    }
                    else
                    {
                        Instantiate(bulletType2, bulletLocation2.position, bulletLocation2.rotation);
                        Instantiate(bulletType2, bulletLocation3.position, bulletLocation3.rotation);
                    }
                }
                else
                {
                    if (gameManager.GetComponent<GameManager>().numShooter == 1)
                    {
                        Instantiate(bulletType1, bulletLocation.position, bulletLocation.rotation);
                    }
                    else
                    {
                        Instantiate(bulletType1, bulletLocation2.position, bulletLocation2.rotation);
                        Instantiate(bulletType1, bulletLocation3.position, bulletLocation3.rotation);
                    }
                }
            }

            // Destroy if hp gets lower or equal to 0
            if (gameObject.GetComponent<Stats>().currentHp <= 0)
            {
                gameManager.GetComponent<GameManager>().gameOver = true;
                gameObject.SetActive(false);
            }
        } 
    }
}
