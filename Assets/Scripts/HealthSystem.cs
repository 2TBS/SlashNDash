using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	public int health;
	float originalSize;

	// Use this for initialization
	void Start () {
		originalSize = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x > 0) {
			DealDamage (2f);
			//print (transform.localScale.x);
		}
	}

	void DealDamage(float percentDamage) {
		transform.localScale -= new Vector3( originalSize * (percentDamage / 100), 0, 0);
		transform.position -= new Vector3( originalSize * (percentDamage / 100) * 3.2f, 0, 0);
	}
}
