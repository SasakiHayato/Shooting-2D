using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform nozzleTransform;
    [SerializeField] private GameObject m_bullet;

    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            CreateBullet();
            timer = 0;
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(m_bullet, nozzleTransform.transform.position, nozzleTransform.transform.rotation);
        bullet.transform.SetParent(this.transform);
    }
}
