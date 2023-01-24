using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamIndex : sbyte
{
    None = -1,
    Neutral = 0,
    Player,
    Enemy,
    Count
}


public class TeamComponent : MonoBehaviour
{
    [SerializeField] private TeamIndex _teamIndex = TeamIndex.None;
    public TeamIndex teamIndex
    {
        set
        {
            if (_teamIndex == value)
            {
                return;
            }

            _teamIndex = value;

           
        }
        get { return _teamIndex; }
    }

    private int Max_Health = 100;
    public int Current_Health = 0;

    void Awake()
    {
        Current_Health = Max_Health;
    }

    void Update()
    {
        if(Current_Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject); // Wait for second cuz with death animation
    }
}
