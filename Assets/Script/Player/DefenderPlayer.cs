using UnityEngine;
using System.Collections;

public class DefenderPlayer : Player
{
    public float RotateSpeed = 5f;
    public float MoveSpeed = 10f;
    public float RushSpeed = 100f;
    public float RushTime = 0.1f;
    public float RushColdDown = 2.0f;
    private float CurrentSpeed;
    private bool isCanRush = true;

    public float ShootSpeed = 20f;

    public Transform ShootPoint;
    public GameObject BallPrefab;

    private Rigidbody rigibody;

    private bool isHaveBall = false;
    
    public Gamepad gamepad;

    public GameManager GM;

    public float AutoShootTime = 3f;

    // Use this for initialization
    void Start () {
        rigibody = GetComponent<Rigidbody>();

        CurrentSpeed = MoveSpeed;
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (null != gamepad)
        {
            if (GameStateManager.GetCurrentState().Equals(PlayingState.Instance))
            {
                MoveAndRotate();

                Shoot();

                Rush();
            }           
        }
    }

    void Rush()
    {
        if (gamepad.GetButtonXDown() && isCanRush)
        {
            isCanRush = false;
            CurrentSpeed = RushSpeed;
            Invoke("ResetSpeed", RushTime);
        }
    }

    void ResetSpeed()
    {
        CurrentSpeed = MoveSpeed;
        Invoke("CanRush", RushColdDown);
    }

    void CanRush()
    {
        isCanRush = true;
    }

    void Shoot()
    {
        if (gamepad.GetButtonADown())
        {
            
            {
                CancelInvoke();
                AutoShoot();
            }
        }
    }

    void PlusOne()
    {
        if (gamepad.GetButtonBDown())
        {
            if (isHaveBall)
            {
                GM.IsPlusOneSecond = true;
                isHaveBall = !isHaveBall;
                GM.CreateBall();
            }
        }
    }

    void AutoShoot()
    {
        //anim.SetTrigger("Skill");
        GameObject ball = Instantiate(BallPrefab, ShootPoint.position, Quaternion.identity) as GameObject;
        ball.GetComponent<Rigidbody>().velocity = -transform.forward * ShootSpeed;
        isHaveBall = !isHaveBall;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball" && isColliderWork && 
            GameStateManager.GetCurrentState().Equals(PlayingState.Instance))
        {
            GM.ChangePlayer();
        }
    }

    public override void CatchBall()
    {
        isHaveBall = true;
        Invoke("AutoShoot", AutoShootTime);
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
                Quaternion.LookRotation(movement), RotateSpeed * Time.deltaTime);

        //rigibody.MovePosition(transform.position - movement * CurrentSpeed * Time.deltaTime);
        rigibody.velocity = -movement * CurrentSpeed;
    }
}
