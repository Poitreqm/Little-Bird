using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target; // выбираем за кем следить
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void LateUpdate()
	{
		transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z); // камера двигается за объектом 
																										// не меняя при этом Y и Z

								
	}
}
