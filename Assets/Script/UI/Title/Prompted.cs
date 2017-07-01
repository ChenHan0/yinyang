using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prompted : MonoBehaviour {
    public GameObject Options;
    public IconMove Icon;

    public float ChangeAlphaSpeed = 5f;
    private int temp = 0;

    public bool IsColliderWork = true;

    private Gamepad pad;
    private Text text;
    private Color color;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        color = text.color;
        Debug.Log(color);
	}
	
	// Update is called once per frame
	void Update () {
        ListenToGamepad();

        ChangeAlpha();
    }

    void ChangeAlpha()
    {
        color = text.color;
        if (color.a == 0 || color.a == 1)
        {
            temp++;
        }
        text.color = new Color(color.r, color.g, color.b,
                 Mathf.Clamp01(color.a + ChangeAlphaSpeed * Time.deltaTime * Mathf.Pow(-1, temp)));
        
    }

    void ListenToGamepad() {
        pad = GamepadManager.GetCurrentPad();
        if (null != pad) {
            Icon.pad = pad;
            Options.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
