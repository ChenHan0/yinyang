using UnityEngine;

public class Gamepad_4 : Gamepad
{
    private static Gamepad_4 instance;
    private Gamepad_4()
    {

    }

    public static Gamepad_4 Instance
    {
        get
        {
            if (null == instance)
                instance = new Gamepad_4();
            return instance;
        }
    }

    public override float GetLSHorizontal()
    {
        return Input.GetAxis("Pad4_LS_Horizontal");
    }

    public override float GetLSVertical()
    {
        return Input.GetAxis("Pad4_LS_Vertical");
    }

    public override bool GetButtonADown()
    {
        return Input.GetButtonDown("Pad4_A");
    }

    public override bool GetButtonBDown()
    {
        return Input.GetButtonDown("Pad4_B");
    }

    public override bool GetButtonXDown()
    {
        return Input.GetButtonDown("Pad4_X");
    }
}
