using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour
{
    public int startingHealth = 100;                           
    public int currentHealth;                                   
    public Scrollbar Healthbar;
    public Image HealthImage;
    public Text HealthText;
    public Animator anim;
    GameObject Gameinfo;
    playerScore playerScore;
    public Text lives;
    Transform playerSpawn;
    bool isDead;                                                // Whether the player is dead.


    void Start()
    {
        // Setting up the references.

        // Set the initial health of the player.
        currentHealth = startingHealth;
        Healthbar = GameObject.Find("healthUI").GetComponent<Scrollbar>();
        HealthImage = GameObject.Find("Image").GetComponent<Image>();
        HealthImage.color = Color.green;
        HealthText = GameObject.Find("Text").GetComponent<Text>();
        anim = GetComponent<Animator>();
        Gameinfo = GameObject.Find("GameInfo");
        playerScore = Gameinfo.GetComponent<playerScore>();
        playerSpawn = GameObject.Find("playerSpawn").GetComponent<Transform>();
    }


    void Update()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        if (currentHealth >= 70)
        {
            HealthImage.color = Color.green;
        }
        else if (currentHealth >= 30 && currentHealth < 70)
        {
            HealthImage.color = Color.yellow;
        }
        else if (currentHealth < 30)
        {
            HealthImage.color = Color.red;
        }
        HealthText.text = "Health: " + currentHealth.ToString();
    }


    public void TakeDamage(int amount)
    {

        // Reduce the current health by the damage amount.
        currentHealth -= amount;
        Healthbar.size = currentHealth / 100f;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
        if (currentHealth >= 70)
        {
            HealthImage.color = Color.green;
        }
        else if (currentHealth >= 30 && currentHealth < 70)
        {
            HealthImage.color = Color.yellow;
        }
        else if (currentHealth < 30)
        {
            HealthImage.color = Color.red;
        }
        else if (currentHealth <= 0)
        {
            Death();
        }
        HealthText.text = "Health: " + currentHealth.ToString();
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
		playerScore.currentLives -= 1;
        if (playerScore.currentLives > 0)
        {
            transform.position = playerSpawn.position;
            currentHealth = 100;
            isDead = false;
            Healthbar.size = currentHealth / 100f;
        }
        else if (playerScore.currentLives <= 0)
        {
            isDead = false;
            Application.LoadLevel(4);
        }
    }
}