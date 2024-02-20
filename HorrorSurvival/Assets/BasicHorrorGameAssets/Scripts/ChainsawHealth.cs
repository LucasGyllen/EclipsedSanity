using UnityEngine;

public class ChainsawHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 200f;

    private bool isDead = false;

    public AudioClip deathClip;

    public void Damage(float damage)
    {
        Debug.Log($"Enemy took {damage} damage.");
        health -= damage;
        Debug.Log("health is now: " + health);
        if (health <= 0)
        {
            Die();
            if (!isDead)
            {
                isDead = true;
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
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
