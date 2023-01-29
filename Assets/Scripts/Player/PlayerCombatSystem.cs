using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    #region Variables

    int Attack_Damage_1;
    int Attack_Damage_2;
    int Attack_Damage_3;

    public Transform Attack_Point;
    [SerializeField] float Attack_Raduis;
    [SerializeField] LayerMask Enemy_Layer;

    public float attack_rate = 2f;
    float next_attack_time = 0f;

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        Attack_Damage_1 = Random.Range(4, 6);
        Attack_Damage_2 = Random.Range(6, 8);
        Attack_Damage_3 = Random.Range(8, 10);

        if (Time.time >= next_attack_time)
        {
            if (Input.GetMouseButtonDown(0))
            {   
                Attack();
                next_attack_time = Time.time + 1f / attack_rate;
            }
        }
    }

    void Attack()
    {
        Collider2D[] hit_Enemies = Physics2D.OverlapCircleAll(Attack_Point.position, Attack_Raduis, Enemy_Layer);

        foreach (Collider2D enemy in hit_Enemies)
        {
            if (PlayerComboSystem.instance.combo_index == 1)
            {
                enemy.GetComponent<EnemyHealth>().Take_Damage(Attack_Damage_1);
            } 
            else if (PlayerComboSystem.instance.combo_index == 2)
            {
                enemy.GetComponent<EnemyHealth>().Take_Damage(Attack_Damage_2);
            }
            else if (PlayerComboSystem.instance.combo_index == 3)
            {
                enemy.GetComponent<EnemyHealth>().Take_Damage(Attack_Damage_3);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Attack_Point.position, Attack_Raduis);
    }
}
