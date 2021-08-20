using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] int m_hp;
    [SerializeField] EnemyManager m_enemyManager;
    [SerializeField] BulletClass m_scoreBullet;

    [SerializeField, Range(30, 360)] float m_angleToDes = 0;

    float m_intervalTime = 0;
    bool m_interval = false;

    public abstract void Shoot();
    public abstract void Move();
    public abstract void GetDamage();

    public bool Interval(float time)
    {
        m_intervalTime += Time.deltaTime;

        if (m_intervalTime > time)
        {
            m_intervalTime = 0;
            m_interval = true;
        }
        else
        {
            m_interval = false;
        }

        return m_interval;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletClass bullet = collision.GetComponent<BulletClass>();
        if (bullet == null) return;
        if (bullet.RetuneEnum() == ParentEnum.Player)
        {
            GetDamage();
            Destroy(collision.gameObject);
        }
    }

    public void DesThis(GameObject enemy)
    {
        for (float angle = 0; angle < 360; angle += m_angleToDes)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));
            
            m_scoreBullet.Set(gameObject.transform, dir.x / 5, dir.y / 5);
            m_scoreBullet.FindPlayer(GameObject.FindGameObjectWithTag("Player"));
        }
        RemoveEnemy(enemy);
        Destroy(gameObject);
    }

    void RemoveEnemy(GameObject enemy) { m_enemyManager.RemoveEnemy(enemy); }

    public int RetuneHp() { return m_hp; }
    public int SetHp(int hp) { return m_hp = hp; } 
}
