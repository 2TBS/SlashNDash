using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : MonoBehaviour {

    public enum SwipeType : int
    {
        Left,
        Right,
        Up,
        Down,
        BottomLeftDiagonal,
        TopLeftDiagonal,
        Tap
    }


    List<MinionLayer> layers = new List<MinionLayer>();

    MinionLayer topLayer;

    MinionSpawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GameObject.FindObjectOfType<MinionSpawner>();

        //Layer generation
        for(int i = 0; i < spawner.GetDifficultyRange(); i++)
            layers.Add(Instantiate((GameObject)spawner.minionPrefabs[Random.Range(0, spawner.minionPrefabs.Length)], transform.position, Quaternion.identity)
                .GetComponent<MinionLayer>()
                .Construct(i, gameObject));

    }
	
	// Update is called once per frame
	void Update () {
        try {
            topLayer = layers[layers.Count - 1];
        }
        catch {Debug.Log("No layers left");}
       
        transform.Translate(Vector2.left / 10);
	}
}