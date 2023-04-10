using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1Controller : MonoBehaviour
{
    // The game manager
    GameObject gameManager;
    // Moving speed
    float speed;
    // Range that it will stop moving down
    public float topRange = 20f;
    // Range moving left and right
    public float horizontalRange = 10f;
    int horizontalDirection;
    public GameObject bullet;
    public GameObject type3Explosion;

    public int type;

    // Attack speed/ how many attack per second
    float attackSpeed;

    //Starting position
    Vector3 startPos;

    float startTime;

    Transform bulletLocation;

    float healthCubeChance;

    GameObject hpCube;

    float bType2Chance;

    float numShooterChance;

    GameObject numShooterReward;

    GameObject bulletType2Reward;

    // Start is called before the first frame update
    void Start()
    {
        // Rotate the object 180 degreed to face the player
        // transform.Rotate(new Vector3(0, 180, 0));

        gameManager = GameObject.Find("GameManager");

        // Speed of the enemy
        speed = gameManager.GetComponent<GameManager>().eType1Speed;

        startPos = transform.position;

        // Decice the random start direction of moving left and right
        System.Random rnd = new System.Random();
        horizontalDirection = rnd.Next(2);

        // Time between attacks
        attackSpeed = gameManager.GetComponent<GameManager>().eT1AS;

        // Location to spawn bullets
        bulletLocation = transform.Find("BulletLocation");
        startTime = Time.time;

        // Add randomization
        topRange = topRange - 3 + rnd.Next(7);
        horizontalRange = horizontalRange - 2 + rnd.Next(5);
        speed = speed - 2 + rnd.Next(5);

        // chance to get health cube after being destroyed 
        healthCubeChance = gameManager.GetComponent<GameManager>().hpCubeChance;

        // health cube
        hpCube = gameManager.GetComponent<GameManager>().hpCube;

        bType2Chance = gameManager.GetComponent<GameManager>().bulletType2Chance;

        bulletType2Reward = gameManager.GetComponent<GameManager>().bulletType2Reward;

        numShooterChance = gameManager.GetComponent<GameManager>().numShooterChance;

        numShooterReward = gameManager.GetComponent<GameManager>().numShooterReward;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // At first start moving up
            if(Vector3.Distance(startPos, transform.position) < topRange)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            // Then moves left and right
            else
            {
                // Moving left
                if(horizontalDirection == 0)
                {
                    if(System.Math.Abs(startPos.x - transform.position.x) < horizontalRange)
                    {
                        transform.position += transform.right * speed * Time.deltaTime;
                    }
                    else
                    {
                        transform.position -= transform.right * speed * Time.deltaTime;
                        horizontalDirection = 1;
                    }
                }
                // Moving right
                else
                {
                    if (System.Math.Abs(startPos.x - transform.position.x) < horizontalRange)
                    {
                        transform.position -= transform.right * speed * Time.deltaTime;
                    }
                    else
                    {
                        transform.position += transform.right * speed * Time.deltaTime;
                        horizontalDirection = 0;
                    }
                }
            }

            // Shoot if passed the last shooting time x seconds
            if(Time.time - startTime > attackSpeed)
            {
                startTime = Time.time;
                GameObject bulletInstance = Instantiate(bullet, bulletLocation.position, bulletLocation.rotation);
                bulletInstance.GetComponent<EnemyBMovingForward>().direction = transform.forward;
            }

            // Destroy if hp gets lower or equal to 0
            if (gameObject.GetComponent<Stats>().currentHp <= 0)
            {
                System.Random rnd = new System.Random();

                // If falls on chance
                if (rnd.Next(101) < healthCubeChance)
                {
                    Instantiate(hpCube, bulletLocation.position, bulletLocation.rotation);
                }
                else if (rnd.Next(100) < bType2Chance)
                {
                    Instantiate(bulletType2Reward, bulletLocation.position, bulletLocation.rotation);
                }
                else if (rnd.Next(100) < numShooterChance && !gameManager.GetComponent<GameManager>().shooterRewarded)
                {
                    Instantiate(numShooterReward, bulletLocation.position, bulletLocation.rotation);
                }

                // Explode if destroyed
                if (type == 3)
                {
                    int numObjects = 12;
                    for(int i = 0; i < numObjects; i++)
                    {
                        GameObject bulletInstance = Instantiate(type3Explosion, bulletLocation.position, bulletLocation.rotation);
                        bulletInstance.GetComponent<EnemyBMovingForward>().direction = Quaternion.AngleAxis(i*360/numObjects, Vector3.up) * transform.forward;
                    }
                }

                if(gameObject.GetComponent<Stats>().maxHp > 90)
                {
                    gameManager.GetComponent<GameManager>().gameOver = true;
                }

                Destroy(gameObject);
            }
        }
    }

    // Change direction if hits walls
    private void OnTriggerEnter(Collider other)
    {
        // Change to the opposite direction if hits wall
        if (other.gameObject.tag.ToLower() == "wall")
        {
            horizontalDirection = (horizontalDirection + 1) % 2;
        }
    }
}
