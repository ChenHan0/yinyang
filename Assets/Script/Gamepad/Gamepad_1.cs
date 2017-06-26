using UnityEngine;

public class Gamepad_1 : Gamepad {
    private static Gamepad_1 instance;
    private Gamepad_1()
    {

    }

    public static Gamepad_1 Instance
    {
        get
        {
            if (null == instance)
                instance = new Gamepad_1();
            return instance;
        }
    }

    public override float GetLSHorizontal()
    {
        return Input.GetAxis("Pad1_LS_Horizontal");
    }

    public override float GetLSVertical()
    {
        return Input.GetAxis("Pad1_LS_Vertical");
    }

    public override bool GetButtonADown()
    {
        return Input.GetButtonDown("Pad1_A");
    }

    public override bool GetButtonBDown()
    {
        return Input.GetButtonDown("Pad1_B");
    }

    public override bool GetButtonXDown()
    {
        return Input.GetButtonDown("Pad1_X");
    }
}
