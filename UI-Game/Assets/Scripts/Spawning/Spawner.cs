using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject redPacmanPrefab;

    [SerializeField]
    GameObject greenPacmanPrefab;

    //[SerializeField]
    //int  minEnemiesSpawned = 1;

    [SerializeField]
    int maxEnemiesSpawned = 1;

    [SerializeField]
    float minSpawnDelay = .5f;

    [SerializeField]
    float maxSpawnDelay = 2f;

    [SerializeField]
    List<Transform> spawnPoints;

    List<GameObject> spawnedPacmen = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnPacman();
    }

    // This method will decide whether or not to spawn based on current # of pacmen in scene
    void Spawn()
    {
        StopCoroutine("SpawnTimer");

        // We are at our maximum, don't spawn any more, but still reset the timer
        if (spawnedPacmen.Count < maxEnemiesSpawned)
        {
            StartCoroutine("SpawnTimer");
        }
    }

    void SpawnPacman()
    {
        GameObject pacman = Instantiate(SelectPacman(), SpawnPoint(), Quaternion.identity, null);

        pacman.GetComponent<Unit>().target = GameObject.FindGameObjectWithTag("Player").transform;

        // Adds this script as a listener for pacman death
        pacman.GetComponent<Pacman>().AddPacmanDeathListener(HandlePacmanDeaths);

        // Add the instantiated pacman to the list
        spawnedPacmen.Add(pacman);

        Spawn();
    }

    void HandlePacmanDeaths(GameObject pacman, int pointValue)
    {
        spawnedPacmen.Remove(pacman);
        StartCoroutine(KillPacman(pacman));

    }

    IEnumerator KillPacman(GameObject pacman)
    {
        yield return new WaitForSeconds(.1f);
        Destroy(pacman);
        Spawn();
    }

    Vector3 SpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)].position;
    }

    GameObject SelectPacman()
    {
        GameObject pacman = (Random.Range(0f, 1f) > .5f) ? redPacmanPrefab : greenPacmanPrefab;
        return pacman;
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        SpawnPacman();

        yield return null;
    }
}

