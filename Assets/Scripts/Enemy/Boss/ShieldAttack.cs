using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttack : MonoBehaviour
{
    public GameObject shieldBullet;
    public bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bulletInstance = Instantiate(shieldBullet, transform.position, transform.rotation);
        bulletInstance.GetComponent<ShieldBullet>().bulletLocation = transform;
        initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            GameObject bulletInstance = Instantiate(shieldBullet, transform.position, transform.rotation);
            bulletInstance.GetComponent<ShieldBullet>().bulletLocation = transform;
            initialized = true;
        }
    }
}
