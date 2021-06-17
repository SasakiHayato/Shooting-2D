using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private GameObject bulletPrefab;

    private float timer = 0;
    private float attackTimer = 0;


    [SerializeField] private float angle;
    [SerializeField] private float degree;
    private float theta;
    [SerializeField] float bulletSpeed;
    private float pi = Mathf.PI;
    private void Start()
    {
        

    }

    void Update()
    {
        Move();
        attackTimer += Time.deltaTime;
        if (attackTimer > 2)
        {
            AlwaysAttack();
            attackTimer = 0;
        }
    }

    void Move()
    {
        transform.Translate(speed / 16, 0, 0);
        timer += Time.deltaTime;
        if (timer > 2)
        {
            speed *= -1;
            timer = 0;
        }
    }

    
    void AlwaysAttack()
    {
        for (int i = 0; i <= (angle - 1); i++)
        {
            float angleRange = pi * (degree / 180);
            if (angle > 1)
            {
                theta = (angleRange / (angle - 1)) * i + 0.5f * (pi - angleRange);
            }
            else
            {
                theta = 0.5f * pi;
            }

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            BossbulletController bossbullet = bullet.GetComponent<BossbulletController>();
            bossbullet.theta = theta;
            bossbullet.velocity = bulletSpeed;
        }
    }
}
