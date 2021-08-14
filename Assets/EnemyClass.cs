using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField] int m_Hp = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletClass bullet = collision.GetComponent<BulletClass>();
        if (bullet.RetuneEnum() == ParentEnum.Player)
        {
            GetDamage();
            Destroy(collision.gameObject);
        }
    }

    void GetDamage()
    {
        m_Hp--;
        Debug.Log(m_Hp);

        if (m_Hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
