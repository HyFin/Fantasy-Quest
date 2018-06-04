using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {
    playerScore playerScore;

	// Use this for initialization
	void Start () {
        playerScore = GameObject.Find("GameInfo").GetComponent<playerScore>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void quitGame (int level)
    {
        playerScore.currentScore = 0;
        Application.LoadLevel(level);

    }
}
