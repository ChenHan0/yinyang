using UnityEngine;

public class Gamepad_2 : Gamepad
{
    private static Gamepad_2 instance;
    private Gamepad_2()
    {

    }

    public static Gamepad_2 Instance
    {
        get
        {
            if (null == instance)
                instance = new Gamepad_2();
            return instance;
        }
    }

    public override float GetLSHorizontal()
    {
        return Input.GetAxis("Pad2_LS_Horizontal");
    }

    public override float GetLSVertical()
    {
        return Input.GetAxis("Pad2_LS_Vertical");
    }

    public override bool GetButtonADown()
    {
        return Input.GetButtonDown("Pad2_A");
    }

    public override bool GetButtonBDown()
    {
        return Input.GetButtonDown("Pad2_B");
    }

    public override bool GetButtonXDown()
    {
        return Input.GetButtonDown("Pad2_X");
    }
}
