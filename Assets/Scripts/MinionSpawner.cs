using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {

	public Object[] minionPrefabs;
    public GameObject minionTemplate;
	public List<GameObject> spawnedMinions;

	bool spawned;

	public int SPAWN_DISTANCE = 15;
	// Use this for initialization
	void Start () {
        ///the MinionLayer prefab list
		minionPrefabs = Resources.LoadAll("Enemies/", typeof(GameObject));
        minionTemplate = Resources.Load("MinionTemplate", typeof(GameObject)) as GameObject;

        StartCoroutine(Spawn());

	}
	
	// Update is called once per frame
	void Update () {

	}

    //Coroutine that runs everytime a minion is needed to be spawned
    public IEnumerator Spawn() {
        while(true)
        {
            spawnedMinions.Add(Instantiate(minionTemplate, new Vector2(10, Random.Range(-4, 4)), Quaternion.identity));
            yield return new WaitForSeconds(2);
        }
       
    }

    ///Gets a random number based on the difficulty index
    public int GetDifficultyRange()
    {
        return 1; //TODO
    }
}
