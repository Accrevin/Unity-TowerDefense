using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Detectenemy : MonoBehaviour
{
    public GameObject closest = null;
    // Update is called once per frame
    void Update()
    {
        float closestDistance = Mathf.Infinity;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Vector3 direction = transform.position - enemy.transform.position;

            float distance = direction.magnitude;

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }


        }

        Debug.DrawRay(gameObject.transform.position, closest.transform.position, Color.blue);


    }
}
