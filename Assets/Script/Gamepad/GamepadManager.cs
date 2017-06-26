using UnityEngine;
using System.Collections;

public class GamepadManager
{

    public static Gamepad GetCurrentPad()
    {
        for (int i = 1; i <= 4; i++)
        {
            if (Input.GetButtonDown("Pad" + i + "_A"))
            {
                Debug.Log(i);
                return GetPad(i);
            }
        }

        return null;
    }

    private static Gamepad GetPad(int i)
    {
        switch (i)
        {
            case 1:
                return Gamepad_1.Instance;
            case 2:
                return Gamepad_2.Instance;
            case 3:
                return Gamepad_3.Instance;
            case 4:
                return Gamepad_4.Instance;
            default:
                return null;
        }
    }
}
