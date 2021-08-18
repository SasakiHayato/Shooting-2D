using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    ScoreClass m_scoreClass;
    [SerializeField] Text m_scoreText;

    void Start()
    {
        m_scoreClass = FindObjectOfType<ScoreClass>();
    }

    void Update()
    {
        m_scoreText.text = m_scoreClass.SetScore().ToString($"Score : {0}");
    }
}
