using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParentEnum
{
    Player,
    Enemy,

    ScoreBullet,
}

[RequireComponent(typeof(Rigidbody2D))]
public class BulletClass : MonoBehaviour
{
    [SerializeField] ParentEnum m_parent;
    [SerializeField] float m_shotPower = 0;

    static Transform m_playerPos;
    Vector2 m_setVec = Vector2.zero;

    float m_desTimeForPlayer = 0;

    /// <summary> Bullet Set </summary>
    
    /// <param name="x">dirX</param>
    /// <param name="y">dirY</param>
    public void Set(Transform parent, float x, float y)
    {
        GameObject bullet = Instantiate(gameObject, parent.transform.position, Quaternion.identity);
        
        Shot(bullet, x, y);
    }

    private void Shot(GameObject bullet, float x, float y)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(x, y);

        rb.AddForce(force * m_shotPower, ForceMode2D.Impulse);
    }

    public Transform FindPlayer(GameObject player)
    {
        m_playerPos = player.transform;
        return m_playerPos;
    }

    void Update()
    {
        if (m_parent == ParentEnum.Player)
        {
            m_desTimeForPlayer += Time.deltaTime;
            if (m_desTimeForPlayer > 1)
            {
                Destroy(gameObject);
            }
        }
        else if (m_parent == ParentEnum.ScoreBullet)
        {
            if (m_playerPos == null) return;
            m_setVec = new Vector2(m_playerPos.position.x, m_playerPos.position.y);
            transform.position = Vector2.MoveTowards(transform.position, m_setVec, m_shotPower * Time.deltaTime);
        }
    }

    public ParentEnum RetuneEnum()
    {
        return m_parent;
    }

    public ParentEnum SetEnum(ParentEnum parent)
    {
        m_parent = parent;
        return m_parent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player") && m_parent == ParentEnum.ScoreBullet)
        {
            ScoreClass score = FindObjectOfType<ScoreClass>();
            score.AddScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            Destroy(gameObject);
        }
    }
}
