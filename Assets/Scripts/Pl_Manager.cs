using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Normal,
    Hit,
    Dead
}

public class Pl_Manager : MonoBehaviour {

    //Basic Player Variables
    private int health  = 100;
    private State currState = State.Normal;

	void Start () {
		
	}
	
	void Update () {
        //Check if dead
		if(currState == State.Dead)
        {
            //do something related to being dead
        }
        else if(currState == State.Hit)
        {
            //Play the animation and vibrate and a lot more



            //Reset back to normal state so we dont keep playing animations xD
            currState = State.Normal;
        }
        else
        {
            //Nothing happened in between
        }


	}

    /// <summary>
    /// Applys a certain amount of damage
    /// </summary>
    /// <param name="damage"></param>
    public void damageApply(int damage)
    {
        
        health -= damage;
        if(health <= 0)
        {
            currState = State.Dead;
        }
        else
        {
            currState = State.Hit;
        }

    }

    public int getHealth()
    {
        return health;
    }

    public void resetPlayer()
    {
        //Resetting to default
        health = 100;
        currState = State.Normal;

    }
}
