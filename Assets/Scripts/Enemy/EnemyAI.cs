using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region Variables
    [Space]
    [SerializeField] Transform Target;
    [SerializeField] float Speed;
    [SerializeField] float Distance_to_Player;
    [Space]

    [Header("Components")]
    [Space]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator animator;




    #endregion

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Distance_to_Player = Vector2.Distance(transform.position, Target.position);

        // Move Animation
        animator.SetFloat("Distance_From_Player", Distance_to_Player);

        if(Distance_to_Player <= 10)
        {
            Chase();
        }
        else
        {
            StopChase();
        }
    }

    void Chase()
    {
        if(transform.position.x < Target.position.x) // Enemy is at the left side of the player, so it move right
        {
            // Move
            rb2d.velocity = new Vector2(Speed * Time.deltaTime, 0);
            // Facing
            transform.localScale = new Vector2(0.7120208f, this.transform.localScale.y * 1);
        }
        else if (transform.position.x > Target.position.x)// Enemy is at the right side of the player, so it move left
        {
            // Move
            rb2d.velocity = new Vector2(-Speed * Time.deltaTime, 0);
            // Facing
            transform.localScale = new Vector2(-0.7120208f, this.transform.localScale.y * 1);
        }
    }

    void StopChase()
    {
        // Stop Move
        rb2d.velocity = new Vector2(0, 0);
    }
}
