using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to each layer Prefab. Instantiated by the Minion object.
/// </summary>
public class MinionLayer : MonoBehaviour {

    const float SIZE_MULT = 1.5f;

    public Minion.SwipeType swipe; //to be assigned in inspector

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Makeshift constructor. Run after instantiation.
    /// </summary>
    public MinionLayer Construct(int size, GameObject parent)
    {
        transform.SetParent(parent.transform);
        transform.localScale = Vector2.one * (size+1) * SIZE_MULT;

        return this;
     
    }
}
