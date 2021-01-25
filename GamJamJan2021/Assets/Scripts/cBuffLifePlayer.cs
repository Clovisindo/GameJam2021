using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBuffLifePlayer : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cBuffLifePlayer;
    private int healBonus = 1;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("CBuffLifeCard") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        cardValue = (int)enumTypeCard;
    }
    public override void SpecialEffect()
    {
        HealLifePlayer();
    }

    protected void HealLifePlayer()
    {
        // bufamos al jugador
        GameManager.instance.player.HealthDamage(healBonus);
        Debug.Log("El jugador gana vida.");
        // activar animacion
        //GameManager.instance.player.attackUp(attackBonus);
    }
}
