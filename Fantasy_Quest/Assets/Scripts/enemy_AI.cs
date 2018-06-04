using UnityEngine;
using System.Collections;

public class enemy_AI : MonoBehaviour {

	public Transform target;
	public float speed;
	private float range;
	private float maxDistance = 6f;
    private float minDistance = 1.5f;
    private Animator Anim;
    private Rigidbody2D Bleh;
	public float angle;

    void Start()
    {
		Anim = GetComponent<Animator> ();
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
		angle = Mathf.Atan2(transform.position.y - target.position.y, transform.position.x - target.position.x) * 180 / Mathf.PI;



        if (range < maxDistance && range > minDistance)
        {
            speed = 3f;

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (minDistance >=range)
        {
            speed = 0f;
        }
    }
	void FixedUpdate ()
	{
		if (range < maxDistance && range > minDistance && (angle <= -45 && angle >= -135)) {
            Anim.SetBool("moveUp", true);
            Anim.SetBool("moveDown", false);
            Anim.SetBool("moveLeft", false);
            Anim.SetBool("moveRight", false);
        }
        else if (range < maxDistance && range > minDistance && (angle >= -44 && angle <=0 || angle <=44 && angle >=0))
        {
            Anim.SetBool("moveUp", false);
            Anim.SetBool("moveDown", false);
            Anim.SetBool("moveLeft", true);
            Anim.SetBool("moveRight", false);
        }
        else if (range < maxDistance && range > minDistance && (angle <= -136 && angle >= -180 || angle >=136 && angle <=180))
        {
            Anim.SetBool("moveUp", false);
            Anim.SetBool("moveDown", false);
            Anim.SetBool("moveLeft", false);
            Anim.SetBool("moveRight", true);

        }
        else if (range < maxDistance && range > minDistance && (angle >= 45 && angle <= 135))
        {
            Anim.SetBool("moveUp", false);
            Anim.SetBool("moveDown", true);
            Anim.SetBool("moveLeft", false);
            Anim.SetBool("moveRight", false);

        }

		else 
		{
            Anim.SetBool("moveUp", false);
            Anim.SetBool("moveDown", false);
            Anim.SetBool("moveLeft", false);
            Anim.SetBool("moveRight", false);
        }

	}

}