using System.Collections.Generic;
using UnityEngine;

public class StoneSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] public List<GameObject> spawnList = new List<GameObject>();
    [SerializeField] private float timerTime = 3f;
    private float timer = 3f;
    private Vector2 spawnPoint;
    private GameObject newObject;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (spawnList.Count < 5)
            {
                spawnPoint = new Vector2(Random.Range(8.5f, -8.5f), Random.Range(3.5f, -4.5f));
                newObject = Instantiate(prefab, spawnPoint, Quaternion.identity, parent);
                spawnList.Add(newObject);
            }
            timer = timerTime;
        }
    }
}
