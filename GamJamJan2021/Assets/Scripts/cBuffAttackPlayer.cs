using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBuffAttackPlayer : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cBuffAttackPlayer;
    private int attackBonus = 1;

    public AudioClip buffSound;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("CBuffAttackCard") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        cardValue = (int)enumTypeCard;

        buffSound = Resources.Load<AudioClip>("Powerup_03");
    }

    public override void SpecialEffect()
    {
        BuffAttackPlayer();
    }

    protected void BuffAttackPlayer()
    {
        // bufamos al jugador
        SoundManager.instance.PlaySingle(buffSound);
        GameManager.instance.player.attackUp(attackBonus);
        Debug.Log("El jugador sube ataque.");
        // activar animacion
        //GameManager.instance.player.attackUp(attackBonus);
    }
}
