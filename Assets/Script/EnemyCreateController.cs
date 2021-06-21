using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject boss;

    GameManager manager;

    private float timer = 0;
    private float bossTimer = 0;

    Vector2 vector;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        vector = new Vector2(0, 3.5f);
    }
    void Update()
    {
        if (!manager.isPley) return;
        timer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        if (timer > 1.5)
        {
            float x = Random.Range(-6.0f, 6.0f);
            Vector2 vector = new Vector2(x, 5.5f);
            Instantiate(enemy, vector, transform.rotation);

            timer = 0;
        }

        if (bossTimer >= 40)
        {
            Instantiate(boss, vector, transform.rotation);
            bossTimer = 0;
        }
    }
}
