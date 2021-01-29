using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 3;
    public int playerAttack = 1; // con esto mediremos la dificultad dinamicamente

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Aplicar daño al jugador
    /// </summary>
    /// <param name="damage"> pasar el numero en valor absoluto</param>
    public void TakeDamage(int damage)
    {
        if ((playerHealth - damage) <= HealthManager.instance.numOfHearts)
        {
            playerHealth -= damage;
            UpdatePlayerHealth();
        }
    }
    /// <summary>
    /// Curar al jugador
    /// </summary>
    /// <param name="heal">pasar el numero en valor absoluto</param>
    public void HealthDamage(int heal)
    {
        if ((playerHealth + heal) <= HealthManager.instance.numOfHearts)
        {
            playerHealth += heal;
            UpdatePlayerHealth();
        }
    }
    /// <summary>
    /// Aplicar subida de daño al jugador
    /// </summary>
    /// <param name="attUp">pasar en valor absoluto</param>
    public void attackUp(int attUp)
    {
        if (playerAttack + attUp <= HealthManager.instance.numOfAttackPower || playerAttack + attUp > 0)
        {
            playerAttack += attUp;
            UpdatePlayerAttack();
        }
    }
    /// <summary>
    /// Aplicar la bajada de daño al jugador
    /// </summary>
    /// <param name="attDown">pasar en valor absoluto</param>
    public void attackDown(int attDown)
    {
        if (playerAttack - attDown <= HealthManager.instance.numOfAttackPower || playerAttack - attDown > 0)
        {
            playerAttack -= attDown;
            UpdatePlayerAttack();
        }
    }

    public void UpdatePlayerHealth()
    {
        HealthManager.instance.UpdateUIHealth(playerHealth);
    }

    public void UpdatePlayerAttack()
    {
        HealthManager.instance.UpdateUIAttack(playerAttack);
    }
}
