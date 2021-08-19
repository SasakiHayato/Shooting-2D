using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StraightEnemy : EnemyClass
{
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public override void AddDamage()
    {
        throw new System.NotImplementedException();
    }
}
