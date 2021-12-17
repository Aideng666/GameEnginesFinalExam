using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3;

    float timeToNextSpawn = 0;

    private void Update()
    {
        if (CanSpawn())
        {
            SpawnDuck();
        }
    }

    bool CanSpawn()
    {
        if (timeToNextSpawn < Time.realtimeSinceStartup)
        {
            timeToNextSpawn = Time.realtimeSinceStartup + spawnDelay;
            return true;
        }

        return false;
    }

    void SpawnDuck()
    {
        var duck = DuckPool.Instance.GetDuckFromPool();

        duck.transform.position = transform.position;
    }
}
