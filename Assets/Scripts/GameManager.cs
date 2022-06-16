using System;

public class GameManager
{
    private static GameManager s_instance = new GameManager();
    public static GameManager Instance => s_instance;

    Action _action;

    public void SetOnStart(Action action)
    {
        
        _action += action;
    }
}
