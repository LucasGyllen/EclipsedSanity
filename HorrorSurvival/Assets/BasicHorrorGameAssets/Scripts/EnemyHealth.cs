using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 200f;

    public void Damage(float damage)
    {
        Debug.Log($"Enemy took {damage} damage.");
        Debug.Log("health is now: " + health);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Function to handle the enemy's death.
    private void Die()
    {
        // Perform any death-related actions here, such as playing death animations, spawning effects, or removing the enemy from the scene.
        // You can customize this method based on your game's requirements.

        // For example, you might destroy the enemy GameObject:
        gameObject.GetComponent<Animator>().SetBool("Death", true);
    }
}
