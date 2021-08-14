using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    [SerializeField] float m_shotPower = 0;
    float m_desTime = 1;

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

    private void Update()
    {
        m_desTime -= Time.deltaTime;
        if (m_desTime < 0) { Destroy(gameObject); }
    }
}
