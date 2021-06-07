using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    void Update()
    {
        transform.Translate(0, speed / 8, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player;
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerController>();
            player.Damage();

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
