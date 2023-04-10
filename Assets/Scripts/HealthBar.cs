using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    GameObject healthBarOwner;
    GameObject foregroundBar;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        healthBarOwner = transform.parent.gameObject;
        foregroundBar = transform.Find("Background").transform.Find("Foreground").gameObject;
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        foregroundBar.GetComponent<Image>().fillAmount = healthBarOwner.GetComponent<Stats>().currentHp / healthBarOwner.GetComponent<Stats>().maxHp;
        //text.text = healthBarOwner.GetComponent<Stats>().currentHp.ToString() + "/" + healthBarOwner.GetComponent<Stats>().maxHp.ToString();
    }
}
