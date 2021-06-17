using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float hp = 0;
    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
