using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public float speed;
	public float switchTime;
	Rigidbody2D rigidbbody2d;
	Random random;
	// Use this for initialization
	void Start ()
	{
		rigidbbody2d = GetComponent<Rigidbody2D>();
		rigidbbody2d.velocity = Vector2.left * speed;

		//InvokeRepeating("Switch", 4, switchTime); // если вместо 0 поставить 4 то получится классный эффект


	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector2.MoveTowards(transform.position, transform.position - transform.right, speed * Time.deltaTime);
	}

	//void Switch()
	//{
	//	//rigidbbody2d.velocity *= -1;
	//}
	
	private void OnBecameInvisible()
	{
		Destroy(gameObject, 4.0f);
	}
}
