using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	Canvas ui;

	// Use this for initialization
	void Start () {
		ui = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) ui.enabled = false;

	}

}
