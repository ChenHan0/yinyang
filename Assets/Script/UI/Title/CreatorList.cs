using UnityEngine;
using System.Collections;

public class CreatorList : MonoBehaviour {
    public Gamepad pad;
    public GameObject Title;
    public GameObject Option;
    public IconMove icon;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        ListenToBtnA();
    }

    void ListenToBtnA()
    {
        if (null != pad)
        {
            if (pad.GetButtonADown())
            {
                Title.SetActive(true);
                Option.SetActive(true);
                icon.pad = pad;
                icon.iconState = IconState.Start;
                gameObject.SetActive(false);
            }
        }
    }
}
