using UnityEngine;
using System.Collections;

public class ReadyState : GameState {
    private static ReadyState instance;
    private ReadyState() { }

    public static ReadyState Instance
    {
        get
        {
            if (null == instance)
                instance = new ReadyState();
            return instance;
        }
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
    }
}
