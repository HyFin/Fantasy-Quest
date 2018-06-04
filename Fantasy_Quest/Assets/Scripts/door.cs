using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	public string levelName = "level_02";

	void OnTriggerStay2D (Collider2D other){
		if(other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			Application.LoadLevel(levelName);
		}
	}

}