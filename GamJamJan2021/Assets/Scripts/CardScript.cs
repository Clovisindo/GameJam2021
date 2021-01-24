using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public static bool DO_NOT = false;// flag

    [SerializeField]
    private int _state;//estado
    [SerializeField]
    private int _cardValue;//valor
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;//dorso carta
    private Sprite _cardFace;//carta

    //public GameObject _manager;//manager

    // Start is called before the first frame update
    void Start()
    {
        _state = 1;
        //_manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()// inicializa cada carta desde el GameManager( se hace cada turno??)
    {
        _cardBack = GameManager.instance.GetComponent<GameManager>().getCardBack();
        _cardFace = GameManager.instance.GetComponent<GameManager>().getCardFace(_cardValue);

        flipcard();
    }

    public void flipcard()//segun el estado definido, se renueva el estado de la carta en el tablero
    {
        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;

        if (_state == 0 && !DO_NOT)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !DO_NOT)
            GetComponent<Image>().sprite = _cardFace;
    }
    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck()//rutina de vuelta a la carta
    {
        StartCoroutine(pause());
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.2F);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }
}
