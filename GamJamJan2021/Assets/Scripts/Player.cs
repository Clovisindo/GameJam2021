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
        animator = GetComponent<Animator>();
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
        playerHealth -= damage;
        UpdatePlayerHealth();
    }
    /// <summary>
    /// Curar al jugador
    /// </summary>
    /// <param name="heal"></param>
    public void HealthDamage(int heal)
    {
        playerHealth += heal;
        UpdatePlayerHealth();
    }

    public void attackUp(int attUp)
    {
        playerAttack += attUp;

    }

    public void UpdatePlayerHealth()
    {
        HealthManager.instance.UpdateUIHealth(playerHealth);
    }

    public void UpdatePlayerAttack()
    {
        HealthManager.instance.UpdateUIAttack(playerHealth);
    }
}
