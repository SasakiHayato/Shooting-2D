using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int m_hp;
    [SerializeField] public ChafeClass m_chafe;

    public void GetDamage()
    {
        m_hp--;
        if (m_hp < 1)
        {
            Des();
        }
    }

    private void Des()
    {
        Destroy(gameObject);
    }
}
