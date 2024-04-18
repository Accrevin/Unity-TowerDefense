using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    public Transform target;
    [SerializeField] private float speed = 5.0f;

    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget = directionToTarget.normalized;

            transform.position += (directionToTarget * speed) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy EnemyComponent = collision.gameObject.GetComponent<Enemy>();
        if (EnemyComponent != null)
        {
            EnemyComponent.health = EnemyComponent.health - 1;
            Destroy(gameObject);
        }

    }
}
