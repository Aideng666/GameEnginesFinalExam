using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPool : MonoBehaviour
{
    [SerializeField] GameObject duckPrefab;

    Queue<GameObject> availableDucks = new Queue<GameObject>();

    public static DuckPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        CreatePool();
    }

    public GameObject GetDuckFromPool()
    {
        if (availableDucks.Count == 0)
        {
            CreatePool();
        }

        var instance = availableDucks.Dequeue();
        instance.SetActive(true);
        instance.GetComponent<Duck>().ResetTime();
        return instance;
    }

    private void CreatePool()
    {
        for (int i = 0; i < 6; ++i)
        {
            var instanceToAdd = Instantiate(duckPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableDucks.Enqueue(instance);
    }
}
