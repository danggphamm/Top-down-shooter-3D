using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour
{
    public bool collidingWall = false;

    public GameObject characterGraphic;

    public GameObject wallDetector;
    
    // Speed
    public float speed;

    // Check if mouse clicked
    bool clicked = false;

    // Check if game is over/lost
    bool gameOver = false;

    Vector3 lastPos = Vector3.zero;
    Vector3 lastDir = Vector3.zero;


    // The coordinate where the mouse clicked
    Vector3 mouseInitialPos = Vector3.zero;
    Vector3 dir = Vector3.zero;

    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = gameManager.GetComponent<GameManager>().gameOver;

        if (!gameOver)
        {
            if (Input.GetMouseButton(0))
            {
                if (!clicked)
                {
                    clicked = true;
                    mouseInitialPos = Input.mousePosition;
                }

                // Direction the mouse dragging to
                dir = mouseInitialPos - Input.mousePosition;

                // Direction in 2D
                Vector3 twoDdirection = new Vector3(dir.x, 0, dir.y);

                twoDdirection.Normalize();

                // Rotate the character to the goinVector3.zerog direction
                //if (Vector3.zero - twoDdirection != Vector3.zero)
                //{
                //    Quaternion rotation = Quaternion.LookRotation(Vector3.zero - twoDdirection, Vector3.up);
                //    characterGraphic.transform.rotation = rotation;
                //}

                if (!wallDetector.GetComponent<WallDetector>().collidingWall)
                {
                    lastPos = transform.position;
                    characterGraphic.transform.position -= twoDdirection * speed*Time.deltaTime;
                    //Debug.Log("Pressed");
                }
                else
                {
                    characterGraphic.transform.position = lastPos;
                    characterGraphic.transform.position -= twoDdirection * speed * Time.deltaTime;
                }
            }
            else
            {
                // Refresh the variables after releasing the mouse
                clicked = false;
                mouseInitialPos = Vector3.zero;
                dir = Vector3.zero;
                //GetComponent<Rigidbody>().velocity = Vector3.zero;
                //Debug.Log("Not pressed");
            }
        }
    }
}
