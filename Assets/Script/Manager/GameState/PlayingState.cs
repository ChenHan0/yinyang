using UnityEngine;
using System.Collections;

public class PlayingState : GameState
{
    private static PlayingState instance;
    private PlayingState() { }

    public static PlayingState Instance
    {
        get
        {
            if (null == instance)
                instance = new PlayingState();
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
