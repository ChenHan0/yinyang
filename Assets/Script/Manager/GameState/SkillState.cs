using UnityEngine;
using System.Collections;

public class SkillState : GameState
{
    private static SkillState instance;
    public Player player;
    private SkillState() { }

    public static SkillState Instance
    {
        get
        {
            if (null == instance)
                instance = new SkillState();
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
