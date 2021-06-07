using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5)
        {
            float x = Random.Range(-6.0f, 6.0f);
            Vector2 vector = new Vector2(x, 5.5f);
            Instantiate(enemy, vector, transform.rotation);

            timer = 0;
        }
    }
}
