using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eLichBoss : MonoBehaviour
{
    int health = 3;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LichTakeDamage(int _damage)
    {
        health -= _damage;
        //ToDo: animacion y/o sonido daño

        if (health <= 0)
        {
            //ToDo: animacion y/o sonido muerte
            EndGame();
        }
    }

    public void SetLifeLich(int _life)
    {
        health = _life;
    }

    private void EndGame()
    {
        //terminamos el juego
        GameManager.instance.reMenu();//ToDo: crear escena de victoria
    }
}
