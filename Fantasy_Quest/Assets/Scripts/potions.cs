using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class potions : MonoBehaviour {
    public int redPots;
    Text redNum;
    playerHealth playerHealth;
	playerAttack playerAttack;

	// Use this for initialization
	void Start () {
        redPots = 2;
        redNum = GameObject.Find("redNum").GetComponent<Text>();
        playerHealth = GameObject.Find("Player").GetComponent<playerHealth>();
		playerAttack = GameObject.Find ("trigger").GetComponent<playerAttack> ();
	}
	
	// Update is called once per frame
	void Update () {
        redNum.text = "x " + redPots.ToString();
        if (redPots > 0 && Input.GetKeyDown("r"))
        {
            redPots -= 1;
			playerAttack.attackDamage = 30;
            playerHealth.currentHealth += 20;
            playerHealth.Healthbar.size = playerHealth.currentHealth / 100f;
        }
	}
}
