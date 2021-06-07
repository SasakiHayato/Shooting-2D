﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform nozzleTransform;
    [SerializeField] private GameObject bulletObject;

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
        GameObject bullet = Instantiate(bulletObject, nozzleTransform.position, nozzleTransform.rotation);
        bullet.transform.SetParent(this.transform);
    }
}
