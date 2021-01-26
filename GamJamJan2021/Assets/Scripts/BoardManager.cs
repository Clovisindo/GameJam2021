using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    int level = 1;
    int difficulty = 1;

    int comboStrike = 0;
    int currentMoves = 0;
    int currentEnemyKills = 0;

    int totalMoves = 0;
    int totalMovesFail = 0;

    bool currentDoorOpen = false;
    public bool nextLevel = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void NextLevel()
    {
        nextLevel = true;
        // actualizamos valores necesarios desde GameManager??

        // aplicamos formula de dificultad
        ApplyDifficulty();

        //instanciamos el nuevo nivel
        GenerateNewBoard();
    }


    private void GenerateNewBoard()
    {
        GameManager.instance.initializeCards();//ToDo:Pasar parametros de dificultad
    }

    private void ApplyDifficulty()
    {
        // tener en cuenta el ataque del jugador
        //numero de movimientos realizados
        //racha de ventajas

        //Assignar el numero de fallos para recibir daño

    }
}
