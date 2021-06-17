using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossbulletController : MonoBehaviour
{
    public float theta;
    public float velocity;
    
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 vector = rigidbody.velocity;
        vector.x = velocity * Mathf.Cos(theta);
        vector.y = velocity * Mathf.Sin(theta);
        rigidbody.velocity = vector;
    }

    private float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
    }
}
