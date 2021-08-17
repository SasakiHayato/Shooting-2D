using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] BulletClass m_bullet;
    MuzzleMove m_muzzle;

    void Start()
    {
        m_muzzle = FindObjectOfType<MuzzleMove>();
    }

    void Update()
    {
        if (Input.GetButton("Shot"))
        {
            if (m_muzzle.DirX() == 0 && m_muzzle.DirY() == 0) return;
            m_bullet.Set(transform.GetChild(0), m_muzzle.DirX(), m_muzzle.DirY());
        }
    }
}
