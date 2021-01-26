using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
	public GameObject[] cards;
	public GameObject CanvasCardsPuzzle;
	private GameObject EditCanvasCard;
	public GameObject gameTime;

	public static GameManager instance = null;
	public BoardManager _board;
	public Player player;
	public GameObject ini_Player;
	public Enemy enemy;

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
		_board = GetComponent<BoardManager>();
		player = Instantiate(player, ini_Player.transform.position, Quaternion.identity);
		//instantiate array cards in canvas
		EditCanvasCard = Instantiate(CanvasCardsPuzzle, CanvasCardsPuzzle.transform.position, Quaternion.identity);
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
    //void initializeCards()
    //{
    //    AssignCardsPuzzle(cards);
    //    for (int id = 0; id < 2; id++)//la segunda vuelta para asegurar dos de cada carta
    //    {
    //        for (int i = 1; i < NumberTypeOfCards + 1; i++)//cuenta 1 vuelta de carta, bucle por numero total de cartas distintas
    //        {

    //            bool test = false;
    //            int choice = 0;
    //            while (!test)//inicializa las cartas de forma aleatoria en cada posicion
    //            {
    //                choice = UnityEngine.Random.Range(0, cards.Length);
    //                test = !(cards[choice].GetComponent<CardScript>().initialized);//busca hasta que encuentra una carta sin inicializar
    //            }
    //            cards[choice].GetComponent<CardScript>().cardValue = i;//ToDo: asignar de otra forma
    //            cards[choice].GetComponent<CardScript>().initialized = true;
    //        }
    //    }

    //    foreach (GameObject c in cards)// carga las texturas de cada carta ToDo: cargar aqui las clases propias de cada carta
    //        c.GetComponent<CardScript>().setupGraphics();

    //    if (!_init)
    //        _init = true;
    //}

    public void initializeCards()
	{
        if (_board.nextLevel)//ToDo: leer variable next level en boardManager
        {
			DestroyImmediate(EditCanvasCard);
			EditCanvasCard = Instantiate(CanvasCardsPuzzle, CanvasCardsPuzzle.transform.position, Quaternion.identity);
			cards = GameObject.FindGameObjectsWithTag("Card");
			gameTime = GameObject.FindGameObjectWithTag("GameTime");
			_matches = 4; //ToDo: gestionar toda la logica de asignar la dificultad
			_board.nextLevel = false;
		}
		//Determinar cuantas cartas de cada tipo se hacen
		int typeCards = 4;
		int cardsEachType = cards.Length / typeCards;
		
			//generamos en secuencias las cartas de cada tipo
			GenerateCardBuffAttack(cardsEachType);
			GenerateCardDebuffAttack(cardsEachType);
			GenerateCardBuffLife(cardsEachType);
			GenerateCardGoblin(cardsEachType);
		
		foreach (GameObject c in cards)// carga las texturas de cada carta ToDo: cargar aqui las clases propias de cada carta
			c.GetComponent<CardScript>().setupGraphics();

		if (!_init)
			_init = true;
	}

	private void GenerateCardBuffAttack( int numberCards )
    {
        for (int j = 0; j < numberCards; j++)
        {
			int i = 0;
			int choice = 0;
			bool test = false;
			//por cada tipo de carta, instanciamos dos huecos
			while (!test)//inicializa las cartas de forma aleatoria en cada posicion
			{
				choice = UnityEngine.Random.Range(0, cards.Length);//posicion random del tablero ToDo: hacer por posiciones ya asignada previamente
                if (cards[choice].GetComponent<CardScript>() != null)
				{
					test = false;
                }
				else//busca hasta que encuentra una carta del tablero sin inicializar
				{
					cards[choice].AddComponent<cBuffAttackPlayer>();// la clase que corresponde
					cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cBuffAttackPlayer>().flipcard());
					cards[choice].GetComponent<cBuffAttackPlayer>().initialized = true;
					test = true;
				}
			}
		}
	}

	private void GenerateCardDebuffAttack(int numberCards)
	{
		for (int j = 0; j < numberCards; j++)
		{
			int i = 0;
			int choice = 0;
			bool test = false;
			//por cada tipo de carta, instanciamos dos huecos
			while (!test)//inicializa las cartas de forma aleatoria en cada posicion
			{
				choice = UnityEngine.Random.Range(0, cards.Length);//posicion random del tablero ToDo: hacer por posiciones ya asignada previamente
				if (cards[choice].GetComponent<CardScript>() != null)
				{
					test = false;
				}
				else//busca hasta que encuentra una carta del tablero sin inicializar
				{
					cards[choice].AddComponent<cDebuffAttackPlayer>();// la clase que corresponde
					cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cDebuffAttackPlayer>().flipcard());
					cards[choice].GetComponent<cDebuffAttackPlayer>().initialized = true;
					test = true;
				}
			}
		}
	}

	private void GenerateCardBuffLife(int numberCards)
	{
		for (int j = 0; j < numberCards; j++)
		{
			int i = 0;
			int choice = 0;
			bool test = false;
			//por cada tipo de carta, instanciamos dos huecos
			while (!test)//inicializa las cartas de forma aleatoria en cada posicion
			{
				choice = UnityEngine.Random.Range(0, cards.Length);//posicion random del tablero ToDo: hacer por posiciones ya asignada previamente
				if (cards[choice].GetComponent<CardScript>() != null)
				{
					test = false;
				}
				else//busca hasta que encuentra una carta del tablero sin inicializar
				{
					cards[choice].AddComponent<cBuffLifePlayer>();// la clase que corresponde
					cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cBuffLifePlayer>().flipcard());
					cards[choice].GetComponent<cBuffLifePlayer>().initialized = true;
					test = true;
				}
			}
		}
	}

	//private void GenerateCardDebuffLife(int numberCards)
	//{
	//	for (int j = 0; j < numberCards; j++)
	//	{
	//		int i = 0;
	//		int choice = 0;
	//		bool test = false;
	//		//por cada tipo de carta, instanciamos dos huecos
	//		while (!test)//inicializa las cartas de forma aleatoria en cada posicion
	//		{
	//			choice = UnityEngine.Random.Range(0, cards.Length);//posicion random del tablero ToDo: hacer por posiciones ya asignada previamente
	//			if (cards[choice].GetComponent<CardScript>() != null)
	//			{
	//				test = false;
	//			}
	//			else//busca hasta que encuentra una carta del tablero sin inicializar
	//			{
	//				cards[choice].AddComponent<cDebuffLifePlayer>();// la clase que corresponde
	//				cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cDebuffLifePlayer>().flipcard());
	//				cards[choice].GetComponent<cDebuffLifePlayer>().initialized = true;
	//				test = true;
	//			}
	//		}
	//	}
	//}

	private void GenerateCardGoblin(int numberCards)
	{
		for (int j = 0; j < numberCards; j++)
		{
			int i = 0;
			int choice = 0;
			bool test = false;
			//por cada tipo de carta, instanciamos dos huecos
			while (!test)//inicializa las cartas de forma aleatoria en cada posicion
			{
				choice = UnityEngine.Random.Range(0, cards.Length);//posicion random del tablero ToDo: hacer por posiciones ya asignada previamente
				if (cards[choice].GetComponent<CardScript>() != null)
				{
					test = false;
				}
				else//busca hasta que encuentra una carta del tablero sin inicializar
				{
					cards[choice].AddComponent<cGoblinMonster>();// la clase que corresponde
					cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cGoblinMonster>().flipcard());
					cards[choice].GetComponent<cGoblinMonster>().initialized = true;
					test = true;
				}
			}
		}
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
			cards[c[0]].GetComponent<CardScript>().SpecialEffect();
			if (_matches == 0)// victoria
			{
				x = 0;
				gameTime.GetComponent<timeScript>().endGame();
				_board.NextLevel();
			}
		}


		for (int i = 0; i < c.Count; i++)//vuelve a asignar 0 al estado y lanza la corutina de voltear la carta
		{
			cards[c[i]].GetComponent<CardScript>().state = x;
			cards[c[i]].GetComponent<CardScript>().falseCheck();
		}

	}

	public void reGame()
	{
		SceneManager.LoadScene("gameScene");
	}

	public void reMenu()
	{
		SceneManager.LoadScene("menuScene");
	}

}
