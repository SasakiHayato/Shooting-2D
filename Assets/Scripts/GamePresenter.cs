using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnStart();
    }

    private void OnDestroy()
    {
        GameManager.Instance.Dispose();
    }
}
