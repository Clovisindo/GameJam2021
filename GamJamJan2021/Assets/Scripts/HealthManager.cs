﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int attack;

    public int numOfHearts = 3;
    public int numOfAttackPower = 3;
    public static HealthManager instance = null;
    public Canvas UICanvas;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public Image[] attacks;
    public Sprite fullAttack;
    public Sprite emptyAttack;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        UICanvas = GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<Canvas>();
        hearts = Utilities.getAllChildsObjectWithTag<Image>(UICanvas.transform, "LifesUI").ToArray();
        attacks = Utilities.getAllChildsObjectWithTag<Image>(UICanvas.transform, "AttackPowerUI").ToArray();

        Init();
    }

    private void Init()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            // este if define cuando el corazon carga la imagen rellena o no, segun la cantidad de vida
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // controla el numero de corazones maximos que se muestran( los previamente creados en los objetos)
            //mejora para esto seria instanciarlo desde el iniciador
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        //attack
        if (attack > numOfAttackPower)
        {
            attack = numOfAttackPower;
        }
        for (int i = 0; i < attacks.Length; i++)
        {
            // este if define cuando el corazon carga la imagen rellena o no, segun la cantidad de vida
            if (i < attack)
            {
                attacks[i].sprite = fullAttack;
            }
            else
            {
                attacks[i].sprite = emptyAttack;
            }

            // controla el numero de corazones maximos que se muestran( los previamente creados en los objetos)
            //mejora para esto seria instanciarlo desde el iniciador
            if (i < numOfAttackPower)
            {
                attacks[i].enabled = true;
            }
            else
            {
                attacks[i].enabled = false;
            }
        }
    }

    private void Update()
    {
        if (UICanvas == null )//ToDo: arreglar ñapa forzando la carga de otra forma o no recargar escenas
        {
            DestroyImmediate(UICanvas);
            UICanvas = GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<Canvas>();
            hearts = Utilities.getAllChildsObjectWithTag<Image>(UICanvas.transform, "LifesUI").ToArray();
            attacks = Utilities.getAllChildsObjectWithTag<Image>(UICanvas.transform, "AttackPowerUI").ToArray();
        }
        //health
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            // este if define cuando el corazon carga la imagen rellena o no, segun la cantidad de vida
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // controla el numero de corazones maximos que se muestran( los previamente creados en los objetos)
            //mejora para esto seria instanciarlo desde el iniciador
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        //attack
        if (attack > numOfAttackPower)
        {
            attack = numOfAttackPower;
        }
        for (int i = 0; i < attacks.Length; i++)
        {
            // este if define cuando el corazon carga la imagen rellena o no, segun la cantidad de vida
            if (i < attack)
            {
                attacks[i].sprite = fullAttack;
            }
            else
            {
                attacks[i].sprite = emptyAttack;
            }

            // controla el numero de corazones maximos que se muestran( los previamente creados en los objetos)
            //mejora para esto seria instanciarlo desde el iniciador
            if (i < numOfAttackPower)
            {
                attacks[i].enabled = true;
            }
            else
            {
                attacks[i].enabled = false;
            }
        }
    }

    public void UpdateUIHealth(int _health)
    {
        if (_health <= numOfHearts)
        {
            health = _health;
        }
        
        if (health <= 0)
        {
            GameManager.instance.PlayerDeathMenu();
        }
    }
    public void UpdateUIAttack(int _attack)
    {
        if (_attack <= numOfAttackPower || _attack > 0)
        {
            attack = _attack;
        }
        
    }
}
