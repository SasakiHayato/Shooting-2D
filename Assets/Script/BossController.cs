using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    private float timer = 0;
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(speed / 16, 0, 0);
        timer += Time.deltaTime;
        if (timer > 1)
        {
            speed *= -1;
            timer = 0;
        }
    }
}
