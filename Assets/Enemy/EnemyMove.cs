using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    private enum EnemyType
    {
        Straight,
    }

    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Straight();
    }

    void Straight()
    {
        m_rb.AddForce(new Vector2(0, -7), ForceMode2D.Impulse);
    }
}
