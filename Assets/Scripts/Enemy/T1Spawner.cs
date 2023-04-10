using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawningRate;
    public float yPos;

    // Time to wait before start spawning
    public float waitTime;
    public int horizontalRandomization;
    float startTime;
    float lastShootingTime;
    bool isBoss = false;

    public int type;
    // The game manager
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        startTime = Time.time;
        lastShootingTime = startTime;

        // Decice the random start direction of moving left and right
        System.Random rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // If wait time is over
            if (Time.time - startTime > waitTime && !isBoss)
            {
                // If passed the last shooting time more than x seconds
                if (Time.time - lastShootingTime > spawningRate)
                {
                    lastShootingTime = Time.time;
                    // Decice the random start direction of moving left and right
                    System.Random rnd = new System.Random();

                    Vector3 newPos = new Vector3(transform.position.x - horizontalRandomization / 2 + rnd.Next(horizontalRandomization + 1), yPos, transform.position.z);
                    Instantiate(enemy, newPos, transform.rotation);
                }

                if(type == 4)
                {
                    isBoss = true;
                }
            }
        }
    }
}
