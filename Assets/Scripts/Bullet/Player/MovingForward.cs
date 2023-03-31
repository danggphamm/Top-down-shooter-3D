using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    // Speed
    float speed;

    // Type
    public int type;

    // The game manager
    GameObject gameManager;

    // Starting position
    Vector3 startPos;
    public float maxRange = 100f;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player graphic");
        speed = gameManager.GetComponent<GameManager>().getTypeSpeed(type);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            transform.position += player.transform.forward*speed * Time.deltaTime;
        }

        // Destroy if flies too far
        if(Vector3.Distance(startPos,transform.position) > maxRange)
        {
            Destroy(gameObject);
        }
    }
}
