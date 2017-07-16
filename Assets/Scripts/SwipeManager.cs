using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeManager : MonoBehaviour {

    private readonly Vector2 xAxis = new Vector2(1, 0);
    private readonly Vector2 yAxis = new Vector2(0, 1);

    private const float angleRange = 30;
    
    //Swipe Speed
    private const float minVelocity = 1500.0f;

    //Minimum Distance of the swipe to be detected
    private const float minSwipeDist = 50.0f;

    //Swipe specific variables
    private Vector2 swipeStartPosition;
    private float swipeStartTime;

    public Text debugText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //On the finger down check
        if (Input.GetMouseButtonDown(0))
        {
            //Set start position and time
            swipeStartPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            swipeStartTime = Time.time;

        }

        //On finger up check if it is a swipe
        if (Input.GetMouseButtonUp(0))
        {
            //Vectors
            Vector2 swipeEndPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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
                }
                else if ((180.0f - swipeAngle) < angleRange)
                {
                    Debug.Log("left");
                    debugText.text = "left";
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
                        CameraShake.Shake(0.25f, 0.4f);
                    }
                    else if ((180.0f - swipeAngle) < angleRange)
                    {
                        Debug.Log("DOWN");
                        debugText.text = "down";
                    }
                    else
                    {
                        Debug.Log("Not a swipe!");
                        debugText.text = "rekt";
                    }
                }



            }



        }



	}
}
