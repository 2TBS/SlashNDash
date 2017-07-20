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
		DealDamage (.01f);
		print (transform.localScale.x);
	}

	void DealDamage(float percentDamage) {
		transform.localScale = new Vector3( originalSize - (originalSize * (percentDamage / 100)), transform.localScale.y, transform.localScale.z);
	}
}
