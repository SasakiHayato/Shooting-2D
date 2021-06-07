using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float hp = 2;
    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
