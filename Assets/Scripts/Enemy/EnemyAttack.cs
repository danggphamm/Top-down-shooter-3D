﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;

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
            other.gameObject.GetComponent<Stats>().currentHp -= damage;
            Destroy(gameObject);
        }
    }
}
