using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboSystem : MonoBehaviour
{
    #region Variables

    public static PlayerComboSystem instance;

    Animator animator;
    public int combo_index = 1;
    [SerializeField] bool attack_combo;

    int attack_1_damage;
    int attack_2_damage;
    int attack_3_damage;

    public float attack_rate = 2f; // If this have changed : PlayerCombatSystem also change it too.
    float next_attack_time = 0f;

    [SerializeField] Transform GroundCheckPoint;
    [SerializeField] float Raduis;
    public LayerMask Layer_For_Ground;
    bool IsGrounded;

    #endregion

    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {   
        IsGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, Raduis, Layer_For_Ground);
        Combo_();
    }

    public void start_combo()
    {
        attack_combo = false;
        if (combo_index < 4)
        {
            combo_index++;
        }
    }

    public void finish_combo()
    {
        attack_combo = false;
        combo_index = 1;
    }

    void Combo_()
    {
        if (Time.time >= next_attack_time)
        {
            if (Input.GetMouseButtonDown(0) && !attack_combo && IsGrounded)
            {
                // attack_combo = true;
                animator.SetTrigger("Attack" + combo_index);
                next_attack_time = Time.time + 1f / attack_rate;
            }
        }
    }
}
