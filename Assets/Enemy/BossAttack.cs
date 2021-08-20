using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] BulletClass m_bullet;
    [SerializeField] Transform[] m_setPos = new Transform[0];

    public void PhaseOne()
    {
        for (int set = 0; set < m_setPos.Length; set++)
        {
            GameObject bullet = Instantiate(m_bullet.gameObject);
            bullet.transform.position = m_setPos[set].position;
        }
    }
}
