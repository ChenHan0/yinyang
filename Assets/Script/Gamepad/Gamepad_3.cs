using UnityEngine;

public class Gamepad_3 : Gamepad
{
    private static Gamepad_3 instance;
    private Gamepad_3()
    {

    }

    public static Gamepad_3 Instance
    {
        get
        {
            if (null == instance)
                instance = new Gamepad_3();
            return instance;
        }
    }

    public override float GetLSHorizontal()
    {
        return Input.GetAxis("Pad3_LS_Horizontal");
    }

    public override float GetLSVertical()
    {
        return Input.GetAxis("Pad3_LS_Vertical");
    }

    public override bool GetButtonADown()
    {
        return Input.GetButtonDown("Pad3_A");
    }

    public override bool GetButtonBDown()
    {
        return Input.GetButtonDown("Pad3_B");
    }

    public override bool GetButtonXDown()
    {
        return Input.GetButtonDown("Pad3_X");
    }
}
