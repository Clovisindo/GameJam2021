using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDoorNextLevel : MonoBehaviour
{
   
    public void InvokeNextLevel()
    {
        GameManager.instance._board.NextLevel();
    }
}
