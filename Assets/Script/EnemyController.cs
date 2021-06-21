using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform nozzleTransform;
    [SerializeField] private GameObject m_bullet;

    GameManager manager;

    private float timer = 0;
    private float vectorY = 0;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        vectorY = Random.Range(-0.2f, -0.05f);
    }

    void Update()
    {
        if (!manager.isPley)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(0, vectorY / 8, 0);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            Destroy(this.gameObject);
        }
    }
}
