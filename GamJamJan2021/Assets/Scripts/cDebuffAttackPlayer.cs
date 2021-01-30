using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDebuffAttackPlayer : CardScript
{
    public new EnumTypeCards enumTypeCard = EnumTypeCards.cDebuffAttackPlayer;
    private int attackDebuff = 1;

    public AudioClip debuffDischarge;

    protected override void Awake()
    {
      _cardFace = Resources.Load<Sprite>("CDebuffAttackCard") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
      _state = 1;
        DO_NOT = false;
        cardValue = (int)enumTypeCard;

        debuffDischarge = Resources.Load<AudioClip>("paralyzer-discharge-01");
    }
  
    public override void SpecialEffect()
    {
        DebuffAttackPlayer();
    }

    protected void DebuffAttackPlayer()
    {
        // bufamos al jugador
        GameManager.instance.SetDescriptionText("Lose your weapon and fight with a tiny sword...");
        SoundManager.instance.PlaySingle(debuffDischarge);
        GameManager.instance.player.attackDown(attackDebuff);
        Debug.Log("El jugador pierde ataque.");
        // activar animacion
        //GameManager.instance.player.attackDown(attackDebuff);
    }
}
