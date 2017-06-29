using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayingUI : MonoBehaviour {
    public Text Name;
    public Text Career;
    public Text Skill;
    public Text Prompted;

    public float ChangeAlphaSpeed = 1.0f;
    private int temp = 0;
    
    private Color color;

    private bool isStart = false;

    // Use this for initialization
    void Start () {
        color = Prompted.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isStart)
            ChangeAlpha();
    }

    void ChangeAlpha()
    {
        color = Prompted.color;
        if (color.a == 0 || color.a == 1)
        {
            temp++;
        }
        Prompted.color = new Color(color.r, color.g, color.b,
                 Mathf.Clamp01(color.a + ChangeAlphaSpeed * Time.deltaTime * Mathf.Pow(-1, temp)));

    }

    public void Starting()
    {
        Prompted.gameObject.SetActive(false);
        Name.gameObject.SetActive(true);
        Career.gameObject.SetActive(true);
        Skill.gameObject.SetActive(true);
    }

    public void ChangeSkillText(string s)
    {
        Skill.text = s;
    }
}
