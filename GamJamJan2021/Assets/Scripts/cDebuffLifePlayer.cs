using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDebuffLifePlayer : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cDebuffLifePlayer;
    private int damageDebuff = 1;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("CDebuffLifeCard") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        cardValue = (int)enumTypeCard;
    }

    public override void SpecialEffect()
    {
        DebuffLifePlayer();
    }

    protected void DebuffLifePlayer()
    {
        // bufamos al jugador
        GameManager.instance.player.TakeDamage(damageDebuff);
        Debug.Log("El jugador pierde vida.");
        // activar animacion
        //GameManager.instance.player.attackUp(damageDebuff);
    }
}
