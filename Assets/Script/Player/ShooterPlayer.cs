using UnityEngine;
using System.Collections;

public class ShooterPlayer : Player {

    public float RotateSpeed = 5f;
    public float MoveSpeed = 10f;

    public float ShootSpeed = 70f;

    public float SkillSpeed = 80f;
    public GameObject SkillBallPrefab;

    public Transform ShootPoint;
    public GameObject BallPrefab;

    private Rigidbody rigibody;

    private bool isHaveBall = false;

    public Gamepad gamepad;

    private Animator anim;

    public int RequiredCatchCount = 3;
    private int currentCatchCount = 0;

    // Use this for initialization
    void Start () {
        rigibody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        GameStateManager.SetCurrentState(PlayingState.Instance);
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (null != gamepad)
        {
            if (GameStateManager.GetCurrentState().Equals(PlayingState.Instance))
            {
                MoveAndRotate();

                Shoot();

                UseSkill();
            }
            else if (GameStateManager.GetCurrentState().Equals(SkillState.Instance))
            {
                SkillState state = GameStateManager.GetCurrentState() as SkillState;
                if (gameObject.Equals(state.player.gameObject))
                {
                    Rotate();
                    ShootSkill();
                }
            }
        }      
    }

    public void AddCatchCount()
    {
        if (currentCatchCount < RequiredCatchCount)
            currentCatchCount++;
    }

    void ShootSkill()
    {
        if (gamepad.GetButtonADown())
        {
            anim.SetTrigger("Skill");
            GameObject ball = Instantiate(BallPrefab, ShootPoint.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody>().velocity = -transform.forward * ShootSpeed;
            isHaveBall = false;
            GameStateManager.SetCurrentState(PlayingState.Instance);
        }
    }

    void Rotate()
    {
        float Horizontal = gamepad.GetLSHorizontal();
        float Vertical = gamepad.GetLSVertical();

        Vector3 movement = new Vector3(Horizontal, 0, Vertical);
        movement = movement.normalized;

        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(movement), RotateSpeed * Time.deltaTime);
        }
    }

    void UseSkill()
    {
        if (gamepad.GetButtonBDown() && currentCatchCount == RequiredCatchCount
            && isHaveBall)
        {
            SkillState state = SkillState.Instance;
            state.player = this;
            GameStateManager.ChangeState(state);
        }
    }

    void Shoot()
    {
        if (gamepad.GetButtonADown())
        {
            if (isHaveBall)
            {
                anim.SetTrigger("Skill");
                GameObject ball = Instantiate(BallPrefab, ShootPoint.position, Quaternion.identity) as GameObject;
                ball.GetComponent<Rigidbody>().velocity = -transform.forward * ShootSpeed;
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
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(movement), RotateSpeed * Time.deltaTime);
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }


        //rigibody.MovePosition(transform.position - movement * MoveSpeed * Time.deltaTime);
        rigibody.velocity = -movement * MoveSpeed;
    }

}
