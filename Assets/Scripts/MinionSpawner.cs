using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

	public Object[] minionPrefabs;
	public List<GameObject> spawnedMinions;

	bool spawned;

	public int SPAWN_DISTANCE = 15;
	// Use this for initialization
	void Start () {
		minionPrefabs = Resources.LoadAll("Enemies/", typeof(GameObject));

        StartCoroutine(Spawn());

	}
	
	// Update is called once per frame
	void Update () {

	}

    //Coroutine that runs everytime a minion is needed to be spawned
    public IEnumerator Spawn() {
        while(true)
        {
            spawnedMinions.Add(Instantiate((GameObject)minionPrefabs[Random.Range(0, minionPrefabs.Length)], new Vector2(10, Random.Range(-5, 5)), Quaternion.identity));
            yield return new WaitForSeconds(2);
        }
       
    }
}
