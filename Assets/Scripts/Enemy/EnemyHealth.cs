using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Variables

    public int Max_Health = 100;
    public int Current_Health = 0;
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
        GetComponent<Animator>().SetTrigger("Get_Hit");
        // Play the hurt sound

        if (Current_Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Disable AI Script
        GetComponent<EnemyAI>().enabled = false;
        // Disable Collision
        GetComponent<Collider2D>().enabled = false;
        // Play Death Animation
        GetComponent<Animator>().SetBool("IsDead", true);    
        // Disable Gravity
        GetComponent<Rigidbody2D>().gravityScale = 0;
        // Play Death Sound
        // Wait 3s then Destroy it
        Destroy(gameObject, 4f);
    }
}
