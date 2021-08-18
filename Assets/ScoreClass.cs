using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreClass : MonoBehaviour
{
    static int m_totalScore = 0;
    int m_upScore = 100;

    public void AddScore()
    {
        m_totalScore += m_upScore;
    }

    public int SetScore()
    {
        return m_totalScore;
    }
}
