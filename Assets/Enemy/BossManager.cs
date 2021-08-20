using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    bool m_attackPhase = false;

    public bool SetAttackPhase(bool setBool) { return m_attackPhase = setBool; }
    public bool AttackPhaseCurreant() { return m_attackPhase; }
}
