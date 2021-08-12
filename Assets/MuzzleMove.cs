using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleMove : MonoBehaviour
{
    [SerializeField] float m_distans = 0;
    void Update()
    {
        Transform playerPos = transform.root;

        float h = Input.GetAxisRaw("R_Horizontal");
        float v = Input.GetAxisRaw("R_Vertical") * -1;
        
        if (h != 0 || v != 0)
        {
            Dir(h, v, playerPos);
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

        transform.position = new Vector2(x, y) * m_distans;
    }
}
