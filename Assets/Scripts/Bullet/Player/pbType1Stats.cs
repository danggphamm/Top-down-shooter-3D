using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pbType1Stats : MonoBehaviour
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
        if(other.gameObject.tag.ToLower() == "enemy")
        {
            if(other.gameObject.GetComponent<Stats>() != null)
            {
                other.gameObject.GetComponent<Stats>().currentHp -= damage;
            }
            Destroy(gameObject);
        }
    }
}
