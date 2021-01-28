using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    int level = 1;
    int difficulty = 1;

    int playerAtk = 1;
    int monsterKilled = 0;
    int movesPlayed = 0;

    int _pairCardsToWin = 0;
    int _failMovesToDamage = 0;

    bool currentDoorOpen = false;
    public bool nextLevel = false;
    private int _nCardsGoblin;
    private int _nCardsOrc;
    private int _nCardsBuffAtk;
    private int _nCardsBuffLife;
    private int _nCardsDebuffAtk;
    private int _nCardsDebugsLife;


    int comboStrike = 0;
    int totalMonsterGenerated = 0;
    int totalMovesLevel = 0;
    int totalCardsLevel = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //dificultad nivel 1
        _pairCardsToWin = 4;
        _failMovesToDamage = 4;
        _nCardsGoblin = 2;
        _nCardsOrc = 0;
        _nCardsBuffAtk = 2;
        _nCardsBuffLife = 2;
        _nCardsDebuffAtk = 2;
        _nCardsDebugsLife = 0;

        //instanciamos los parametros del primer nivel
        GameManager.instance.SetParametersNewLevel(_pairCardsToWin, _failMovesToDamage, _nCardsGoblin, _nCardsOrc, _nCardsBuffAtk,
        _nCardsBuffLife, _nCardsDebuffAtk, _nCardsDebugsLife, level);
        CalculateMonsterGenerated();
    }

   

    public void NextLevel()
    {
        nextLevel = true;
        // actualizamos valores necesarios desde GameManager??

        //formula de dificultad dinamica
        GenerateDificultyNewlevel();

        // aplicamos la dificultad a los parametros del GameManager
        ApplyDifficulty();

        //instanciamos el nuevo nivel
        GenerateNewBoard();
    }

    private void GenerateDificultyNewlevel()
    {
        difficulty = 0;
        //actualizamos datos necesarios para calcular la dificultad
        UpdateTotalCardsLevel();
        UpdateTotalMovesLevel();

        //calculamos la nueva dificultad
        CheckDifAtkPlayer();
        CheckMonsterKilled();
        CheckMovesPlayed();

        //actualizamos los datos de dificultad para el siguiente nivel
        //hechos a mano segun la dificultad
        SetNewDifficulty();
    }

    private void SetNewDifficulty()
    {
        switch (difficulty)
        {
            case 1:
            case 2:
            case 3:
                _pairCardsToWin = 2;
                _failMovesToDamage = 4;
                _nCardsGoblin = 2;
                _nCardsOrc = 0;
                _nCardsBuffAtk = 2;
                _nCardsBuffLife = 2;
                _nCardsDebuffAtk = 2;
                _nCardsDebugsLife = 0;
                break;

            case 4:
            case 5:
            case 6:
                _pairCardsToWin = 3;
                _failMovesToDamage = 3;
                _nCardsGoblin = 2;
                _nCardsOrc = 2;
                _nCardsBuffAtk = 2;
                _nCardsBuffLife = 0;
                _nCardsDebuffAtk = 2;
                _nCardsDebugsLife = 0;
                break;

            case 7:
            case 8:
            case 9:
                _pairCardsToWin = 4;
                _failMovesToDamage = 2;
                _nCardsGoblin = 2;
                _nCardsOrc = 4;
                _nCardsBuffAtk = 2;
                _nCardsBuffLife = 0;
                _nCardsDebuffAtk = 0;
                _nCardsDebugsLife = 0;
                break;
        }

        level++;
    }

    private void CheckDifAtkPlayer()
    {
        switch (playerAtk)
        {
            case 3:
                difficulty += 1;
                break;
            case 2:
                difficulty += 2;
                break;
            case 1:
                difficulty += 3;
                break;
        }
    }

    private void CheckMonsterKilled()
    {
        if (monsterKilled == 0)
        {
            difficulty += 1;
        }
        else if (Utilities.Between(monsterKilled,0,totalMonsterGenerated/2,true))
        {
            difficulty += 2;
        }
        else if (Utilities.Between(monsterKilled, (totalMonsterGenerated / 2 )+ 1, totalMonsterGenerated, true))
        {
            difficulty += 3;
        }

    }

    private void CheckMovesPlayed()
    {
        if (Utilities.Between(movesPlayed, 0, (totalMovesLevel / 2) + 2, true))
        {
            difficulty += 1;
        }
        else if (Utilities.Between(movesPlayed, (totalMovesLevel / 2) + 3, (totalMovesLevel / 2) + 4, true))
        {
            difficulty += 2;
        }
        else if (Utilities.Between(movesPlayed, (totalMovesLevel / 2) + 5, (totalMovesLevel / 2) + 6, true))
        {
            difficulty += 3;
        }
        else if (movesPlayed > (totalMovesLevel / 2) + 6)
        {
            difficulty += 3;
        }
    }

    /// <summary>
    /// recibimos los datos de la ultima fase para actualizar la dificultad
    /// </summary>
    /// <param name="_playerAtk"></param>
    /// <param name="_monsterKilled"></param>
    /// <param name="_movesPlayed"></param>
    public void SetBoardNewLevelParameters(int _playerAtk, int _monsterKilled, int _movesPlayed)
    {
        playerAtk = _playerAtk;
        monsterKilled = _monsterKilled;
        movesPlayed = _movesPlayed;
    }

    private void ApplyDifficulty()
    {
       
        //asignamos los parametros ya cargados de la dificultad al GameManager
        GameManager.instance.SetParametersNewLevel(_pairCardsToWin, _failMovesToDamage, _nCardsGoblin, _nCardsOrc, _nCardsBuffAtk,
        _nCardsBuffLife, _nCardsDebuffAtk, _nCardsDebugsLife, level);
        CalculateMonsterGenerated();//actualizamos los monstruos generados
    }

    private void CalculateMonsterGenerated()
    {
        totalMonsterGenerated = _nCardsGoblin + _nCardsOrc;
    }

    private void GenerateNewBoard()
    {
        GameManager.instance.initializeCards();
    }

    private void UpdateTotalMovesLevel()
    {
        totalMovesLevel = totalCardsLevel / 2;
    }

    private void UpdateTotalCardsLevel()
    {
        totalCardsLevel = _nCardsGoblin + _nCardsOrc + _nCardsBuffAtk + _nCardsBuffLife + _nCardsDebuffAtk + _nCardsDebugsLife;
    }

    
}
