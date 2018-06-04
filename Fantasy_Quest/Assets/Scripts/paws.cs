using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class paws : MonoBehaviour {
	
	private bool isGamePaused = false;
	private Text pausedTxt;
	private Image pausedImg;
	private Text bleh;


	void Start () {
		pausedTxt = GameObject.Find("pauseText").GetComponent<Text>();
		pausedImg = GameObject.Find("pauseImage").GetComponent<Image>();
		bleh = GameObject.Find("Bleh").GetComponent<Text>();
		isGamePaused = false;
	}
	
	void Update () {
		if(Input.GetKeyDown("escape") && !isGamePaused)
		{
			Time.timeScale = 0;
			isGamePaused = true;
			pausedTxt.enabled = true;
			pausedImg.enabled = true;
			bleh.enabled = true;

		}
		else if(Input.GetKeyDown("escape") && isGamePaused)
		{
			Time.timeScale = 1;
			isGamePaused = false;
			pausedTxt.enabled = false;
			pausedImg.enabled = false;
			bleh.enabled = false;
		}
		if (Input.GetKey ("q") && isGamePaused) {
			Time.timeScale = 1;
            playerScore.currentScore = 0;
			Application.LoadLevel (0);
		}
	}
}
