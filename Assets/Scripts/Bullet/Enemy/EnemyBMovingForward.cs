using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBMovingForward : MonoBehaviour
{
    // Speed
    public float speed;

    // The game manager
    GameObject gameManager;

    // Starting position
    Vector3 startPos;
    float maxRange;
    GameObject player;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player graphic");
        startPos = transform.position;
        maxRange = gameManager.GetComponent<GameManager>().bulletDestructionRange;
        // direction = player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            transform.position -= direction * speed * Time.deltaTime;

            // Destroy if flies too far
            if (Vector3.Distance(startPos, transform.position) > maxRange)
            {
                Destroy(gameObject);
            }
        }
    }
}
