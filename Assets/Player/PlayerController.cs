using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerManager
{
    [SerializeField] BulletClass m_bullet;
    [SerializeField] PlayerSkillClass m_skill;
    MuzzleMove m_muzzle;

    void Start()
    {
        m_muzzle = FindObjectOfType<MuzzleMove>();
    }

    void Update()
    {
        if (Input.GetButton("Shot"))
        {
            if (m_muzzle.DirX() == 0 && m_muzzle.DirY() == 0) return;
            m_bullet.Set(transform.GetChild(0), m_muzzle.DirX(), m_muzzle.DirY());
        }

        if (Input.GetButtonDown("Shot2") && m_chafe.GetChafeScore() > 10)
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
