using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.GetComponent<Enemy>() != null)
        {
            currentHealth = currentHealth - 1;
            healthBar.setHealth(currentHealth);

            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            // It won't quit in the editor but quits in builds
            Application.Quit();
        }
    }

    // Update is called once per frame
}
