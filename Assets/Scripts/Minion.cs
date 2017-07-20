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

        Debug.Log(swipeMan.currentSwipe);
        if(swipeMan.currentSwipe.Contains(transform.position, topLayer.transform.localScale.x) && swipeMan.currentSwipe.swipeType == topLayer.swipe) {
            
            layers.Remove(topLayer);
            Destroy(topLayer);
            Debug.Log("Good Swipe Detected");
        }

        if(transform.position.x < -15 || layers.Count == 0) {
            Destroy(gameObject);
            CameraShake.Shake(0.2f,0.25f);
        }
           
	}
}