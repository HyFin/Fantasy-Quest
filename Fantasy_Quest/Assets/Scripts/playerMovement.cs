using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeed = 5.0f;
	private Animator Anim;
	public float moveX;
	public float moveY;
	// Use this for initialization
	void Start () {

		Anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

		Anim.SetFloat("moveSpeedX", GetComponent<Rigidbody2D>().velocity.x);
		Anim.SetFloat("moveSpeedY", GetComponent<Rigidbody2D>().velocity.y);
	}
    void Update ()
    {
        GetComponent<Rigidbody2D>().WakeUp();
    }
}
