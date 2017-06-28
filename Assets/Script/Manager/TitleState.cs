using UnityEngine;
using System.Collections;

public class TitleState : GameState
{
    private static TitleState instance;
    private TitleState() { }

    public static TitleState Instance
    {
        get
        {
            if (null == instance)
                instance = new TitleState();
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
