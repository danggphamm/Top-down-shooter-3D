using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Check if game is over/lost
    public bool gameOver = false;

    // Bullet type 1 speed
    public float playerBulletType1Speed = 1f;

    public GameObject pBulletType1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getTypeSpeed(int type)
    {
        float typeSpeed = 0f;

        if(type == 1)
        {
            typeSpeed = playerBulletType1Speed;
        }

        return typeSpeed;
    }
}
