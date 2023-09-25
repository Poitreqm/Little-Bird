using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Bird : MonoBehaviour
{
	public Animator animator; // доступ до анимации
	public GameObject hand; // картинка с "рукой" которая намекает что нужно кликнуть по экрану
	public GameObject text; // картинска с текстом на которой написанно краткое интсрукция

	Rigidbody2D rigidbbody2d;

	public float speed; // скорость птицы
	public float force; // сила прыжка

	private GameHelper gameHelper;

	public Text scoreTextOnThePanel; // счет на панели
	public Text recordTextOnThePanel; // рекорд на панели

	public int recordInt; // переменная для рекорда

	public GameObject panel;
	public GameObject buttonJump;


	private const string bannerId = "ca-app-pub-5917403779380612/1587781554";


	// Use this for initialization


	void Start()
	{
		Time.timeScale = 0f;
		buttonJump.SetActive(true);
		panel.SetActive(false);
		hand.SetActive(true);
		text.SetActive(true);
		rigidbbody2d = GetComponent<Rigidbody2D>();
		rigidbbody2d.velocity = Vector2.right * speed;
		gameHelper = Camera.main.GetComponent<GameHelper>(); // Выходим на компонент камеры
															 //scoreTextOnThePanel = GetComponent<Text>();
		BannerView banner = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
		AdRequest request = new AdRequest.Builder().Build();
		//AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("63ed5971e9340879").Build();
		banner.LoadAd(request);
	}



	// Update is called once per frame
	void Update()
	{
		///---
		// сохраняем рекорд
		if (gameHelper.score > recordInt)
		{
			PlayerPrefs.SetInt("recordInt", gameHelper.score);
			PlayerPrefs.Save();
		}

		recordInt = PlayerPrefs.GetInt("recordInt");

		///---

		//if (Input.GetKeyUp(KeyCode.Space) && panel.active == false)
		//{
		//	Time.timeScale = 1f;
		//	animator.speed = 0.5f;
		//}

		//if (Input.GetKey(KeyCode.Space) && panel.active == false)
		//{
		//	hand.active = false;
		//	text.active = false;
		//	animator.speed = 2f; // заставляем птицу быстрее махать крыльями
		//	Time.timeScale = 1.3f; // немного увеличиваем скорость когда она быстрее махает крыльями
		//	rigidbbody2d.AddForce(Vector2.up * (force - rigidbbody2d.velocity.y), ForceMode2D.Impulse); // прыжок

		//}

		//if (Input.GetKeyDown(KeyCode.R) && panel.active == false)
		//{
		//	rigidbbody2d.AddForce(Vector2.down * (force - rigidbbody2d.velocity.y), ForceMode2D.Impulse);
		//}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		YouAreDead(); // если сталкнулся с чем либо о вызвать функцию
		
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		gameHelper.score++; // если прошел сквозь триггер(дырку) увеличить счет
	}
	
	void YouAreDead() // функция которая вызывается пр исмерти
	{
		GetComponent<AudioSource>().Play();
		scoreTextOnThePanel.text =   "Score:             " + gameHelper.score; // счет в панели
		recordTextOnThePanel.text =  "Top:                 " + recordInt; // рекорд в панели
		panel.SetActive(true);
		buttonJump.SetActive(false);
		Time.timeScale = 0;
		

	}

	public void OnMouseDown()
	{
		if (panel.active == false)
		{
			hand.SetActive(false);
			text.SetActive(false);
			animator.speed = 1f; // заставляем птицу быстрее махать крыльями
			Time.timeScale = 1f; // немного увеличиваем скорость когда она быстрее махает крыльями
			rigidbbody2d.AddForce(Vector2.up * (force - rigidbbody2d.velocity.y), ForceMode2D.Impulse); // прыжок
		}
	}


}
