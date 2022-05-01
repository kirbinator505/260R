using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] SpawnLocations;
    public float WaitTime;
    public GameObject[] EnemiesAlive;
    private GameObject spawnedObject;
    private WaitForSeconds wfs, lateStartWfs = new WaitForSeconds(1);
    private int spawnLoc;
    public int wave = 1;
    private bool spawning;
    public bool isFirstSpawn = true;

    private void Start()
    {
        StartCoroutine(lateStart());
    }

    IEnumerator lateStart()
    {
        yield return lateStartWfs;
        if (isFirstSpawn)
        {
            FirstSpawn();
        }
        else
        {
            setWave();
            StartCoroutine(Spawn());
        }
    }

    void FirstSpawn()
    {
        EnemiesAlive = new GameObject[1];
        wfs = new WaitForSeconds(WaitTime);
        spawnedObject = Instantiate(prefab, SpawnLocations[0]);
        EnemiesAlive[0] = spawnedObject;
        spawnedObject.transform.parent = null;
        InvokeRepeating("EnemiesCheck", 1f, 1f);
        isFirstSpawn = false;
    }

    void EnemiesCheck()
    {
        if (isArrayEmpty() && !spawning)
        {
            wave+=1;
            EnemiesAlive = new GameObject[wave];
            StartCoroutine(Spawn());
            spawning = true;
        }
    }

    IEnumerator Spawn()
    {
        yield return wfs;
        for (int i = 0; i < EnemiesAlive.Length; i++)
        {
            spawnLoc = Random.Range(0, SpawnLocations.Length - 1);
            spawnedObject = Instantiate(prefab, SpawnLocations[spawnLoc]);
            EnemiesAlive[i] = spawnedObject;
            spawnedObject.transform.parent = null;
            spawnedObject = null;
        }
        spawning = false;
    }

    private bool isArrayEmpty()
    {
        for (int i = 0; i < EnemiesAlive.Length; i++)
        {
            if (EnemiesAlive[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    private void setWave()
    {
        EnemiesAlive = new GameObject[wave];
    }

    public void ResetEnemies()
    {
        foreach (var enemy in EnemiesAlive)
        {
            Destroy(enemy.gameObject);
        }

        StopCoroutine(lateStart());
        FirstSpawn();
    }
}
