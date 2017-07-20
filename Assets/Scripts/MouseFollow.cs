using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Makes a trail where players are swiping
public class MouseFollow : MonoBehaviour {

	public GameObject trailObj; //Object to instantiate
	public Camera mainCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0)) {
			Debug.Log("Mouse held");
			Instantiate(trailObj, mainCam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,20), Quaternion.identity);
		}
	}
}
