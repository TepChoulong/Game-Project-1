using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Variables

    public int Max_Health = 100;
    public int Current_Health = 0;

    public static bool IsPlayerDead;
    #endregion

    void Start()
    {
        Current_Health = Max_Health;
    }

    public void Take_Damage(int Damage)
    {
        // Deduct the current health of the enemy
        Current_Health -= Damage;
        // Play hit animation
        GetComponent<Animator>().SetTrigger("Take_Damage");
        // Play the hurt sound

        if (Current_Health <= 0)
        {
            IsPlayerDead = true;
            Die();
        }
        else if (Current_Health > 0)
        {
            IsPlayerDead = false;
        }
    }

    void Die()
    {
        //Disable AI Script
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>().enabled = false;
        // Disable Collision
        GetComponent<Collider2D>().enabled = false;
        // Play Death Animation
        GetComponent<Animator>().SetBool("IsDead", true);    
        // Disable Gravity
        GetComponent<Rigidbody2D>().gravityScale = 0;
        // Play Death Sound
        // Wait 3s then Destroy it
        Destroy(gameObject, 3f);
    }
}
