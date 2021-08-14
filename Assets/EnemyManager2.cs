using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    [SerializeField] GameObject[] m_enemy = new GameObject[0];

    [SerializeField] Transform m_setMinPos;
    [SerializeField] Transform m_setMaxPos;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            float posX = Random.Range(m_setMinPos.position.x, m_setMaxPos.position.x);
            float posY = Random.Range(m_setMinPos.position.y, m_setMaxPos.position.y);

            Vector2 setPos = new Vector2(posX, posY);

            int set = Random.Range(0, m_enemy.Length);
            Instantiate(m_enemy[set], setPos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
