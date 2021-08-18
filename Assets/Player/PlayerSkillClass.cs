using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillClass : MonoBehaviour
{
    [SerializeField] BulletClass m_scoreBullet;

    public void DesEnemyBulletAll()
    {
        GameObject[] bulletArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject bullet in bulletArray)
        {
            SetScoreBullet(bullet);
            Destroy(bullet);
        }
    }

    private void SetScoreBullet(GameObject bullet)
    {
        Transform set = bullet.transform;
        GameObject scoreBullet = Instantiate(m_scoreBullet.gameObject);

        scoreBullet.transform.position = new Vector2(set.position.x, set.position.y);
        m_scoreBullet.FindPlayer(this.gameObject);
    }
}
