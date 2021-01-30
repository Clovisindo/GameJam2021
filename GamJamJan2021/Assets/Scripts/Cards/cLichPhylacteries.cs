using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLichPhylacteries : CardScript
{

    public new EnumTypeCards enumTypeCard = EnumTypeCards.cLichPhylactery;
    public eLichBoss enemy;
    private int damageToLich = 1;

    public AudioClip openFlask;
    public AudioClip lichSound;

    protected override void Awake()
    {
        _cardFace = Resources.Load<Sprite>("CLichPhylactery") as Sprite;
        _cardBack = Resources.Load<Sprite>("cardDown") as Sprite;
        _state = 1;
        DO_NOT = false;
        cardValue = (int)enumTypeCard;
        enemy = GameObject.FindGameObjectWithTag("LichBoss").GetComponent<eLichBoss>();

        openFlask = Resources.Load<AudioClip>("water-vial-fill-01");
        lichSound = Resources.Load<AudioClip>("Zombie_63");
    }

    public override void SpecialEffect()
    {
        GameManager.instance.SetDescriptionText("That make damage to The Lich, keep going on!!");
        SoundManager.instance.PlaySingle(openFlask);
        SoundManager.instance.PlaySingle(lichSound);
        enemy.LichTakeDamage(damageToLich);
    }
}
