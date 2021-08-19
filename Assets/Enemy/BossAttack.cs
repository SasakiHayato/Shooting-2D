using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    bool m_attackCreant = false;

    bool m_phaseOne = false;
    bool m_phaseTow = false;

    public bool AttackCreant()
    {
        return m_attackCreant;
    }

    public void PhaseOne()
    {
        if (m_phaseOne) return;

        Debug.Log("a");
    }
    public bool PhaseOneCheck()
    {
        return m_phaseOne;
    }

    public void PhaseTow()
    {
        if (m_phaseTow) return;
        Debug.Log("b");
    }
    public bool PhaseTowCheck()
    {
        return m_phaseOne;
    }
}
