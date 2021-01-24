using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDebuffAttackPlayer : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cDebuffAttackPlayer;
    private int attackDebuff = 1;

    protected override void Awake()
    {
      _cardFace = Resources.Load<Sprite>("CDebuffAttackCard") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
      _state = 1;
        cardValue = (int)enumTypeCard;
    }
  
    public override void SpecialEffect()
    {
        DebuffAttackPlayer();
    }

    protected void DebuffAttackPlayer()
    {
        // bufamos al jugador
        GameManager.instance.player.attackDown(attackDebuff);
        Debug.Log("El jugador pierde ataque.");
        // activar animacion
        //GameManager.instance.player.attackDown(attackDebuff);
    }
}
