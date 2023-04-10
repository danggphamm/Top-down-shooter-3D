using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBullet : MonoBehaviour
{
    public float shootingTime;
    // Scaling up rate. Percentage unit
    public float scalingRate = 1f;
    public Transform bulletLocation;
    public Vector3 direction;
    public float speed;
    public float scalingRateIncreaseAfterShoot = 5;

    // The game manager
    GameObject gameManager;

    bool setDirection = false;
    float startTime;
    Vector3 startPos;
    float maxRange;

    Vector3 firstScale;
    // Start is called before the first frame update
    void Start()
    {
        firstScale = transform.localScale;

        startTime = Time.time;
        gameManager = GameObject.Find("GameManager");
        maxRange = gameManager.GetComponent<GameManager>().bulletDestructionRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-startTime < shootingTime)
        {
            transform.position = bulletLocation.position;
        }
        else
        {
            if (!setDirection)
            {
                direction = bulletLocation.forward;
                startPos = transform.position;
                scalingRate = scalingRate * scalingRateIncreaseAfterShoot;
                setDirection = true;
                bulletLocation.gameObject.GetComponent<ShieldAttack>().initialized = false;
            }

            transform.position -= direction * speed * Time.deltaTime;
        }

        // Destroy if flies too far
        if (setDirection && Vector3.Distance(startPos, transform.position) > maxRange)
        {
            Destroy(gameObject);
        }

        transform.localScale += firstScale * scalingRate / 100f;
    }
}
