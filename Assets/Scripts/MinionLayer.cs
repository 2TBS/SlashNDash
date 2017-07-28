using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attached to each layer Prefab. Instantiated by the Minion object.
/// </summary>
public class MinionLayer : MonoBehaviour {

    const float SIZE_MULT = 0.8f;

    public Swipe.Type swipe; //to be assigned in inspector

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Makeshift constructor. Run after instantiation.
    /// </summary>
	public MinionLayer Construct(float size, GameObject parent, int layer)
    {
        transform.SetParent(parent.transform);
		//transform.localScale = Vector2.one * size * SIZE_MULT;
		if(layer == 1)
			transform.localScale = parent.transform.localScale;
		else
			transform.localScale = parent.transform.localScale * size * SIZE_MULT;
		//transform.localScale = new Vector2(parent.localScale.x, );
        return this;
     
    }
		

}
