using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject Runner;
    public GameObject Defender;

    public CreatePlayer CreatePlayer;
    public GameObject BallPrefab;

    public bool IsPlusOneSecond = false;

    // Use this for initialization
    void Start () {
        GameStateManager.SetCurrentState(TitleState.Instance);
	}
	
	// Update is called once per frame
	void Update () {
        PlusOneSecond();
    }

    void isGameOver()
    {
        if (null == Runner || null == Defender)
        {
            GameOverState.Instance.IsShooterWin = true;
            GameStateManager.SetCurrentState(GameOverState.Instance);
        }
    }

    public void ChangePlayer()
    {
        if (null != Runner)
        {
            DefenderPlayer def = Defender.GetComponent<DefenderPlayer>();
            RunnerPlayer run = Runner.GetComponent<RunnerPlayer>();

            def.gamepad.isUse = false;
            def.gamepad = run.gamepad;
            def.playingUI = run.playingUI;
        }
        else if (null == Runner)
        {
            isGameOver();
        }

        Destroy(Runner);
    }

    public void PlusOneSecond()
    {
        if (null == Runner && IsPlusOneSecond)
        {
            GameObject go = CreatePlayer.CreateRunner();
            if (null != go)
            {
                Runner = go;
                IsPlusOneSecond = false;
            }               
        }
    }

    public void CreateBall()
    {
        Instantiate(BallPrefab);
    }
}
