using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public Sprite[] cardFace;
	public Sprite cardBack;
	public GameObject[] cards;
	public GameObject CanvasCardsPuzzle;
	public GameObject gameTime;

	public static GameManager instance = null;
	public Player player;
	public GameObject ini_Player;

	private bool _init = false;
	private int _matches = 4;


	// Start is called before the first frame update
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null)
		{
			Destroy(gameObject);
		}

		//DontDestroyOnLoad(gameObject);
		player = Instantiate(player, ini_Player.transform.position, Quaternion.identity);
		//instantiate array cards in canvas
		Instantiate(CanvasCardsPuzzle, CanvasCardsPuzzle.transform.position, Quaternion.identity);
		cards = GameObject.FindGameObjectsWithTag("Card");
		gameTime = GameObject.FindGameObjectWithTag("GameTime");

	}
	// Update is called once per frame
	void Update()
	{
		if (!_init)// volver a iniciar la partida ToDo: cargar fases
			initializeCards();

		if (Input.GetMouseButtonUp(0))// cuando clicas comprueba las cartas
			checkCards();

	}
	void initializeCards()
	{
		for (int id = 0; id < 2; id++)//ToDo: hacer array dinamico segun el levelGenerator
		{
			for (int i = 1; i < 5; i++)
			{

				bool test = false;
				int choice = 0;
				while (!test)//inicializa las cartas de forma aleatoria en cada posicion
				{
					choice = Random.Range(0, cards.Length);
					test = !(cards[choice].GetComponent<CardScript>().initialized);
				}
				cards[choice].GetComponent<CardScript>().cardValue = i;//ToDo: asignar de otra forma
				cards[choice].GetComponent<CardScript>().initialized = true;
			}
		}

		foreach (GameObject c in cards)// carga las texturas de cada carta ToDo: cargar aqui las clases propias de cada carta
			c.GetComponent<CardScript>().setupGraphics();

		if (!_init)
			_init = true;
	}

	public Sprite getCardBack()
	{
		return cardBack;
	}

	public Sprite getCardFace(int i)
	{
		return cardFace[i - 1];
	}
	/// <summary>
	/// Levantar la carta
	/// Si hay dos cartas levantadas, las compara
	/// </summary>
	void checkCards()
	{
		List<int> c = new List<int>();//lista donde se insertar las dos cartas a comparar

		//ToDo: convertir a un metodo findCard
		for (int i = 0; i < cards.Length; i++)//recorre todas las cartas para encontrar la activa
		{
			if (cards[i].GetComponent<CardScript>().state == 1)
				c.Add(i);
		}

		if (c.Count == 2)
			cardComparison(c);
	}

	/// <summary>
	/// Compara si las cartas son pareja o no
	/// </summary>
	/// <param name="c"></param>
	void cardComparison(List<int> c)
	{
		CardScript.DO_NOT = true;//bandera de comparar cartas, se usa para detener las corrutinas

		int x = 0;

		//comparamos si son iguales
		if (cards[c[0]].GetComponent<CardScript>().cardValue == cards[c[1]].GetComponent<CardScript>().cardValue)
		{
			x = 2;//estado que no cambia en ninguna parte,no vuelve a girarse
			_matches--;
			if (_matches == 0)// victoria
				gameTime.GetComponent<timeScript>().endGame();
		}


		for (int i = 0; i < c.Count; i++)//vuelve a asignar 0 al estado y lanza la corutina de voltear la carta
		{
			cards[c[i]].GetComponent<CardScript>().state = x;
			cards[c[i]].GetComponent<CardScript>().falseCheck();
		}

	}

	public void reGame()
	{
		//instance = null;
		//DestroyImmediate(gameObject);
		SceneManager.LoadScene("gameScene");
		//this.Awake();
	}

	public void reMenu()
	{
		SceneManager.LoadScene("menuScene");
	}

}
