using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numShooterBuff : MonoBehaviour
{
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower() == "player")
        {
            gameManager.GetComponent<GameManager>().numShooter = 2;
            gameManager.GetComponent<GameManager>().shooterRewarded = true;
            Destroy(transform.parent.gameObject);
        }
    }
}
