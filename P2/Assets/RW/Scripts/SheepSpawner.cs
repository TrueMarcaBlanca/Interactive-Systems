using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{

    public bool canSpawn = true;


    public GameObject blackSheepPrefab;
    public GameObject sheepPrefab;
    
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns ;
    private List<GameObject> sheepList = new List<GameObject>();

    private int randomSheep;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        randomSheep = Random.Range(0,9);

        if(randomSheep >2)
        {
            Vector3 randomPosition = sheepSpawnPositions [Random.Range(0,sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition ,sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
        }
        else
        {
            Vector3 randomPosition = sheepSpawnPositions [Random.Range(0,sheepSpawnPositions.Count)].position;
            GameObject sheep = Instantiate(blackSheepPrefab, randomPosition ,blackSheepPrefab.transform.rotation);
            sheepList.Add(sheep);
            sheep.GetComponent<Sheep>().SetSpawner(this);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
        SpawnSheep();
        yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveSheepFromList (GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
    foreach (GameObject sheep in sheepList) // 1
    {
        Destroy(sheep); // 2
    }

    sheepList.Clear();
}

}
