using UnityEngine;
using System.Collections;

public class GameOverState : GameState {
    public bool IsShooterWin = true;

    private static GameOverState instance;
    private GameOverState() { }

    public static GameOverState Instance
    {
        get
        {
            if (null == instance)
                instance = new GameOverState();
            return instance;
        }
    }

    public override void Enter()
    {
        if (IsShooterWin)
        {
            Debug.Log("进攻方胜利");
        }
        else
        {
            Debug.Log("防守方胜利");
        }
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
    }
}
