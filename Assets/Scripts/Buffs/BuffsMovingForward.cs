using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsMovingForward : MonoBehaviour
{
    // Speed
    float speed;

    public float localSpeed;

    // The game manager
    GameObject gameManager;

    // Starting position
    Vector3 startPos;
    float maxRange;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player graphic");

        speed = localSpeed;

        maxRange = gameManager.GetComponent<GameManager>().bulletDestructionRange;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            // Move forward
            if (!gameManager.GetComponent<GameManager>().gameOver)
            {
                transform.position -= player.transform.forward * speed * Time.deltaTime;

                // Destroy if flies too far
                if (Vector3.Distance(startPos, transform.position) > maxRange)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
