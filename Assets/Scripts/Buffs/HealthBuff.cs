using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    public float HPBuff;
    public float maxHpBuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower() == "player")
        {
            if((int)other.gameObject.GetComponent<Stats>().maxHp/5 > HPBuff)
            {
                other.gameObject.GetComponent<Stats>().currentHp += (int)other.gameObject.GetComponent<Stats>().maxHp / 5;
            }
            else
            {
                other.gameObject.GetComponent<Stats>().currentHp += HPBuff;
            }

            other.gameObject.GetComponent<Stats>().maxHp += maxHpBuff;
            Destroy(gameObject);
        }
    }
}
