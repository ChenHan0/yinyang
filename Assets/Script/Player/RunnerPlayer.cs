using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RunnerPlayer : Player {
    public float RotateSpeed = 3f;
    public float MoveSpeed = 3f;

    public Text text;

    private Rigidbody rigibody;

    private int turns = 0;

    public Gamepad gamepad;

    [HideInInspector]
    public bool[] points;

    // Use this for initialization
    void Start () {
        rigibody = GetComponent<Rigidbody>();

        points = new bool[8];

        ResetPoints();

    }

    void ResetPoints()
    {
        for (int i = points.Length - 1; i >= 0; i--)
        {
            points[i] = false;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (null != gamepad)
        {
            if (GameStateManager.GetCurrentState().Equals(PlayingState.Instance))
            {
                MoveAndRotate();

                DisplayPoints();
            }                
        }       
    }

    public void FinishRun()
    {
        turns++;

        text.text = turns.ToString();

        ResetPoints();
        points[0] = true;
        Debug.Log(turns);    
    }

    void MoveAndRotate()
    {
        float Horizontal = gamepad.GetLSHorizontal();
        float Vertical = gamepad.GetLSVertical();
        Vector3 movement = new Vector3(Horizontal, 0, Vertical);
        movement = movement.normalized;

        if (movement.magnitude > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(-movement), RotateSpeed * Time.deltaTime);

        rigibody.MovePosition(transform.position - movement * MoveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("The Runner is Dead");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SocrePoint")
        {
            other.GetComponent<ScorePoint>().GetThisPoint(this);
        }
    }

    void DisplayPoints()
    {
        string str = "points: ";
        for (int i = 0; i < points.Length; i++)
        {
            str += (i + ": " + points[i] + "\t");
        }

        Debug.Log(str);
    }
}
