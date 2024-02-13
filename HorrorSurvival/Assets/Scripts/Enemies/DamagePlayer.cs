using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100f;

    //public string nextSceneName; // Name of the next scene to load
    //public float delay = 0.5f; // Delay in seconds before loading the next scene
    //public GameObject fadeout;

    public void Damage(float damage)
    {
        Debug.Log($"Player took {damage} damage.");
        health -= damage;
        Debug.Log("health is now: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    // Function to handle the enemy's death.
    private void Die()
    {
        Debug.Log("You are dead!");
        //fadeout.SetActive(true);
        //Invoke("LoadNextScene", delay);
    }

    private void LoadNextScene()
    {
        //SceneManager.LoadScene(nextSceneName); 
    }
}
