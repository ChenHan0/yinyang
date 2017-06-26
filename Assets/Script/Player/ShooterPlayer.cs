using UnityEngine;
using System.Collections;

public class ShooterPlayer : Player {

    public float RotateSpeed = 5f;
    public float MoveSpeed = 10f;

    public float ShootSpeed = 20f;

    public Transform ShootPoint;
    public GameObject BallPrefab;

    private Rigidbody rigibody;

    private bool isHaveBall = false;

    private Gamepad gamepad;

	// Use this for initialization
	void Start () {
        rigibody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (null == gamepad)
        {
            gamepad = GamepadManager.GetCurrentPad();
        }
        else
        {
            MoveAndRotate();

            Shoot();
        }        
    }

    void Shoot()
    {
        if (gamepad.GetButtonADown())
        {
            if (isHaveBall)
            {
                GameObject ball = Instantiate(BallPrefab, ShootPoint.position, Quaternion.identity) as GameObject;
                ball.GetComponent<Rigidbody>().velocity = transform.forward * ShootSpeed;
                isHaveBall = !isHaveBall;
            }
        }
    }

    public override void CatchBall()
    {
        isHaveBall = true;
        Debug.Log(isHaveBall);
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

}
