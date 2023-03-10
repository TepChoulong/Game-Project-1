using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    public float attackRange;

    Transform player;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerHealth.IsPlayerDead == false)
        {
            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>().Speed = 0;
                animator.SetTrigger("Attack");
            }
        }
        else if (PlayerHealth.IsPlayerDead == true)
        {
            Debug.Log("Player is Dead");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>().Speed = 80;
    }
}
