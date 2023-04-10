using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Check if game is over/lost
    public bool gameOver = false;

    // Bullet type 1 speed
    public float playerBulletType1Speed = 1f;

    // Player bullet type
    public int playerBType = 1;

    // Player's bullet type 1
    public GameObject pBulletType1;

    // Player's bullet type 2
    public GameObject pBulletType2;

    // Number of bullet type 2 left
    public int bulletType2Count = 0;

    // Enemy type 1 speed
    public float eType1Speed;

    // Enemy type 1 attack speed/ how many attacks per second
    public float eT1AS;

    // Bullet ddestruction range
    public float bulletDestructionRange;

    // Chance to create a healthCube after destroying enemy. Unit is percentage
    public float hpCubeChance;

    // The hp cube
    public GameObject hpCube;

    // Chance to create a attack type 2 after destroying enemy. Unit is percentage
    public float bulletType2Chance;

    // The bullet type 2 reward
    public GameObject bulletType2Reward;

    public Text numbBulletType2Text;

    public GameObject bulletType2Displayer;

    public GameObject player;

    public GameObject gameOverDisplayer;

    public Text gameOverText;

    public int numShooter = 1;

    public float numShooterChance;

    public GameObject numShooterReward;

    public bool shooterRewarded = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverDisplayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerBType == 2 && bulletType2Count > 0)
        {
            bulletType2Displayer.SetActive(true);
            numbBulletType2Text.text = "X " + bulletType2Count.ToString();
        }
        else
        {
            bulletType2Displayer.SetActive(false);
        }

        if (gameOver)
        {
            gameOverDisplayer.SetActive(true);
            if(player.GetComponent<Stats>().currentHp <= 0)
            {
                gameOverText.text = "You lost!";
            }
            else
            {
                gameOverText.text = "You won!";
            }
        }
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

    public void restart()
    {
        SceneManager.LoadScene("Main");
    }
}
