﻿using UnityEngine;
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
	public Text descriptionText;

	public static GameManager instance = null;
	public BoardManager _board;
	public Player player;
	public GameObject ini_Player;
	[NonSerialized] public Enemy enemy;
	public GameObject ini_enemy;
	public eLichBoss finalBoss;
	public GameObject minionFinalBoss;
	[NonSerialized] public GameObject _doorNextLevel;
	public GameObject ini_DoorNextLevel;

	public AudioClip flipCard;

	//parametros que definen de dificultad
	private int playerAttack;
	private int monstersKilled = 0;
	private int movesPlayed = 0;

	//parametros que representan la dificultad
	//int monsterCardsForLevel;
	private int pairCardsToWin;
	private int failMovesToDamage;
	private int failMoves = 0;

	// Indice de cartas a generar
	private int nCardsGoblin;
	private int nCardsOrc;
	private int nCardsBuffAtk;
	private int nCardsBuffLife;
	private int nCardsDebuffAtk;
	private int nCardsDebuffLife;
	private int nCardsLichPhylacteries;

	private bool _init = false;
	private bool _flipBoardLevel = false;
	private int _matches = 4;
	private int level = 1;
    private int target = 60;

    public int NCardsGoblin { get => nCardsGoblin; set => nCardsGoblin = value; }
    public int NCardsOrc { get => nCardsOrc; set => nCardsOrc = value; }
    public int NCardsBuffAtk { get => nCardsBuffAtk; set => nCardsBuffAtk = value; }
    public int NCardsBuffLife { get => nCardsBuffLife; set => nCardsBuffLife = value; }
    public int NCardsDebuffAtk { get => nCardsDebuffAtk; set => nCardsDebuffAtk = value; }
    public int NCardsDebuffLife { get => nCardsDebuffLife; set => nCardsDebuffLife = value; }
    public int NCardsLichPhylacteries { get => nCardsLichPhylacteries; set => nCardsLichPhylacteries = value; }


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
		if (HealthManager.instance != null)
		{
			if (!HealthManager.instance.enabled)
			{
				HealthManager.instance.enabled = true;
				HealthManager.instance.SetNewCanvasUI();
			}
		}

		Application.targetFrameRate = target;
		descriptionText = GameObject.FindGameObjectWithTag("descriptionText").GetComponent<Text>(); 
		//DontDestroyOnLoad(gameObject);
		_board = GetComponent<BoardManager>();
		player = Instantiate(player, ini_Player.transform.position, Quaternion.identity);
		ini_enemy = GameObject.FindGameObjectWithTag("ini_enemy");
		//instantiate array cards in canvas
		EditCanvasCard = Instantiate(CanvasCardsPuzzle, CanvasCardsPuzzle.transform.position, Quaternion.identity);
		EditCanvasCard.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		_doorNextLevel =  GameObject.FindGameObjectWithTag("nextLevelDoor");
		cards = GameObject.FindGameObjectsWithTag("Card");
		gameTime = GameObject.FindGameObjectWithTag("GameTime");
	}

    // Update is called once per frame
    void Update()
	{
		if (!_init)// volver a iniciar la partida ToDo: cargar fases
		{
			initializeCards();
		}

		if (Input.GetMouseButtonUp(0))// cuando clicas comprueba las cartas
			checkCards();

	}
	/// <summary>
	/// Metodo que genera el tablero de cartas de un nivel
	/// </summary>
    public void initializeCards()
	{
		//resetamos valores de puntuacion
		monstersKilled = 0;
		movesPlayed = 0;
		failMoves = 0;

		//La dificultad ya viene asignada del BoardManager
		
		if (_board.nextLevel)
        {
			DestroyImmediate(EditCanvasCard);
			//DestroyImmediate(_doorNextLevel);
			EditCanvasCard = Instantiate(CanvasCardsPuzzle, CanvasCardsPuzzle.transform.position, Quaternion.identity);
			EditCanvasCard.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
			_doorNextLevel = GameObject.FindGameObjectWithTag("nextLevelDoor");
			cards = GameObject.FindGameObjectsWithTag("Card");
			gameTime = GameObject.FindGameObjectWithTag("GameTime");
			_matches = pairCardsToWin; 
			_board.nextLevel = false;

            if (_board.FinalBoss)
            {
				SoundManager.instance.musicSource.Stop();
				SoundManager.instance.musicSource.clip = Resources.Load<AudioClip>("06_EscapingTheDevil");
				SoundManager.instance.musicSource.Play();
				finalBoss = Instantiate(finalBoss, ini_enemy.transform.position, Quaternion.identity);
				minionFinalBoss = Instantiate(minionFinalBoss,new Vector2(ini_enemy.transform.position.x + 30, ini_enemy.transform.position.y), Quaternion.identity);
				Instantiate(minionFinalBoss, new Vector2(ini_enemy.transform.position.x -30, ini_enemy.transform.position.y), Quaternion.identity);
				finalBoss.SetLifeLich(NCardsLichPhylacteries / 2);
			}
		}

		//ahora las daremos ya definidas desde la clase BoardManager
		//vemos el total de cartas para ese nivel ( ya predefinidas)
		//Las creamos a manita y son fijas, ToDo: si se quiere mejorar
		
		// cartas de monstruos a generar
		GenerateCardOrc(nCardsOrc);
		GenerateCardGoblin(NCardsGoblin);

		//generamos en secuencias las cartas de cada tipo
		//cartas de buff
		GenerateCardBuffAttack(nCardsBuffAtk);
		GenerateCardBuffLife(nCardsBuffLife);

		//cartas de debuff
		GenerateCardDebuffAttack(nCardsDebuffAtk);
		GenerateCardDebuffLife(nCardsDebuffLife);

		//cartas de filacterea del liche
		GenerateCardLichPhylactery(NCardsLichPhylacteries);

		foreach (GameObject c in cards)// carga las texturas de cada carta ToDo: cargar aqui las clases propias de cada carta
		{
			c.GetComponent<CardScript>().setupGraphics();
			c.GetComponent<Button>().enabled = false;
		}
		
		ShowBoardLevel();
	
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

    private void GenerateCardDebuffLife(int numberCards)
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
                    cards[choice].AddComponent<cDebuffLifePlayer>();// la clase que corresponde
                    cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cDebuffLifePlayer>().flipcard());
                    cards[choice].GetComponent<cDebuffLifePlayer>().initialized = true;
                    test = true;
                }
            }
        }
    }

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

	private void GenerateCardOrc(int numberCards)
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
					cards[choice].AddComponent<cOrcMonster>();// la clase que corresponde
					cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cOrcMonster>().flipcard());
					cards[choice].GetComponent<cOrcMonster>().initialized = true;
					test = true;
				}
			}
		}
	}

	private void GenerateCardLichPhylactery(int numberCards)
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
					cards[choice].AddComponent<cLichPhylacteries>();// la clase que corresponde
					cards[choice].GetComponent<Button>().onClick.AddListener(() => cards[choice].GetComponent<cLichPhylacteries>().flipcard());
					cards[choice].GetComponent<cLichPhylacteries>().initialized = true;
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
		SoundManager.instance.PlaySingle(flipCard);
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
		movesPlayed++;//sumamos un movimiento

		//comparamos si son iguales
		if (cards[c[0]].GetComponent<CardScript>().cardValue == cards[c[1]].GetComponent<CardScript>().cardValue)
		{
			x = 2;//estado que no cambia en ninguna parte,no vuelve a girarse
			_matches--;
			cards[c[0]].GetComponent<CardScript>().SpecialEffect();
			if (_matches == 0 && !_board.FinalBoss)// victoria SALVO que no sea final boss
			{
				//x = 0; esto sobre por que si no siempre voltea la ultima
				gameTime.GetComponent<timeScript>().endGame();
				setParametersEndLevel();
				OpenDoorNextLevel();
				GameManager.instance.SetDescriptionText("You find your way to the door to the next level");
			}
		}
        else//anotamos los movimientos fallidos para activar daño
        {
			failMoves++;
        }

        if (failMovesToDamage == failMoves)//si ha tomado demasiados intentos
        {
			GameManager.instance.player.TakeDamage(1);//ToDo: hacer animacion especial con trampas o algo
			failMoves = 0;
        }

		for (int i = 0; i < c.Count; i++)//vuelve a asignar 0 al estado y lanza la corutina de voltear la carta
		{
			cards[c[i]].GetComponent<CardScript>().state = x;
			cards[c[i]].GetComponent<CardScript>().falseCheck();
		}
	}

	private void ShowBoardLevel()
    {
		StartCoroutine(FlipBoardLevel());
		
	}

	IEnumerator FlipBoardLevel()
	{
		_flipBoardLevel = false;
		foreach(GameObject c in cards)
			c.GetComponent<CardScript>().flipcard();

		yield return new WaitForSeconds(1.5F);

		foreach (GameObject c in cards)
		{
			c.GetComponent<CardScript>().flipcard();
			c.GetComponent<Button>().enabled = true;
		}

	}

	private void OpenDoorNextLevel()
    {
		//activamos la puerta
		_doorNextLevel.GetComponent<Image>().enabled = true;
		_doorNextLevel.GetComponent<Button>().enabled = true;
	}

	/// <summary>
	/// Se envia la info al BoardManager para calcular la dificultad para el proximo nivel
	/// </summary>
    private void setParametersEndLevel()
    {
		//enviar info a BoardManager
		_board.SetBoardNewLevelParameters(GameManager.instance.player.playerAttack, monstersKilled, movesPlayed);
    }

	/// <summary>
	/// Se reciben los datos del BoardManager para generar un nuevo nivel
	/// </summary>
	/// <param name="_pairCardsToWin"></param>
	/// <param name="_failMovesToDamage"></param>
	/// <param name="_nCardsGoblin"></param>
	/// <param name="_nCardsOrc"></param>
	/// <param name="_nCardsBuffAtk"></param>
	/// <param name="_nCardsBuffLife"></param>
	/// <param name="_nCardsDebuffAtk"></param>
	/// <param name="_nCardsDebugsLife"></param>
	/// <param name="_level"></param>
	public void SetParametersNewLevel(int _pairCardsToWin,int _failMovesToDamage, int _nCardsGoblin, int _nCardsOrc,int _nCardsBuffAtk,
		int _nCardsBuffLife, int _nCardsDebuffAtk, int _nCardsDebugsLife, int _nCardsLichPhylactery, int _level)
	{
		pairCardsToWin = _pairCardsToWin;
		failMovesToDamage = _failMovesToDamage;
		nCardsGoblin = _nCardsGoblin;
		nCardsOrc = _nCardsOrc;
		nCardsBuffAtk = _nCardsBuffAtk;
		nCardsBuffLife = _nCardsBuffLife;
		nCardsDebuffAtk = _nCardsDebuffAtk;
		nCardsDebuffLife = _nCardsDebugsLife;
		NCardsLichPhylacteries = _nCardsLichPhylactery;
		level = _level;


	}

	public void UpdateMonsterKilled()
    {
		monstersKilled++;
    }

	public void SetDescriptionText(string _description)
    {
		descriptionText.text = _description;
    }

	public void reGame()
	{
		//SceneManager.LoadScene("gameScene");
		cards = GameObject.FindGameObjectsWithTag("Card");

		foreach (GameObject c in cards)
			c.GetComponent<CardScript>().flipcard();
	}

	public void reMenu()
	{
		SceneManager.LoadScene("menuScene");
	}

	public void victoryMenu()
	{
		DestroyImmediate(HealthManager.instance);
		SceneManager.LoadScene("VictoryScene");
	}

	public void PlayerDeathMenu()
	{
		HealthManager.instance.enabled = false;
		SceneManager.LoadScene("menuScene");
	}

}
