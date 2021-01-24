using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardFactory 
{
    // Start is called before the first frame update
   
    public static CardScript GetTypeCard( int _cardValue)
    {
        CardScript card;
        if (_cardValue == 1)
        {
            card = new cBuffAttackPlayer();
        }
        else if (true)
        {
            throw new Exception("no existe");
        }
        return card;
    }

}
