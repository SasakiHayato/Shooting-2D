using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContoller : EnemyBase
{
    [SerializeField] BulletClass m_bullet;
    [SerializeField] Transform[] m_setPosArray = new Transform[0];
    [SerializeField] Transform m_attackPos;
    [SerializeField] BossAttack m_bossAttack;

    bool m_set = false;
    bool m_startAttack = false;
    bool m_cureantAttack = false;
    Transform m_setPos;
    float m_hpPasent;
    float m_cureantHp;

    void Start()
    {
        m_hpPasent = (float)RetuneHp() / 100;
        m_cureantHp = m_hpPasent;
    }

    void Update()
    {
        if (Interval(1f))
        {
            Shoot();
        }

        if (!m_startAttack)
        {
            Move();
        }
        HpCheck();
    }

    public override void Move()
    {
        if (!m_set) 
        {
            int random = Random.Range(0, m_setPosArray.Length);
            m_setPos = m_setPosArray[random];
            m_set = true;
        }

        if (transform.position != m_setPos.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_setPos.position, Time.deltaTime * 4);
        }
        else
        {
            m_set = false;
        }
        
    }

    public override void Shoot()
    {
        for (int angle = 0; angle < 360; angle += 20)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));

            m_bullet.Set(gameObject.transform, dir.x, dir.y);
        }
    }

    void HpCheck()
    {
        if (RetuneHp() < m_hpPasent * 80 && !m_bossAttack.PhaseOneCheck())
        {
            m_startAttack = true;
            AttackToMove();
            if (m_cureantAttack)
            {
                m_bossAttack.PhaseOne();
            }
        }
        else if (RetuneHp() < m_cureantHp * 50 && !m_bossAttack.PhaseTowCheck())
        {
            m_startAttack = true;
            AttackToMove();
            if (m_cureantAttack)
            {
                m_bossAttack.PhaseTow();
            }
        }
    }

    void AttackToMove()
    {
        if (transform.position != m_attackPos.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_attackPos.position, Time.deltaTime * 4);
        }
        else
        {
            m_cureantAttack = true;
        }
    }
}
