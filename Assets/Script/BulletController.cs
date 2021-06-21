using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, speed / 8, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyManager enemy;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<EnemyManager>();
            enemy.Damage();

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            Destroy(this.gameObject);
        }
    }
}
