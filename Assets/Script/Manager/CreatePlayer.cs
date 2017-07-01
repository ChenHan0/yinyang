using UnityEngine;
using System.Collections;

public class CreatePlayer : MonoBehaviour {
    public GameObject ShooterPlayer;
    public GameObject RunnerPlayer;
    public GameObject DefenderPlayer;
    public PlayingUI[] PlayingUIs;

    private int currentPlayer = 0;

    private Gamepad pad;

    public GameManager GM;

    void Update()
    {
        if (GameStateManager.GetCurrentState().Equals(PlayingState.Instance) &&
            currentPlayer < 4)
        {
            ListenGamepad();
        }
    }

    private void ListenGamepad()
    {
        pad = GamepadManager.GetCurrentPad();
        if (null != pad && !pad.isUse)
        {
            if (currentPlayer < 2)
            {
                pad.isUse = true;
                CreaeteShooterPlayer(pad);
            }
            else if (currentPlayer < 3)
            {
                pad.isUse = true;
                CreateDefenderPlayer(pad);
            }
            else
            {
                pad.isUse = true;
                CreateRunnerPlayer(pad);
                GameStateManager.SetCurrentState(PlayingState.Instance);
            }
            currentPlayer++;
        }
    }

    public GameObject CreateRunner()
    {
        pad = GamepadManager.GetCurrentPad();
        if (null != pad && !pad.isUse)
        {
            pad.isUse = true;
            return CreateRunnerPlayer(pad);
        }
        return null;
    }

    private void CreaeteShooterPlayer(Gamepad pad)
    {
        GameObject shooter = Instantiate(ShooterPlayer);
        ShooterPlayer shooterPlayer = shooter.GetComponent<ShooterPlayer>();
        shooterPlayer.gamepad = pad;
        shooterPlayer.playingUI = PlayingUIs[currentPlayer];
        shooterPlayer.playingUI.Starting();
    }

    private GameObject CreateRunnerPlayer(Gamepad pad)
    {
        GameObject runner = Instantiate(RunnerPlayer);
        RunnerPlayer runnerPlayer = runner.GetComponent<RunnerPlayer>();
        runnerPlayer.gamepad = pad;
        runnerPlayer.playingUI = PlayingUIs[currentPlayer];
        runnerPlayer.playingUI.Starting();
        GM.Runner = runner;

        return runner;
    }

    private void CreateDefenderPlayer(Gamepad pad)
    {
        GameObject defender = Instantiate(DefenderPlayer);
        DefenderPlayer defenderPlayer = defender.GetComponent<DefenderPlayer>();
        defenderPlayer.gamepad = pad;
        defenderPlayer.playingUI = PlayingUIs[currentPlayer];
        defenderPlayer.playingUI.Starting();
        GM.Defender = defender;
        defenderPlayer.GM = GM;
    }
}
