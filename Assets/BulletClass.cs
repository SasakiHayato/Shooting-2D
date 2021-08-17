using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParentEnum
{
    Player,
    Enemy,
}

[RequireComponent(typeof(Rigidbody2D))]
public class BulletClass : MonoBehaviour
{
    [SerializeField] ParentEnum m_parent;
    [SerializeField] float m_shotPower = 0;

    float m_desTimeForPlayer = 0;

    /// <summary> Bullet Set </summary>
    
    /// <param name="x">dirX</param>
    /// <param name="y">dirY</param>
    public void Set(Transform parent, float x, float y)
    {
        GameObject bullet = Instantiate(gameObject, parent.transform.position, Quaternion.identity);
        
        Shot(bullet, x, y);
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
    }

    private void Shot(GameObject bullet, float x, float y)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(x, y);
        
        rb.AddForce(force * m_shotPower, ForceMode2D.Impulse);
    }

    public ParentEnum RetuneEnum()
    {
        return m_parent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
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
