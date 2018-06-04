using UnityEngine;
using System.Collections;


public class enemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 3f;     // The time in seconds between each attack.
    public int attackDamage = 5;               // The amount of health taken away per attack.


    GameObject player;                          // Reference to the player GameObject.
    playerHealth playerHealth;                  // Reference to the player's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    public Animator anim;


    void Start()
    {
        // Setting up the references.
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<playerHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
			anim.SetBool ("Attack", false);
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

		if (timer > timeBetweenAttacks && playerInRange && playerHealth.currentHealth > 0) 
		{
			Attack ();
		}
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;
		anim.SetBool ("Attack", true);
        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
