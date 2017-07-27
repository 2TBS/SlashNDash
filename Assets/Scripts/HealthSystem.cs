//Omar Hossain
//7-19-17

//HealthSystem.cs
//This is where the health is regulated and where 
//Health is changed. This script will be attatched
//to the red rectangle(the healthbar).

// NOTE: IF YOU WANT TO CHANGE THE HEALTH, YOU MUST USE THE TWO METHODS
// DEALDAMAGE/REPLENISHHEALTH. THE VAR HEALTH IS NOT CONNECTED DIRECTLY
// TO THE SCALE OF THE HEALTH BAR.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {


	//	WHEN TESTING, DON'T MAKE BOTH TRUE!
	public bool testReplenish;// Tick this for testing health
	public bool testDamage;// Tick this for testing damage

	public float health;//	Though this is a float, never use decimals
						//		Keep health a int so it doesn't confuse
						//		the player. The health range is 0-100
	float originalSize;//	The original size of the red rectangle when
						//		It is initialized into the scene. This will
						//		be used to change the size when health is 
						//		depleted/increased

	// Use this for initialization
	void Start () {
		originalSize = this.transform.localScale.x;//	Set originalSize to initial
													//		size of the red rectangle health bar
		if (testReplenish) {
			DealDamage (100f);
		}
	}
	
	// Update is called once per frame
	// We might have to update this method to change the "once per frame" bit
	void Update () {

		// This code block is just for testing
		if (testDamage && health > 0) {
			DealDamage (2f);//	Deal 2 damage per update call
			print (health);//	Print current health
		}

		if (testReplenish && health < 100) {
			ReplenishHealth (2f);//	Replenish 2 health per update call
			print (health);//	Print current health
		}


	}

	// Deals damage acccording to the number that is passed in. For example, 5 will do 5 damage, subtracting 5 from the health var.
	// This method will also update the localscale of the healthbar so it is depleated
	// It will also move the health bar left when damage is dealth so the health bar doesn't
	// Look like it is closing in on itself
	public void DealDamage(float percentDamage) {
		transform.localScale -= new Vector3( originalSize * (percentDamage / 100), 0, 0); // Change scale of healthbar
		transform.position -= new Vector3( originalSize * (percentDamage / 100) * 3.2f, 0, 0);// Change position of healthbar
		health -= percentDamage;// Subtract health according to passed in percentDamage
	}

	// Replenishes health acccording to the number that is passed in. For example, 5 will replenish 5 health, adding 5 from the health var.
	// This method will also update the localscale of the healthbar so it is increased
	// It will also move the health bar right when health is replenished so the health bar doesn't
	// Look like it is expanding out in two directions
	public void ReplenishHealth(float percentHealth) {
		transform.localScale += new Vector3( originalSize * (percentHealth / 100), 0, 0); // Change scale of healthbar
		transform.position += new Vector3( originalSize * (percentHealth / 100) * 3.2f, 0, 0);// Change position of healthbar
		health += percentHealth;// Add health according to passed in percentHealth
	}
}
