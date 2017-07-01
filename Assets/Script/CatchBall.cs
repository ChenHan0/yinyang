using UnityEngine;
using System.Collections;

public class CatchBall : MonoBehaviour {
    public Player player;

    public float BallVelocity;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            player.isColliderWork = false;
            if (other.GetComponent<Rigidbody>().velocity.magnitude >= BallVelocity)
            {
                ShooterPlayer splayer = player.GetComponent<ShooterPlayer>();
                if (null != splayer)
                {
                    splayer.AddCatchCount();
                }
            }

            Destroy(other.gameObject);
            player.CatchBall();

            Invoke("ColliderWork", 0.5f);
        }
    }


    void ColliderWork()
    {
        player.isColliderWork = true;
    }
}
