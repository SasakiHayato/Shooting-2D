using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.SetOnStart(() => SetUp());
    }

    protected abstract void SetUp();
}
