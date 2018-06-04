using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerScore : MonoBehaviour {
    public static int currentScore;
    public Text gold;
    public GameObject GameInfo;
	public int currentLives;
    public Text lives;
	// Use this for initialization
	void Start () {
        GameInfo = GameObject.Find("GameInfo");
        DontDestroyOnLoad(GameInfo);
		currentLives = 3;
	}
	
	// Update is called once per frame
	void Update () {
        gold = GameObject.Find("Gold").GetComponent<Text>();
        gold.text = "Gold: " + currentScore.ToString();
        lives = GameObject.Find("lives").GetComponent<Text>();
        lives.text = "Lives: " + currentLives.ToString();
        if (currentLives <= 0)
        {
            currentLives = 3;
        }
    }
}
