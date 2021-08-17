using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_renderer;
    [SerializeField] float m_speed;
    SpriteRenderer m_clone;
    float m_posY;

    void Start()
    {
        m_posY = m_renderer.transform.position.y;

        m_clone = Instantiate(m_renderer);
        m_clone.transform.Translate(0, m_renderer.bounds.size.y, 0);
    }

    void Update()
    {
        m_renderer.transform.Translate(0, m_speed * Time.deltaTime, 0);
        m_clone.transform.Translate(0, m_speed * Time.deltaTime, 0);
        
        if (m_renderer.transform.position.y < m_posY - m_renderer.bounds.size.y)
        {
            m_renderer.transform.Translate(0, m_renderer.bounds.size.y * 2, 0);
        }
        if (m_clone.transform.position.y < m_posY - m_clone.bounds.size.y)
        {
            m_clone.transform.Translate(0, m_renderer.bounds.size.y, 0);
        }
    }
}
