using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerManager
{
    [SerializeField] BulletClass m_bullet;
    
    PlayerSkillClass m_skill;
    MuzzleMove m_muzzle;
    ChafeClass m_chafe;

    void Start()
    {
        m_muzzle = FindObjectOfType<MuzzleMove>();
        m_skill = FindObjectOfType<PlayerSkillClass>();
        m_chafe = FindObjectOfType<ChafeClass>();
    }

    void Update()
    {
        if (Input.GetButton("Shot"))
        {
            if (m_muzzle.DirX() == 0 && m_muzzle.DirY() == 0) return;
            m_bullet.Set(transform.GetChild(0), m_muzzle.DirX(), m_muzzle.DirY());
        }

        if (Input.GetButtonDown("Shot2") && m_chafe.GetChafeScore() > m_chafe.SetChafe())
        {
            m_skill.DesEnemyBulletAll();
            m_chafe.ResetChafeScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletClass bullet = collision.GetComponent<BulletClass>();
        if (bullet == null) return;
        if (bullet.RetuneEnum() == ParentEnum.Enemy)
        {
            GetDamage();
        }
    }
}
