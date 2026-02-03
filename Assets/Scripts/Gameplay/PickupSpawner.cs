using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public int maxPickups = 5;
    public Vector2 spawnAreaMin = new Vector2(-5, -5);
    public Vector2 spawnAreaMax = new Vector2(5, 5);
    private List<GameObject> currentPickups = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < maxPickups; i++)
        {
            SpawnPickups();
        }
    }

    void Update()
    {
        currentPickups.RemoveAll(p => p == null);
        while (currentPickups.Count < maxPickups)
        {
            SpawnPickups();
        }
    }


    void SpawnPickups()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        GameObject pickup = Instantiate(pickupPrefab, spawnPos, Quaternion.identity);
        currentPickups.Add(pickup);
    }
}
