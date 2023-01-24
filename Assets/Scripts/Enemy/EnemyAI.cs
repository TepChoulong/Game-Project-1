using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region Variables
    Rigidbody2D rb2d;
    [SerializeField] Transform Target;
    [SerializeField] float Speed;

    [SerializeField] float Range;

    float Distance_to_Player;

    #endregion

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Distance_to_Player = Vector2.Distance(transform.position, Target.position);

        if(Distance_to_Player > Range)
        {
            StopChase();
        }
        else
        {
            Chase();
        }
    }

    void Chase()
    {
        if(transform.position.x < Target.position.x) // Enemy is at the left side of the player, so it move right
        {
            // Move
            rb2d.velocity = new Vector2(Speed * Time.deltaTime, 0);
            // Facing
            transform.localScale = new Vector2(1, 1);
            // Move Animation
        }
        else if (transform.position.x > Target.position.x)// Enemy is at the right side of the player, so it move left
        {
            // Move
            rb2d.velocity = new Vector2(-Speed * Time.deltaTime, 0);
            // Facing
            transform.localScale = new Vector2(-1, 1);
            // Move Animation
        }
    }

    void StopChase()
    {
        // Stop Move
        rb2d.velocity = new Vector2(0, 0);
        // Play Idle Animation
    }
}
