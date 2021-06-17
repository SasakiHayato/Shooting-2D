using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    UiController uiController;
    [SerializeField] private float hp = 0;

    void Start()
    {
        GameObject ui = GameObject.Find("UiController");
        uiController = ui.GetComponent<UiController>();
    }

    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            uiController.ScoreCheck();
            Destroy(this.gameObject);
        }
    }
}
