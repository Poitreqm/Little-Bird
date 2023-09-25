using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameHelper : MonoBehaviour
{


	public GameObject obstacle; // препятствие
	public GameObject scoreTrigger; // триггер для подсчета очков
	public GameObject cloud; // облака


	public float frequency; // частота появления препятствий

	public float distance; // растояние(дырка) между нижним и верхним препятствием

	public Text scoreText; // текст счета который виден игроку

	public int score;


	Bird bird = new Bird();


	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("CreateObstacle", 0f, frequency);

	}

	// Update is called once per frame
	void Update ()
	{
		scoreText.text = "" + score;

	}



	void CreateObstacle()
	{
		// создание случайной позиции для верхнего препятствия
		float randomPosition = 5f - (4f - distance) * Random.value;
		// добавление верхнего препятствия на сцену
		GameObject topObstacle = Instantiate(obstacle);

		// настройка позиции верхнего препятствия
		topObstacle.transform.position = new Vector2(4f, randomPosition);
		// добавление нижнего препятствия на сцену
		GameObject lowerObstacle = Instantiate(obstacle);

		// настройка позиции нижнего препятствия
		lowerObstacle.transform.position = new Vector2(4f, randomPosition - distance - 5f);

		// создаем триггер для считывания очков
		GameObject scoreTriggerObject = Instantiate(scoreTrigger);
		// меняем местоположение
		scoreTriggerObject.transform.position = new Vector2(4f, randomPosition - 6f);

		GameObject cloudObject = Instantiate(cloud); // создаем облако
		cloudObject.transform.position = new Vector2(randomPosition, randomPosition) * Random.value; // меняем местоположение

	}
}
