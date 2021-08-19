using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChafeClass : MonoBehaviour
{
    int m_chafeScore;
    [SerializeField] int m_setChafe;

    [SerializeField] Image m_meterImage;
    
    void Start()
    {
        m_meterImage.fillAmount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletClass bullet = collision.GetComponent<BulletClass>();
        if (bullet == null) return;
        if (bullet.RetuneEnum() == ParentEnum.Enemy)
        {
            MeterControl(ChafeScore());
        }
    }

    int ChafeScore()
    {
        m_chafeScore++;
        return m_chafeScore;
    }

    void MeterControl(int score)
    {
        m_meterImage.fillAmount = ((float)score / 100) * 2;
    }

    public int GetChafeScore()
    {
        return m_chafeScore;
    }

    public int ResetChafeScore()
    {
        m_chafeScore = 0;
        MeterControl(m_chafeScore);

        return m_chafeScore;
    }

    public int SetChafe()
    {
        return m_setChafe;
    }
}
