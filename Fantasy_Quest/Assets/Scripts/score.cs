using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {
    playerScore GameInfo;
    Text scoreText;

	// Use this for initialization
	void Start () {
        GameInfo = GameObject.Find("GameInfo").GetComponent<playerScore>();
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + playerScore.currentScore.ToString();
	
	}
}
