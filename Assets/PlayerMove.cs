using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float m_speed;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("L_Horizontal");
        float v = Input.GetAxisRaw("L_Vertical") * -1;

        m_rb.velocity = new Vector2(h, v) * m_speed;
    }
}
