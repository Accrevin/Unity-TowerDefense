using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Detectenemy))]

public class FireProjectile : MonoBehaviour
{

    [SerializeField] private GameObject _projectilePrefab;
    private GameObject _tower;
    private GameObject _closestEnemy;
    private GameObject _spawnedProjectile;
    [SerializeField] private bool _CanSpawn = true;
    private bool invoked = false;


    
    void Start()
    {
     
    }

    void SetCanSpawn()
    {
        _CanSpawn = true;
        invoked = false;
    }


    void Update()
    {
        if (_CanSpawn == false && invoked == false)
        {
            invoked = true;
            Invoke("SetCanSpawn", 3);
        }

        if (_CanSpawn)
        {
            if (_projectilePrefab == null)
            {
                Debug.LogError("_projectilePrefab is missing!");
            }

            Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);

            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    Detectenemy detectenemy = gameObject.GetComponent<Detectenemy>();
                    if (detectenemy != null)
                    {
                        _closestEnemy = detectenemy.closest;

                        if (_closestEnemy != null && _CanSpawn == true)
                        {
                            _spawnedProjectile = Instantiate(_projectilePrefab, transform.position + Vector3.up, Quaternion.identity);
                            _spawnedProjectile.GetComponent<Projectile>().target = _closestEnemy.transform;
                            _CanSpawn = false;
                        }

                    }
                }
            }
        }
    }
}
