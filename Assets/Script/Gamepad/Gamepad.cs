using UnityEngine;
using System.Collections;

public class Gamepad {
    public virtual float GetLSHorizontal()
    {
        return 0.0f;
    }

    public virtual float GetLSVertical()
    {
        return 0.0f;
    }

    public virtual bool GetButtonADown()
    {
        return false;
    }

    public virtual bool GetButtonBDown()
    {
        return false;
    }

    public virtual bool GetButtonXDown()
    {
        return false;
    }
}
