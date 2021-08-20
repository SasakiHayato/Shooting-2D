using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StraightEnemy : EnemyBase
{
    Rigidbody2D m_rb;
    [SerializeField] BulletClass m_bullet;
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
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 set = player.position - transform.position;

        m_rb.AddForce(set / 5, ForceMode2D.Impulse);
    }

    public override void Shoot()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 set = player.position - transform.position;

        m_bullet.Set(gameObject.transform, set.x / 10, set.y / 10);
    }

    public override void GetDamage()
    {
        int hp = RetuneHp();
        hp--;
        SetHp(hp);

        if (RetuneHp() < 0) { DesThis(this.gameObject); }
    }
}
