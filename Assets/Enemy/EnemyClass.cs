using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyClass : MonoBehaviour
{
    [SerializeField] int m_hp;
    [SerializeField] EnemyManager m_enemyManager;
    [SerializeField] BulletClass m_bullet;
    [SerializeField, Range(30, 360)] float m_angleToDes = 0;

    public abstract void AddDamage();

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

    void GetDamage()
    {
        m_hp--;

        if (m_hp < 0)
        {
            m_enemyManager.RemoveEnemy(this.gameObject);
            DesThis();
        }
    }

    void DesThis()
    {
        for (float angle = 0; angle < 360; angle += m_angleToDes)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));

            m_bullet.Set(gameObject.transform, dir.x, dir.y);
        }
        Destroy(gameObject);
    }
}
