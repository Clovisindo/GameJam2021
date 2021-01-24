using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBuffAttackPlayer : CardScript
{
    private EnumTypeCards type = EnumTypeCards.BuffAttackPlayer;
    private int attackBonus = 1;

    private void BuffAttackPlayer()
    {
        // bufamos al jugador
        GameManager.instance.player.attackUp(attackBonus);
        // activar animacion
        //GameManager.instance.player.attackUp(attackBonus);
    }
}
