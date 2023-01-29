using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public LayerMask attackLayer;
    public int attackDamage;
    public float attackRange;
    public Vector3 attackOffset;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackLayer);
        if (colInfo != null)
        {
            Debug.Log("Hit Player");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Take_Damage(attackDamage);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
