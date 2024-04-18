using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            PlaceTower placeTower = GameObject.FindAnyObjectByType<PlaceTower>();
            placeTower.AddResources();
            
            Destroy(gameObject);
        }
    }


}
