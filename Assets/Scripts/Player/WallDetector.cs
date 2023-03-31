using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public Collision collidingObject = null;
    public bool collidingWall = false;

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        collidingObject = collision;

        if (collidingObject != null)
        {
            if (collidingObject.gameObject.tag.ToLower() == "wall")
            {
                collidingWall = true;
            }
            else
            {
                collidingWall = false;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        collidingWall = false;
        collidingObject = null;
    }
}
