using UnityEngine;
using System.Collections;

public enum IconState {
    Start = 0,
    About,
    Exit
}

public class IconMove : MonoBehaviour {
    public float RotateSpeed = 10f;
    public GameObject Title;
    public GameObject Option;
    public GameObject CreatorList;
    public GameObject TitleTotalUI;
    public GameObject PlayingTotalUI;

    private RectTransform rect;
    public Gamepad pad;
    [HideInInspector]
    public IconState iconState;
    private bool isMoved = false;
    private Vector2 pos;

	// Use this for initialization
	void Start () {
        rect = transform as RectTransform;
        iconState = IconState.Start;
        pos = rect.anchoredPosition;
	}
	
	// Update is called once per frame
	void Update () {
        RotateSelf();
        if (null != pad)
        {
            Move();
            PressABtn();
        }
    }

    void PressABtn()
    {
        if (pad.GetButtonADown())
        {
            switch ((int)iconState) {
                case 0:
                    GameStateManager.SetCurrentState(ReadyState.Instance);
                    PlayingTotalUI.SetActive(true);
                    TitleTotalUI.SetActive(false);
                    break;
                case 1:
                    CreatorList.SetActive(true);
                    CreatorList.GetComponent<CreatorList>().pad = pad;
                    Title.SetActive(false);
                    Option.SetActive(false);
                    break;
                case 2:
                    Application.Quit();
                    break;
            }

        }
    }

    void RotateSelf()
    {
        rect.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));
    }

    void Move()
    {
        if (pad.GetLSVertical() > 0.5f && !isMoved)
        {
            isMoved = true;
            if (iconState != IconState.Start && (int)iconState <= 2)
            {
                iconState--;
            }
        }
        else if (pad.GetLSVertical() < -0.5f && !isMoved)
        {
            isMoved = true;
            if (iconState != IconState.Exit && (int)iconState >= 0)
            {
                iconState++;
            }
        }
        else if(pad.GetLSVertical() == 0)
        {
            isMoved = false;
        }

        rect.anchoredPosition = new Vector2(pos.x, pos.y - 100 * (int)iconState);
    }
}
