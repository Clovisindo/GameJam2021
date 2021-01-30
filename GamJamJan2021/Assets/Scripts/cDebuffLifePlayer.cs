using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDebuffLifePlayer : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cDebuffLifePlayer;
    private int damageDebuff = 1;

    public AudioClip debuffDischarge;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("CDebuffLifeCard") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        DO_NOT = false;
        cardValue = (int)enumTypeCard;

        debuffDischarge = Resources.Load<AudioClip>("paralyzer-discharge-01");
    }

    public override void SpecialEffect()
    {
        DebuffLifePlayer();
    }

    protected void DebuffLifePlayer()
    {
        // debufamos al jugador
        GameManager.instance.SetDescriptionText("So many fights make you feel tired and lose some health...");
        SoundManager.instance.PlaySingle(debuffDischarge);
        GameManager.instance.player.TakeDamage(damageDebuff);
        Debug.Log("El jugador pierde vida.");
        // activar animacion
        //GameManager.instance.player.attackUp(damageDebuff);
    }
}
