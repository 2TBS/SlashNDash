using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeManager : MonoBehaviour {

    private readonly Vector2 xAxis = new Vector2(1, 0);
    private readonly Vector2 yAxis = new Vector2(0, 1);

    private const float angleRange = 30;
    
    //Swipe Speed
    private const float minVelocity = 15.0f;

    //Minimum Distance of the swipe to be detected
    private const float minSwipeDist = 2.0f;

    //Swipe specific variables
    private Vector2 swipeStartPosition;
    private float swipeStartTime;
    private Swipe.Type type;

    //Main camera for getting the swipe vector
    [SerializeField]
    private Camera mainCam;

    public Text debugText;

    ///returns the current swipe registered; returns none if no swipe detected
    public Swipe currentSwipe;

    // Use this for initialization
    void Start () {
		currentSwipe = new Swipe();
	}
	
	// Update is called once per frame
	void Update () {

        //On the finger down check
        if (Input.GetMouseButtonDown(0))
        {   
            //Set start position and time
            swipeStartPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            swipeStartTime = Time.time;

        }

        //On finger up check if it is a swipe
        if (Input.GetMouseButtonUp(0))
        {
            //Vectors
            Vector2 swipeEndPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);;
            Vector2 swipeVector = swipeEndPosition - swipeStartPosition;

            //Time Difference
            float deltaTime = Time.time - swipeStartTime;
            //Velocity of Vector
            float velocity = swipeVector.magnitude / deltaTime;

            //Make sure it is a swipe
            if(swipeVector.magnitude > minSwipeDist && velocity > minVelocity)
            {
                swipeVector.Normalize();

                float swipeAngle = Vector2.Dot(swipeVector, xAxis);
                swipeAngle = Mathf.Acos(swipeAngle) * Mathf.Rad2Deg;

                // Detect Horizontal Swipes
                if (swipeAngle < angleRange)
                {
                    Debug.Log("right");
                    debugText.text = "right";
                    type = Swipe.Type.Right;
                }
                else if ((180.0f - swipeAngle) < angleRange)
                {
                    Debug.Log("left");
                    debugText.text = "left";
                    type = Swipe.Type.Left;
                }
                else
                {
                    //Vertical Swipes!
                    swipeAngle = Vector2.Dot(swipeVector, yAxis);
                    swipeAngle = Mathf.Acos(swipeAngle) * Mathf.Rad2Deg;
                    if (swipeAngle < angleRange)
                    {
                        Debug.Log("UP");
                        debugText.text = "up";
                        type = Swipe.Type.Up;
                        
                    }
                    else if ((180.0f - swipeAngle) < angleRange)
                    {
                        Debug.Log("DOWN");
                        debugText.text = "down";
                        type = Swipe.Type.Down;
                    }
                    else
                    {
                        Debug.Log("Not a swipe!");
                        debugText.text = "rekt";
                        type = Swipe.Type.None;
                    }
                }

                ///Sets current swipe based on gathered statistics
                currentSwipe = new Swipe(swipeStartPosition, swipeEndPosition, type);

            }



        }



	}
}
