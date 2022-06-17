using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// �Q�[���S�̂̊Ǘ��N���X
/// </summary>

public class GameManager
{
    // Note. Singleton
    private static GameManager s_instance = new GameManager();
    public static GameManager Instance => s_instance;

    Dictionary<int, Action> _onStartAction = new Dictionary<int, Action>();
    Dictionary<int, ManagerBase> _managerDic = new Dictionary<int, ManagerBase>();

    /// <summary>
    /// �Q�[���J�n����Action�̓o�^�B�d�����Ȃ��悤�ɒǉ�
    /// </summary>
    /// <param name="path">Key</param>
    /// <param name="action">Value</param>
    public void SetOnStartAction(int instanceID, Action action)
    {
        if (_onStartAction.Count <= 0)
        {
            _onStartAction.Add(instanceID, action);
        }
        else
        {
            if (_onStartAction.All(a => a.Key != instanceID))
            {
                _onStartAction.Add(instanceID, action);
            }
        }
    }

    /// <summary>
    /// �Q�[���J�n���ɂ���Manager��SetUp
    /// </summary>
    public void OnStart()
    {
        if (_onStartAction.Count <= 0) return;
        
        foreach (var pair in _onStartAction)
        {
            pair.Value.Invoke();
        }
    }

    /// <summary>
    /// �eManager�̒ǉ�
    /// </summary>
    /// <param name="manager">Manager</param>
    public void AddMaager(ManagerBase manager)
    {
        if (_managerDic.Count <= 0)
        {
            _managerDic.Add(manager.GetInstanceID(), manager);
        }
        else
        {
            if (_managerDic.All(m => m.Key != manager.GetInstanceID()))
            {
                _managerDic.Add(manager.GetInstanceID(), manager);
            }
        }
    }

    /// <summary>
    /// �eManager�̎擾
    /// </summary>
    /// <typeparam name="Manager">ManagerBase���p�������h���N���X</typeparam>
    /// <param name="instanceID">Manager��ID</param>
    /// <returns>Manager</returns>
    public Manager GetManager<Manager>(int instanceID) where Manager : ManagerBase
    {
        Manager get;

        try
        {
            get = (Manager)_managerDic.First(m => instanceID == m.Key).Value;
        }
        catch (Exception)
        {
            return null;
        }

        return get;
    }

    /// <summary>
    /// Manager�̏���
    /// </summary>
    /// <param name="manager">Manager</param>
    public void RemoveManager(ManagerBase manager)
    {
        if (_managerDic.Count <= 0) return;

        var pair = _managerDic.First(m => m.Key == manager.GetInstanceID());
        _managerDic.Remove(pair.Key);
    }

    /// <summary>
    /// �V�[���ύX���̏�����
    /// </summary>
    public void Dispose()
    {
        _onStartAction = new Dictionary<int, Action>();
        _managerDic = new Dictionary<int, ManagerBase>();
    }
}
