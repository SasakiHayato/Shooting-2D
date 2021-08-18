using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChafeClass : MonoBehaviour
{
    int m_chafeScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletClass bullet = collision.GetComponent<BulletClass>();
        if (bullet == null) return;
        if (bullet.RetuneEnum() == ParentEnum.Enemy)
        {
            ChafeScore();
        }
    }

    void ChafeScore()
    {
        m_chafeScore++;
    }

    public int GetChafeScore()
    {
        return m_chafeScore;
    }

    public int ResetChafeScore()
    {
        m_chafeScore = 0;
        return m_chafeScore;
    }
}
