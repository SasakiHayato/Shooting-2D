using UnityEngine;

/// <summary>
/// Manager‚ÌŠî’êƒNƒ‰ƒX
/// </summary>

public abstract class ManagerBase : MonoBehaviour
{
    public static int InstanceID { get; private set; }

    void Awake()
    {
        InstanceID = GetInstanceID();

        GameManager.Instance.SetOnStartAction(GetInstanceID(), () => SetUp());
        GameManager.Instance.AddMaager(this);
    }

    protected abstract void SetUp();

    void OnDestroy()
    {
        GameManager.Instance.RemoveManager(this);
    }
}
