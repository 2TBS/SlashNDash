using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : MonoBehaviour {

[SerializeField]
    List<MinionLayer> layers = new List<MinionLayer>();
[SerializeField]
    MinionLayer topLayer;
[SerializeField]
    MinionSpawner spawner;
[SerializeField]
    SwipeManager swipeMan;

	// Use this for initialization
	void Start () {
        spawner = GameObject.FindObjectOfType<MinionSpawner>();
        swipeMan = GameObject.FindObjectOfType<SwipeManager>();
        //Layer generation
		int difficulty = spawner.GetDifficultyRange();
		for (int i = difficulty; i > 0; i--)
			layers.Add (Instantiate ((GameObject)spawner.minionPrefabs [Random.Range (0, spawner.minionPrefabs.Length)], transform.position, Quaternion.identity)
               .GetComponent<MinionLayer> ()
               .Construct (i, gameObject, difficulty));
    }

    public GameObject Construct(GameObject spawnObj) {
        spawner = spawnObj.GetComponent<MinionSpawner>();
        swipeMan = spawnObj.GetComponent<SwipeManager>();

        return gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        foreach(MinionLayer layer in layers) {
            layer.gameObject.setActive(true);
        }
        
        try {
            topLayer = layers[layers.Count - 1];
        }
        catch {Debug.Log("No layers left");}
       
        transform.Translate(Vector2.left / 10);

        Debug.Log(swipeMan.currentSwipe);

        if(swipeMan.currentSwipe.swipeType == topLayer.swipe) {
            layers.Remove(topLayer);
            Destroy(topLayer);
            Debug.Log("Good Swipe Detected");
        }
        
        if(transform.position.x < -10 || layers.Count == 0) {
            //REMOVE HEALTH HERE!
            Destroy(gameObject);
            // CameraShake.Shake(0.2f,0.25f); REENABLE LATER
        }
        
           
	}
}