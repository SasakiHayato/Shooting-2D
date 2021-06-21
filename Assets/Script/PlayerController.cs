﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform nozzleTransform;
    [SerializeField] private GameObject m_bullet;

    [SerializeField] public float hp = 0;

    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            BulletCreate();
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(h / 16, v / 16, 0);
    }

    void BulletCreate()
    {
        GameObject bullet = Instantiate(m_bullet, nozzleTransform.position, nozzleTransform.rotation);
        bullet.transform.SetParent(this.transform);
    }

    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            manager.isPley = false;
            Destroy(this.gameObject);
        }
    }
}
