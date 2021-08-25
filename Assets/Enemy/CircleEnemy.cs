using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : EnemyBase
{
    [SerializeField] BulletClass m_bullet;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Move();
    }

    void Update()
    {
        if (Interval(0.5f)) { Shoot(); }
    }
    public override void Move()
    {
        m_rb.AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
    }

    public override void Shoot()
    {
        for (int angle = 0; angle < 360; angle += 30)
        {
            float rad = angle * Mathf.Deg2Rad;
            m_bullet.Set(transform, Mathf.Cos(rad), Mathf.Sin(rad));
        }
    }

    public override void GetDamage()
    {
        int hp = RetuneHp();
        hp--;
        SetHp(hp);

        if (RetuneHp() < 0) { DesThis(this.gameObject); }
    }
}
