using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContoller : EnemyBase
{
    [SerializeField] BulletClass m_bullet;
    [SerializeField] Transform[] m_setPosArray = new Transform[0];
    [SerializeField] Transform m_attackPos;
    [SerializeField] BossAttack m_bossAttack;
    [SerializeField] BossManager m_manager;

    bool m_set = false;
    bool m_cureantAttack = false;
    Transform m_setPos;
    float m_hpPasent;

    void Start()
    {
        m_hpPasent = (float)RetuneHp() / 100;
    }

    void Update()
    {
        if (Interval(1f) && !m_manager.AttackPhaseCurreant()) { Shoot(); }

        if (!m_manager.AttackPhaseCurreant()) { Move(); }
        else { AttackToMove(); }

        if (m_cureantAttack) { m_bossAttack.PhaseOne(); }
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
    public override void GetDamage()
    {
        int hp = RetuneHp();
        hp--;
        SetHp(hp);
        HpCheck();
        if (RetuneHp() < 0) { DesThis(this.gameObject); }
    }

    void HpCheck()
    {
        if (RetuneHp() < m_hpPasent * 80 && !m_manager.AttackPhaseCurreant())
        {
            m_manager.SetAttackPhase(true);
        }
    }

    void AttackToMove()
    {
        if (transform.position != m_attackPos.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_attackPos.position, Time.deltaTime * 4);
        }
        else { m_cureantAttack = true; }
    }
}
