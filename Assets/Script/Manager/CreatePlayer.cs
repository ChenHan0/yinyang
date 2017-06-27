using UnityEngine;
using System.Collections;

public class CreatePlayer : MonoBehaviour {
    public GameObject ShooterPlayer;
    public GameObject RunnerPlayer;
    public GameObject DefenderPlayer;

    private int currentPlayer = 0;

    private Gamepad pad;

    void Update()
    {
        if (currentPlayer < 4)
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
            }
            currentPlayer++;
        }
    }

    private void CreaeteShooterPlayer(Gamepad pad)
    {
        GameObject shooter = Instantiate(ShooterPlayer);
        shooter.GetComponent<ShooterPlayer>().gamepad = pad;
    }

    private void CreateRunnerPlayer(Gamepad pad)
    {
        GameObject runner = Instantiate(RunnerPlayer);
        runner.GetComponent<RunnerPlayer>().gamepad = pad;
    }

    private void CreateDefenderPlayer(Gamepad pad)
    {
        GameObject defender = Instantiate(DefenderPlayer);
        defender.GetComponent<DefenderPlayer>().gamepad = pad;
    }
}
