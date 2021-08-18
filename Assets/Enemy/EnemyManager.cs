using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_enemyObs = new GameObject[0];

    [SerializeField] private Transform m_setMinPos;
    [SerializeField] private Transform m_setMaxPos;

    [SerializeField] int m_setEnemy;

    static List<GameObject> m_enemyList = new List<GameObject>();

    static int m_getEnemy;
    static Transform m_getMinPos;
    static Transform m_getMaxPos;
    static GameObject[] m_getEnemyObs = new GameObject[0];

    void Start()
    {
        GetSet();
        SetEnemys();
    }

    void GetSet()
    {
        m_getEnemy = m_setEnemy;
        m_getMinPos = m_setMinPos;
        m_getMaxPos = m_setMaxPos;
        m_getEnemyObs = m_enemyObs;
    }

    void SetEnemy(int i)
    {
        float posX = Random.Range(m_getMinPos.position.x, m_getMaxPos.position.x);
        float posY = Random.Range(m_getMinPos.position.y, m_getMaxPos.position.y);

        Vector2 setPos = new Vector2(posX, posY);

        int set = Random.Range(0, m_getEnemyObs.Length);
        GameObject enemy = Instantiate(m_getEnemyObs[set], setPos, Quaternion.identity);
        enemy.name = $"Enemy{i + 1}";

        m_enemyList.Add(enemy);
    }

    void SetEnemys()
    {
        for (int i = 0; i < m_getEnemy; i++)
        {
            SetEnemy(i);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        m_enemyList.Remove(enemy);

        if (m_enemyList.Count < 1) { SetEnemys(); }
    }
}
