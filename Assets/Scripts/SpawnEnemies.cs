using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy;
    // Start is called before the first frame update
    void Start()
    {
        var _renderer = gameObject.GetComponent<Renderer>();
        InvokeRepeating("SpawnEnemy", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 GenerateRandomPoint(GameObject obj)
    {
        Bounds bounds = obj.GetComponent<Renderer>().bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(randomX, randomY, randomZ);

    }

    public void SpawnEnemy()
    {
        Vector3 spawnPoint = GenerateRandomPoint(gameObject);
        Debug.Log(spawnPoint);
        Instantiate(_Enemy, spawnPoint, Quaternion.identity);
    }
}
