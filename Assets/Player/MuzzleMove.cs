using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleMove : MonoBehaviour
{
    private float m_dirX, m_dirY;

    void Update()
    {
        Transform playerPos = transform.root;

        m_dirX = Input.GetAxisRaw("R_Horizontal");
        m_dirY = Input.GetAxisRaw("R_Vertical") * -1;
        
        if (m_dirX != 0 || m_dirY != 0)
        {
            Dir(m_dirX, m_dirY, playerPos);
        }
        else
        {
            transform.position = playerPos.position;
        }
    }

    private void Dir(float h, float v, Transform playerPos)
    {
        float x = playerPos.position.x + h;
        float y = playerPos.position.y + v;

        transform.position = new Vector2(x, y);
    }

    public float DirX() { return m_dirX; }
    

    public float DirY() { return m_dirY; }

}
