using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Attach to trail object. Makes the object disappear after set amount of seconds.
public class TrailObj : MonoBehaviour {

	const int MICROSECS = 20; //Time before disappearing

	// Use this for initialization
	void Start () {
		Destroy();
	}

	void Destroy () {
		StartCoroutine(wait());
		//Destroy(gameObject);
	}

	IEnumerator wait() {
		int i = 0;
		while(i < MICROSECS) {
			i++;
			yield return new WaitForSeconds(MICROSECS/100);
		}

		Destroy(gameObject);
		yield return null;
		
	}
}
