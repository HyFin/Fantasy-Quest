using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {
	public float timeBetweenAttacks = 1f;
	public int attackDamage = 5; 
    private enemyHealth enemyHealth;                                        
	public float timer;
    public GameObject enemyObj;
    public bool enemyInRange;
    public GameObject player;
    public Animator anim;
    playerMovement playerMovement;
    public float animtimer;
    GameObject GameInfo;
    private bool attacking = false;
    playerScore playerScore;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
        playerMovement = player.GetComponent<playerMovement>();
        GameInfo = GameObject.Find("GameInfo");
        playerScore = GameInfo.GetComponent<playerScore>();

    }
    void OnTriggerStay2D(Collider2D other)
    {
		if (other.gameObject.tag == "Enemy" && attacking == true)
        {
            var collidedEnemy = other.gameObject.GetComponent<enemyHealth>();
			if (timer >0.75)
			{
				collidedEnemy.currentHealth -=attackDamage;
				timer = 0f;
				attackDamage = 5;
			}

            if (collidedEnemy.currentHealth <= 0)
            {
                enemyObj = other.gameObject;
                Destroy(enemyObj);
                playerScore.currentScore += 10;
            }
            Debug.Log(collidedEnemy.currentHealth);
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

		if (Input.GetKey("space")) 
		{
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			playerMovement.enabled = false;
			anim.SetBool ("attack", true);
			attacking = true;

        }
		else if (Input.GetKeyUp ("space"))
		{
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
			playerMovement.enabled = true;
			anim.SetBool ("attack", false);
			attacking = false;
		}
		else
		{
			anim.SetBool("attack", false);
			playerMovement.enabled = true;
			attacking = false;
		}
    }
}
