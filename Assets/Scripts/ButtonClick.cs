using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
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

	public void Play()
	{

		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // загружаем сцену с игрой
		bird.panel.SetActive(false);
		Debug.Log("PLAY");
	}

	public void Exit()
	{

		Application.Quit();
		System.Diagnostics.Process.GetCurrentProcess().Kill(); // убиваем процессор
		Debug.Log("Exit");
	}

	public void Restart()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//bird.panel.SetActive(false);
		Time.timeScale = 1;
		Debug.Log("Restart");
	}

	public void Menu()
	{

		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		Debug.Log("Menu");
	}
}
