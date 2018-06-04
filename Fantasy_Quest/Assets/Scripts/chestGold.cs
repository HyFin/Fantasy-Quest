using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class chestGold : MonoBehaviour {
    GameObject player;
    GameObject GameInfo;
    playerScore playerScore;
    bool open;
    SpriteRenderer sr;
    public Sprite lootOpen;
    AudioSource audio;
	potions potions;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        GameInfo = GameObject.Find("GameInfo");
        playerScore = GameInfo.GetComponent<playerScore>();
        open = false;
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
		potions = GameObject.Find ("UI").GetComponent<potions> ();
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject == player && Input.GetKeyDown("e") && !open) 
        {
            playerScore.currentScore += 50;
			potions.redPots += 1;
            open = true;
            sr.sprite = lootOpen;
            audio.Play();
        }
	
	}
}
