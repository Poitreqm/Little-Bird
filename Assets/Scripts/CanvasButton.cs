using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButton : MonoBehaviour
{
	Bird bird = new Bird();
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void OnMouseDown()
	{
		Debug.Log("qweqw");

		bird.OnMouseDown();
	}

}
